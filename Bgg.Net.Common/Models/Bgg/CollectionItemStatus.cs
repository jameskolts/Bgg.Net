using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents the status of a collection item from the BGG Xml API2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("status", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class CollectionItemStatus
    {
        /// <summary>
        /// Is the item owned in this collection.
        /// </summary>
        [XmlAttribute("own")]
        public bool Own { get; set; }

        /// <summary>
        /// Was the item previously owned in this collection.
        /// </summary>
        [XmlAttribute("prevowned")]
        public bool PreviouslyOwned { get; set; }

        /// <summary>
        /// Is the item currently for trade in this collection.
        /// </summary>
        [XmlAttribute("fortrade")]
        public bool ForTrade { get; set; }

        /// <summary>
        /// Is the item wanted for this collection.
        /// </summary>
        [XmlAttribute("want")]
        public bool Want { get; set; }

        /// <summary>
        /// Is the item wanted to be played.
        /// </summary>
        [XmlAttribute("wanttoplay")]
        public bool WantToPlay { get; set; }

        /// <summary>
        /// Is the item wanted to be purchased.
        /// </summary>
        [XmlAttribute("wanttobuy")]
        public bool WantToBuy { get; set; }

        /// <summary>
        /// Is the item on a wishlist.
        /// </summary>
        [XmlAttribute("wishlist")]
        public bool WishList { get; set; }

        /// <summary>
        /// Is the item preordered.
        /// </summary>
        [XmlAttribute("preordered")]
        public bool PreOrdered { get; set; }

        /// <summary>
        /// When was the status of this item last changed.
        /// </summary>
        [XmlAttribute("lastmodified")]
        public string LastModified { get; set; }
    }
}
