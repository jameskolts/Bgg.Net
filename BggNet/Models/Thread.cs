namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents thread details as represented in the BGG API.
    /// </summary>
    /// <remarks>
    /// Retrieved from Thread API calls.
    /// </remarks>
    public class Thread
    {
        public long? Id { get; set; }

        public string Subject { get; set; }

        public int? NumArticles { get; set; }

        public string Link { get; set; }        

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
