namespace Bgg.Net.Common.Models.Polls.PollResults
{
    /// <summary>
    /// The poll result.
    /// </summary>
    public class PollResult
    {
        /// <summary>
        /// The string value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The number of votes for this value.
        /// </summary>
        public int? NumVotes { get; set; }
    }
}
