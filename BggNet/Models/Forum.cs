namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a forum from the BGG API.
    /// </summary>
    public class Forum
    {
        public long? Id { get; set; }

        public string Title { get; set; }

        public int? NumThreads { get; set; }

        public DateTime? LastPostDate { get; set; }

        public bool? NoPosting { get; set; }

        /// <summary>
        /// The summary of the threads associated with this Forum.
        /// </summary>
        /// <remarks>
        /// Will not be populated from forums retrieved from ForumList API calls.
        /// </remarks>
        public List<ThreadSummary> Threads { get; set; } = new List<ThreadSummary>();
    }
}
