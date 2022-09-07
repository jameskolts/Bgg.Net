namespace Dgi.Api.Models
{
    public class InsightResponse
    {
        /// <summary>
        /// The insight result.
        /// </summary>
        public List<Insight> Insights { get; set; } = new();

        /// <summary>
        /// True if the insight request was processed successfully, otherwise false.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Contains information about any errors that occurred.
        /// </summary>
        public List<string> Errors { get; set; } = new();
    }
}
