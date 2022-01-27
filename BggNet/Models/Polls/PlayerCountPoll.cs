using Bgg.Net.Common.Models.Polls.PollResults;

namespace Bgg.Net.Common.Models.Polls
{
    /// <summary>
    /// The playercount poll.
    /// </summary>
    public class PlayerCountPoll : Poll
    {
        /// <summary>
        /// The results of the poll.
        /// </summary>
        public List<PlayerCountResult> Results { get; set; } = new List<PlayerCountResult>();
    }
}
