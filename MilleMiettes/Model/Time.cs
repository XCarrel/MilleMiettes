namespace MilleMiettes
{
    /// <summary>
    ///  Payload received on the MQTT time topic, e.g. { "UnixTimeStamp": 1794818021 }
    /// </summary>
    public class Time
    {
        public Time(long unixTimeStamp)
        {
            UnixTimeStamp = unixTimeStamp;
        }

        // Seconds elapsed since 1970-01-01 00:00:00 UTC
        public long UnixTimeStamp { get; private set; }

        // The same instant, expressed in the local time zone
        public DateTime LocalTime => DateTimeOffset.FromUnixTimeSeconds(UnixTimeStamp).LocalDateTime;
    }
}
