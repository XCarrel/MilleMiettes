using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using MQTTnet;
using MQTTnet.Client;
using SkiaSharp;

namespace MilleMiettes
{
    public partial class Backoffice : Form
    {
        // %AppData%\MilleMiettes\COM-7777.json
        private static readonly string DataFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MilleMiettes",
            "COM-7777.json");

        // %AppData%\MilleMiettes\time.json
        private static readonly string TimeFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MilleMiettes",
            "time.json");

        // Copied next to the executable at build time
        private static readonly JsonSchema EnvelopeSchema = JsonSchema.FromFile(
            Path.Combine(AppContext.BaseDirectory, "contracts", "envelope.schema.json"));

        private const string MqttBroker = "mqtt.blue.section-inf.ch";
        private const string MqttUsername = "ict";
        private const string MqttPassword = "321";
        private const string TimeTopic = "umddcmid3b/time";
        private const string LogTopic = "umddcmid3b/log";

        private readonly MqttFactory mqttFactory = new MqttFactory();
        private readonly IMqttClient mqttClient;

        // The model displayed by the form, kept so it can be saved later
        private readonly Business me;

        // Last time received, kept to refresh the open/closed status when the hours change
        private DateTime currentTime;

        // Open/closed status last displayed, null until the first time is shown
        private bool? wasOpen;

        public Backoffice()
        {
            InitializeComponent();

            // First run: seed %AppData% with the copy shipped next to the executable
            string shippedFile = Path.Combine(AppContext.BaseDirectory, "COM-7777.json");
            if (!File.Exists(DataFile))
            {
                SaveBusiness(LoadBusiness(shippedFile));
            }

            me = LoadBusiness(DataFile);

            // Data file written before opening hours existed: take the default ones from the shipped copy
            if (me.OpeningHours == null)
            {
                me.OpeningHours = LoadBusiness(shippedFile).OpeningHours ?? new List<OpeningDay>();
                SaveBusiness(me);
            }
            Render(me);

            UMDDTime time = JsonSerializer.Deserialize<UMDDTime>(File.ReadAllText(TimeFile))!;
            ShowTime(time.LocalTime);

            // Subscribed after Render so that displaying the initial price does not trigger a save
            numericUpDownSpecialPrice.ValueChanged += numericUpDownSpecialPrice_ValueChanged;

            mqttClient = mqttFactory.CreateMqttClient();
            mqttClient.ApplicationMessageReceivedAsync += OnMqttMessageReceived;
            Load += Backoffice_Load;
        }

        private async void Backoffice_Load(object? sender, EventArgs e)
        {
            MqttClientOptions options = new MqttClientOptionsBuilder()
                .WithTcpServer(MqttBroker)
                .WithCredentials(MqttUsername, MqttPassword)
                .Build();
            await mqttClient.ConnectAsync(options, CancellationToken.None);

            MqttClientSubscribeOptions subscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => f.WithTopic(TimeTopic))
                .Build();
            await mqttClient.SubscribeAsync(subscribeOptions, CancellationToken.None);
        }

        private Task OnMqttMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            string message = e.ApplicationMessage.ConvertPayloadToString();

            if (!IsValidEnvelope(message))
            {
                return Task.CompletedTask;
            }
            Envelope envelope = JsonSerializer.Deserialize<Envelope>(message);
            if (envelope.V != 1) return Task.CompletedTask; // ignore unknown envelope versions

            Time time = JsonSerializer.Deserialize<Time>(envelope.Payload)!;

            // MQTTnet raises this event on a background thread: the labels must be updated on the UI thread
            BeginInvoke(() => ShowTime(time.LocalTime));
            return Task.CompletedTask;
        }

        /// <summary>
        ///  Checks that a received message is a well-formed envelope (see contracts\envelope.schema.json).
        /// </summary>
        private static bool IsValidEnvelope(string payload)
        {
            JsonNode? message;
            try
            {
                message = JsonNode.Parse(payload);
            }
            catch (JsonException)
            {
                return false; // not even JSON
            }

            // In draft 2020-12, "format" (uuid, date-time) is only an annotation unless validation is required explicitly
            EvaluationOptions options = new EvaluationOptions { RequireFormatValidation = true };
            return EnvelopeSchema.Evaluate(message, options).IsValid;
        }

        /// <summary>
        ///  Displays the current time and whether the shop is open at that time.
        /// </summary>
        private void ShowTime(DateTime time)
        {
            currentTime = time;
            labelTime.Text = time.ToString("dd.MM.yyyy HH:mm:ss");

            bool open = IsOpen(time);
            if (open)
            {
                labelOpenStatus.Text = "Nous sommes ouverts";
                labelOpenStatus.BackColor = Color.Green;
            }
            else
            {
                labelOpenStatus.Text = "Nous sommes fermés";
                labelOpenStatus.BackColor = Color.DarkOrange;
            }

            // Only a change is logged: the status known at startup is not an opening or a closing
            if (wasOpen.HasValue && wasOpen.Value != open)
            {
                string text = $"{me.Name} {(open ? "ouvre" : "ferme")} ({time:dd.MM.yyyy HH:mm})";
                _ = PublishLog(new Log("info", text));
            }
            wasOpen = open;
        }

        /// <summary>
        ///  Wraps a log in an envelope and publishes it on the log topic. Dropped if the broker is not connected.
        /// </summary>
        private async Task PublishLog(Log log)
        {
            if (!mqttClient.IsConnected) return;

            Envelope envelope = new Envelope(
                1,
                Guid.NewGuid(),
                me.ID,
                "*",
                DateTimeOffset.UtcNow,
                "log",
                JsonSerializer.SerializeToElement(log));

            MqttApplicationMessage message = new MqttApplicationMessageBuilder()
                .WithTopic(LogTopic)
                .WithPayload(JsonSerializer.Serialize(envelope))
                .Build();

            try
            {
                await mqttClient.PublishAsync(message, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Log non envoyé : {ex.Message}");
            }
        }

        private bool IsOpen(DateTime time)
        {
            OpeningDay? day = me.OpeningHours!.FirstOrDefault(d => d.Day == time.DayOfWeek);
            if (day == null) return false;

            TimeOnly now = TimeOnly.FromDateTime(time);
            return day.Slots.Any(s =>
                now >= TimeOnly.ParseExact(s.Open, "HH:mm", CultureInfo.InvariantCulture) &&
                now < TimeOnly.ParseExact(s.Close, "HH:mm", CultureInfo.InvariantCulture));
        }

        private void numericUpDownSpecialPrice_ValueChanged(object? sender, EventArgs e)
        {
            // The form shows francs, the model stores centimes
            me.Special.Price = (int)Math.Round(numericUpDownSpecialPrice.Value * 100);
            SaveBusiness(me);
        }

        private void buttonOpeningHours_Click(object sender, EventArgs e)
        {
            using OpeningHoursForm form = new OpeningHoursForm(me.OpeningHours!);
            if (form.ShowDialog(this) != DialogResult.OK) return;

            me.OpeningHours = form.OpeningHours;
            SaveBusiness(me);
            ShowTime(currentTime); // the new hours may change the open/closed status
        }

        private static Business LoadBusiness(string path)
        {
            return JsonSerializer.Deserialize<Business>(File.ReadAllText(path))!;
        }

        private static void SaveBusiness(Business business)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DataFile)!);
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(DataFile, JsonSerializer.Serialize(business, options));
        }

        private void Render(Business business)
        {
            Text = business.Name;
            pictureBoxLogo.Image = LoadImage(business.Logo);
            labelBusinessName.Text = business.Name;
            labelBusinessId.Text = business.ID;

            Special special = business.Special;
            pictureBoxSpecial.Image = LoadImage(special.Picture);
            labelSpecialName.Text = special.Name;
            labelSpecialId.Text = special.ID;
            numericUpDownSpecialPrice.Value = special.Price / 100m;
        }

        /// <summary>
        ///  Decodes a base64 data URI. SkiaSharp is needed because GDI+ cannot read WebP (the logo format).
        /// </summary>
        private static Image LoadImage(string dataUri)
        {
            byte[] bytes = Convert.FromBase64String(dataUri[(dataUri.IndexOf(',') + 1)..]);
            using SKBitmap bitmap = SKBitmap.Decode(bytes);
            using SKData png = bitmap.Encode(SKEncodedImageFormat.Png, 100);

            // GDI+ keeps reading from the stream as long as the image lives: it must stay open.
            return Image.FromStream(new MemoryStream(png.ToArray()));
        }
    }
}
