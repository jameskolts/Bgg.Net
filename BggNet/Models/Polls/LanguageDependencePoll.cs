using Bgg.Net.Common.Models.Polls.PollResults;

namespace Bgg.Net.Common.Models.Polls
{
    /// <summary>
    /// The language dependence poll.
    /// </summary>
    public class LanguageDependencePoll : Poll
    {
        /// <summary>
        /// The results of the poll.
        /// </summary>
        public List<LanguageResult> Results { get; set; } = new List<LanguageResult>();
    }
}
