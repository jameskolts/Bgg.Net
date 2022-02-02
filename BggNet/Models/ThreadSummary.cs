namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a forum thread summary from the BGG API.
    /// </summary>
    /// <remarks>
    /// Typically retrieved from forum API calls.
    /// </remarks>
    public class ThreadSummary
    {
        public long? Id { get; set; }

        public string Subject { get; set; }

        public int? NumArticles { get; set; }

        public string Author { get; set; }

        public DateTimeOffset? PostDate { get; set; }
    }
}
