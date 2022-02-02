namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an article from the BGG API.
    /// </summary>
    public class Article
    {
        public long? Id { get; set; }

        public string UserName { get; set; }

        public string Link { get; set; }

        public DateTimeOffset? PostDate { get; set; }

        public DateTimeOffset? EditDate { get; set; }

        public int? NumEdits { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
