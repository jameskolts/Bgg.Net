namespace Bgg.Net.Common.Models.Polls
{
    /// <summary>
    /// The base type for Poll objects.
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// The name of the poll.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The title of the poll.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Total number of votes in this poll.
        /// </summary>
        public int? TotalVotes { get; set; }
    }
}
