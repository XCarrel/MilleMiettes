using System.Text.Json;
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

        // The model displayed by the form, kept so it can be saved later
        private readonly Business me;

        public Backoffice()
        {
            InitializeComponent();

            // First run: seed %AppData% with the copy shipped next to the executable
            if (!File.Exists(DataFile))
            {
                SaveBusiness(LoadBusiness(Path.Combine(AppContext.BaseDirectory, "COM-7777.json")));
            }

            me = LoadBusiness(DataFile);
            Render(me);

            UMDDTime time = JsonSerializer.Deserialize<UMDDTime>(File.ReadAllText(TimeFile))!;
            labelTime.Text = time.LocalTime.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Copy the edited values from the form into the model
            me.Special.Price = (double)numericUpDownSpecialPrice.Value;

            SaveBusiness(me);
            MessageBox.Show($"Enregistré dans {DataFile}", "Backoffice");
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
            numericUpDownSpecialPrice.Value = (decimal)special.Price;
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
