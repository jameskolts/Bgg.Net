using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an item in a collection from the BGG XML API2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("item", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class CollectionItem
    {
        /// <summary>
        /// The id of the item.
        /// </summary>
        [XmlAttribute("objectid")]
        public long Id { get; set; }

        /// <summary>
        /// The type of the item.
        /// </summary>
        [XmlAttribute("objecttype")]
        public string Type { get; set; }

        /// <summary>
        /// The subtype of the item.
        /// </summary>
        [XmlAttribute("subtype")]
        public string SubType { get; set; }

        /// <summary>
        /// The collid of an item.  Used to restrict collection results.
        /// </summary>
        [XmlAttribute("collid")]
        public long CollId { get; set; }

        /// <summary>
        /// The name of the Item
        /// </summary>
        /// TODO: Ignoring SortIndex attribute of this element.  Does it matter?
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The year the item was published.
        /// </summary>
        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }

        /// <summary>
        /// The url of the image for this item.
        /// </summary>
        [XmlElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// The url of the thumbnail for this item.
        /// </summary>
        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// The status of this item.
        /// </summary>
        [XmlElement("status")]
        public CollectionItemStatus Status { get; set; }

        /// <summary>
        /// The number of times this item has been played.
        /// </summary>
        [XmlElement("numplays")]
        public int NumPlays { get; set; }
    }
}
