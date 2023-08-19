using Bgg.Net.Common.Models.Bgg;
using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    public class LogPlayRequest : LogRequest
    {
        [JsonProperty("objectid")]
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
        public int Length { get; set; }

        [JsonProperty("incomplete")]
        public bool Incomplete { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}
