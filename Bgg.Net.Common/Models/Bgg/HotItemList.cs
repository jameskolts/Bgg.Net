using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a list of hot Items from the BGG XML API2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class HotItemList : BggBase
    {
        /// <summary>
        /// The Hot Items.
        /// </summary>
        [XmlElement("item")]
        public List<HotItem> Item { get; set; } = new();
    }
}
