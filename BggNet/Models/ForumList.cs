namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a ForumList from the BGG API.
    /// </summary>
    public class ForumList : BggBase
    {
        /// <summary>
        /// The Id.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The List of Forums.
        /// </summary>
        public List<Forum> Forums { get; set; } = new List<Forum>();
    }
}
