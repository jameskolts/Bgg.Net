namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a ForumList from the BGG API.
    /// </summary>
    public class ForumList
    {
        public int? Id { get; set; }

        public string Type { get; set; }

        public List<Forum> Forums { get; set; } = new List<Forum>();
    }
}
