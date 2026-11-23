using System.Text.Json.Serialization;

namespace MilleMiettes
{
    /// <summary>
    ///  Opening hours of one day of the week. A day without slots is closed.
    /// </summary>
    public class OpeningDay
    {
        public OpeningDay(DayOfWeek day, List<TimeSlot> slots)
        {
            Day = day;
            Slots = slots;
        }

        // Stored as "Monday", "Tuesday", ... rather than 1, 2, ...
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DayOfWeek Day { get; private set; }
        public List<TimeSlot> Slots { get; set; }
    }

    /// <summary>
    ///  A period during which the shop is open. Times are stored as "HH:mm" text.
    /// </summary>
    public class TimeSlot
    {
        public TimeSlot(string open, string close)
        {
            Open = open;
            Close = close;
        }

        public string Open { get; private set; }
        public string Close { get; private set; }
    }
}
