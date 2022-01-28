namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents Statistics from board game geek.
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// The number of pages.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The user ratings.
        /// </summary>
        public Ratings Ratings { get; set; }
    }
}
