namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a collection of Videos.
    /// </summary>
    public class Videos
    {
        /// <summary>
        /// The total number of videos across all pages.
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// The list of videos.
        /// </summary>
        public List<Video> Video { get; set; } = new List<Video>();
    }
}
