using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a collection from the BGG Xml API2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class Collection : BggBase
    {
        /// <summary>
        /// The total items in the collection.
        /// </summary>
        [XmlAttribute("totalitems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// The datetime this collection document was published.
        /// </summary>
        [XmlAttribute("pubdate")]
        public string PubDate { get; set; }

        [XmlElement("item")]
        public List<CollectionItem> Items { get; set; }
    }
}
