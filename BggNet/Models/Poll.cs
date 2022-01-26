namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a Poll from BGG.
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// The Name of the poll.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The title of the poll.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The total Number of votes for this poll.
        /// </summary>
        public int? TotalVotes { get; set; }

        /// <summary>
        /// The list of poll results.
        /// </summary>
        public List<PollResults> Results { get; set; } = new List<PollResults>();
    }
}
