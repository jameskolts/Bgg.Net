using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class SearchResultList : BggBase
    {
        /// <summary>
        /// The total number of search results.
        /// </summary>
        [XmlAttribute("total")]
        public int Total { get; set; }

        [XmlElement("item")]
        public List<SearchResult> Item { get; set; } = new();
    }
}
