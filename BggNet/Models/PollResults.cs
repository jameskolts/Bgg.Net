namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// The PollResults
    /// </summary>
    public class PollResults
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
