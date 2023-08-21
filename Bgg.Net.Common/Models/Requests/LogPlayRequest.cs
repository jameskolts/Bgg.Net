using Bgg.Net.Common.Infrastructure.Attributes;
using Bgg.Net.Common.Models.Bgg;
using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    public class LogPlayRequest : LogRequest
    {
        [JsonProperty("objectid")]
        [RequireNonDefault(ErrorMessage = "ObjectId was not set.")]
        public long ObjectId { get; set; }

        [JsonProperty("playdate")]
        public DateTime PlayDate { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Duration in minutes.
        /// </summary>
        [JsonProperty("length")]
        public int? Length { get; set; }

        [JsonProperty("incomplete")]
        public bool? Incomplete { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; } = new();

        public LogPlayRequest()
        {
            ObjectType = "thing";
            Action = "save";
            Ajax = 1;
        }

        public LogPlayRequest(long objectId)
        {
            ObjectId = objectId;
            ObjectType = "thing";
            Action = "save";
            Ajax = 1;
        }
    }
}
