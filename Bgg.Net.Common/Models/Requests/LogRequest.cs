using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Base Class for Logging Requests.
    /// </summary>
    public abstract class LogRequest
    {
        [JsonProperty("ajax")]
        public int Ajax { get; set; }

        [JsonProperty("objecttype")]
        public string ObjectType { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
