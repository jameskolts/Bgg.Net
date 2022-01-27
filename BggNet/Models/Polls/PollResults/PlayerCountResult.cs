namespace Bgg.Net.Common.Models.Polls.PollResults
{
    /// <summary>
    /// The player count poll result.
    /// </summary>
    public class PlayerCountResult
    {
        /// <summary>
        /// The number of players.
        /// </summary>
        public int? NumPlayers { get; set; }

        /// <summary>
        /// The poll results.
        /// </summary>
        public List<PollResult> Results { get; set; } = new List<PollResult>();
    }
}
