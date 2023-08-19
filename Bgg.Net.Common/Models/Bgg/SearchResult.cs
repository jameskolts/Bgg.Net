using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a search result item from the Bgg XML API 2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class SearchResult
    {
        /// <summary>
        /// The id of the item.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The type of the item.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        [XmlElement("name")]
        public BggName Name { get; set; }

        /// <summary>
        /// The year the item was published.
        /// </summary>
        [XmlElement("yearpublished")]
        public BggInteger YearPublished { get; set; }
    }
}
