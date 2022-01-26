namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the comments of an item.
    /// </summary>
    public class Comments
    {
        public int? Page { get; set; }

        public int? TotalItems { get; set; }

        public List<Comment> Comment { get; set; }
    }
}
