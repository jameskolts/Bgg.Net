namespace Bgg.Net.Common.Models.Links
{
    /// <summary>
    /// Represents a link to a listing in BGG.
    /// </summary>
    public class ListingLink
    {
        /// <summary>
        /// The web url of the link.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The link title.
        /// </summary>
        public string Title { get; set; }
    }
}
