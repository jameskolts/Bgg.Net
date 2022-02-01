namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the comments of an item.
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// Which page of comments represented.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The total number of comments across all pages.
        /// </summary>
        public int? TotalItems { get; set; }

        /// <summary>
        /// The comments included in this page.
        /// </summary>
        public List<Comment> Comment { get; set; }
    }
}
