namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents ratings from board game geek.
    /// </summary>
    public class Ratings
    {
        /// <summary>
        /// The number of users who've rated.
        /// </summary>
        public long? UsersRated { get; set; }

        /// <summary>
        /// The average rating.
        /// </summary>
        public double? Average { get; set; }

        /// <summary>
        /// The bayesaverage rating.
        /// </summary>
        public double? BayesAverage { get; set; }

        /// <summary>
        /// A list of ranks.
        /// </summary>
        public List<Rank> Ranks { get; set; } = new List<Rank>();

        /// <summary>
        /// The Standard Deviation of the ratings.
        /// </summary>
        public double? StdDeviation { get; set; }

        /// <summary>
        /// The median rating.
        /// </summary>
        public double? Median { get; set; }

        /// <summary>
        /// How many users own the item.
        /// </summary>
        public long? Owned { get; set; }

        /// <summary>
        /// How many users are trading this item.
        /// </summary>
        public long? Trading { get; set; }

        /// <summary>
        /// How many users are wanting this item.
        /// </summary>
        public long? Wanting { get; set; }

        /// <summary>
        /// How many users are wishing for this item.
        /// </summary>
        public long? Wishing { get; set; }

        /// <summary>
        /// The number of comments for this item.
        /// </summary>
        public long? NumComments { get; set; }

        /// <summary>
        /// The number of weights for this item.
        /// </summary>
        public long? NumWeights { get; set; }

        /// <summary>
        /// The average weights for this item.
        /// </summary>
        public double? AverageWeights { get; set; }
    }
}
