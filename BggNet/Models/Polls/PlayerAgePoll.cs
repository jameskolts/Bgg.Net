using Bgg.Net.Common.Models.Polls.PollResults;

namespace Bgg.Net.Common.Models.Polls
{
    /// <summary>
    /// The player age poll.
    /// </summary>
    public class PlayerAgePoll : Poll
    {
        /// <summary>
        /// The results of the poll.
        /// </summary>
        public List<PollResult> Results { get; set; } = new List<PollResult>();
    }
}
