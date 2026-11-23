using System.Text.Json.Serialization;

namespace MilleMiettes
{
    /// <summary>
    ///  Payload sent to the log service (see contracts\log.schema.json)
    /// </summary>
    public class Log
    {
        public Log(string level, string text)
        {
            Level = level;
            Text = text;
        }

        // "info", "warn" or "error"
        [JsonPropertyName("level")]
        public string Level { get; private set; }

        // Message to archive, never empty
        [JsonPropertyName("text")]
        public string Text { get; private set; }
    }
}
