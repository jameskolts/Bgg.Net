using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// A link to a related item.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("link", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Link
    {
        /// <summary>
        /// The type of the link.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The id of the linked item.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
