using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a listing of an item for sale on BGG.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Listing
    {
        /// <summary>
        /// The date the item was listed.
        /// </summary>
        [XmlElement("listdate")]
        public BggString ListDate { get; set; }

        /// <summary>
        /// The cost of the item.
        /// </summary>
        [XmlElement("price")]
        public Price Price { get; set; }

        /// <summary>
        /// The condition of the item.
        /// </summary>
        [XmlElement("condition")]
        public BggString Condition { get; set; }

        /// <summary>
        /// Any additional notes regarding the item.
        /// </summary>
        [XmlElement("notes")]
        public BggString Notes { get; set; }

        /// <summary>
        /// A link to the listing.
        /// </summary>
        [XmlElement("link")]
        public ListingLink Link { get; set; }
    }
}
