using Bgg.Net.Common.Models.Links;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a listing of an item for sale on BGG.
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// The date the item was listed.
        /// </summary>
        public DateTime? ListDate { get; set; }

        /// <summary>
        /// The cost of the item.
        /// </summary>
        public Price Price { get; set; }

        /// <summary>
        /// The condition of the item.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Any additional notes regarding the item.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// A link to the listing.
        /// </summary>
        public ListingLink Link { get; set; }
    }
}
