namespace MilleMiettes
{
    public class UMDDTime
    {
        public UMDDTime(long unixTimeStamp)
        {
            UnixTimeStamp = unixTimeStamp;
        }

        // Seconds elapsed since 1970-01-01 00:00:00 UTC
        public long UnixTimeStamp { get; private set; }

        // The same instant, expressed in the local time zone
        public DateTime LocalTime => DateTimeOffset.FromUnixTimeSeconds(UnixTimeStamp).LocalDateTime;
    }
}
