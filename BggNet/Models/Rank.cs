namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a ranking from board game geek.
    /// </summary>
    public class Rank
    {
        /// <summary>
        /// The type of the ranking.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The id of the ranking.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// The name of the ranking.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The friendly name of the ranking.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The value of the ranking.
        /// </summary>
        public long? Value { get; set; }

        /// <summary>
        /// The BayesAverage of the ranking.
        /// </summary>
        public double? BayesAverage { get; set; }
    }
}
