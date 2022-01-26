namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// A link to a related item.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// The type of the link.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The id of the linked item.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        public string Value { get; set; }
    }
}
