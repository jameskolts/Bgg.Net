namespace Bgg.Net.Common.Models.Polls.PollResults
{
    /// <summary>
    /// A Language poll result.
    /// </summary>
    public class LanguageResult : PollResult
    {
        /// <summary>
        /// The level of proficincy needed in the language.
        /// </summary>
        public int? Level { get; set; }
    }
}
