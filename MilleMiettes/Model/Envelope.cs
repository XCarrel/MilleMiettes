using System.Text.Json;
using System.Text.Json.Serialization;

namespace MilleMiettes
{
    /// <summary>
    ///  Envelope wrapping every message exchanged on MQTT (see contracts\envelope.schema.json)
    /// </summary>
    public class Envelope
    {
        public Envelope(int v, Guid id, string from, string to, DateTimeOffset ts, string type, JsonElement payload)
        {
            V = v;
            Id = id;
            From = from;
            To = to;
            Ts = ts;
            Type = type;
            Payload = payload;
        }

        // Version of the envelope format (always 1 for now)
        [JsonPropertyName("v")]
        public int V { get; private set; }

        // Unique id of the message
        [JsonPropertyName("id")]
        public Guid Id { get; private set; }

        // Name of the sending node
        [JsonPropertyName("from")]
        public string From { get; private set; }

        // Name of the receiving node, or * for all
        [JsonPropertyName("to")]
        public string To { get; private set; }

        // When the message was sent (UTC)
        [JsonPropertyName("ts")]
        public DateTimeOffset Ts { get; private set; }

        // Name of the payload's schema: "time" or "log"
        [JsonPropertyName("type")]
        public string Type { get; private set; }

        // Kept as raw JSON: its shape depends on Type, deserialize it afterwards (e.g. Payload.Deserialize<Time>())
        [JsonPropertyName("payload")]
        public JsonElement Payload { get; private set; }
    }
}
