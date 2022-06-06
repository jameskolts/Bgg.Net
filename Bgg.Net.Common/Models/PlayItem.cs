using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an item that was played in the BGG XML Api2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class PlayItem
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// What type is this item.
        /// </summary>
        [XmlAttribute("objecttype")]
        public string ObjectType { get; set; }

        /// <summary>
        /// The id of this item.
        /// </summary>
        [XmlAttribute("objectid")]
        public long Id { get; set; }

        [XmlArray("subtypes")]
        [XmlArrayItem("subtype")]
        public List<BggString> SubTypes { get; set; }
    }
}
