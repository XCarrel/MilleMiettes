using System.Globalization;

namespace MilleMiettes
{
    /// <summary>
    ///  Edits the opening hours of the week: up to two slots per day (e.g. morning and afternoon).
    ///  A day with no checked slot is closed.
    /// </summary>
    public partial class OpeningHoursForm : Form
    {
        private const string TimeFormat = "HH:mm";
        private const int SlotsPerDay = 2;

        // Week displayed from Monday to Sunday
        private static readonly DayOfWeek[] Week =
        {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,
            DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
        };

        // Values proposed when a slot is checked on a day that had none
        private static readonly (TimeOnly Open, TimeOnly Close)[] DefaultSlots =
        {
            (new TimeOnly(8, 0), new TimeOnly(12, 0)),
            (new TimeOnly(13, 0), new TimeOnly(18, 0))
        };

        // [day, slot]
        private readonly CheckBox[,] slotChecks = new CheckBox[Week.Length, SlotsPerDay];
        private readonly DateTimePicker[,] openPickers = new DateTimePicker[Week.Length, SlotsPerDay];
        private readonly DateTimePicker[,] closePickers = new DateTimePicker[Week.Length, SlotsPerDay];

        /// <summary>
        ///  The edited opening hours, available once the dialog is closed with OK.
        /// </summary>
        public List<OpeningDay> OpeningHours { get; private set; }

        public OpeningHoursForm(List<OpeningDay> openingHours)
        {
            InitializeComponent();
            OpeningHours = openingHours;
            BuildRows(openingHours);
        }

        private void BuildRows(List<OpeningDay> openingHours)
        {
            CultureInfo french = CultureInfo.GetCultureInfo("fr-CH");

            for (int d = 0; d < Week.Length; d++)
            {
                string dayName = french.DateTimeFormat.GetDayName(Week[d]);
                tableLayoutPanelDays.Controls.Add(new Label
                {
                    Text = char.ToUpper(dayName[0]) + dayName[1..],
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                }, 0, d + 1);

                List<TimeSlot> slots = openingHours.FirstOrDefault(o => o.Day == Week[d])?.Slots ?? new List<TimeSlot>();

                for (int s = 0; s < SlotsPerDay; s++)
                {
                    bool used = s < slots.Count;
                    TimeOnly open = used ? ParseTime(slots[s].Open) : DefaultSlots[s].Open;
                    TimeOnly close = used ? ParseTime(slots[s].Close) : DefaultSlots[s].Close;

                    CheckBox check = new CheckBox { Checked = used, AutoSize = true, Anchor = AnchorStyles.Left };
                    DateTimePicker openPicker = CreateTimePicker(open, used);
                    DateTimePicker closePicker = CreateTimePicker(close, used);
                    check.CheckedChanged += (_, _) =>
                    {
                        openPicker.Enabled = check.Checked;
                        closePicker.Enabled = check.Checked;
                    };

                    int column = 1 + s * 3;
                    tableLayoutPanelDays.Controls.Add(check, column, d + 1);
                    tableLayoutPanelDays.Controls.Add(openPicker, column + 1, d + 1);
                    tableLayoutPanelDays.Controls.Add(closePicker, column + 2, d + 1);

                    slotChecks[d, s] = check;
                    openPickers[d, s] = openPicker;
                    closePickers[d, s] = closePicker;
                }
            }
        }

        private static DateTimePicker CreateTimePicker(TimeOnly time, bool enabled)
        {
            return new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = TimeFormat,
                ShowUpDown = true,
                Width = 70,
                Value = DateTime.Today.Add(time.ToTimeSpan()),
                Enabled = enabled
            };
        }

        private static TimeOnly ParseTime(string text)
        {
            return TimeOnly.ParseExact(text, TimeFormat, CultureInfo.InvariantCulture);
        }

        private static string FormatTime(DateTimePicker picker)
        {
            return TimeOnly.FromDateTime(picker.Value).ToString(TimeFormat, CultureInfo.InvariantCulture);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            List<OpeningDay> result = new List<OpeningDay>();

            for (int d = 0; d < Week.Length; d++)
            {
                List<TimeSlot> slots = new List<TimeSlot>();
                TimeOnly previousClose = TimeOnly.MinValue;

                for (int s = 0; s < SlotsPerDay; s++)
                {
                    if (!slotChecks[d, s].Checked) continue;

                    TimeOnly open = TimeOnly.FromDateTime(openPickers[d, s].Value);
                    TimeOnly close = TimeOnly.FromDateTime(closePickers[d, s].Value);
                    if (open >= close || open < previousClose)
                    {
                        MessageBox.Show(
                            $"{tableLayoutPanelDays.GetControlFromPosition(0, d + 1)!.Text} : les plages doivent se suivre et chacune commencer avant de finir.",
                            "Horaires", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None; // keep the dialog open
                        return;
                    }
                    previousClose = close;
                    slots.Add(new TimeSlot(FormatTime(openPickers[d, s]), FormatTime(closePickers[d, s])));
                }
                result.Add(new OpeningDay(Week[d], slots));
            }

            OpeningHours = result;
        }
    }
}
