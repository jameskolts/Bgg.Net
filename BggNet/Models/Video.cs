namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an individual video.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// The Id of the video.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The Title of the video.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The category of the video.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The language of the video.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The link to the video.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// The username of the poster.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The userid of the poster.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// The datetime the video was posted.
        /// </summary>
        public DateTimeOffset? PostDate { get; set; }
    }
}
