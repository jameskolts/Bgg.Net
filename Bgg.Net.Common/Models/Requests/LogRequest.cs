using Bgg.Net.Common.Infrastructure.Attributes;
using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Base Class for Logging Requests.
    /// </summary>
    public abstract class LogRequest
    {
        [JsonProperty("ajax")]
        [RequireNonDefault(ErrorMessage = "Ajax was not set.")]
        public int Ajax { get; set; }

        [JsonProperty("objecttype")]
        public string ObjectType { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
