namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a user comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The user making the comment.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The rating of the comment.
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// The value of the comment.
        /// </summary>
        public string Value { get; set; }
    }
}
