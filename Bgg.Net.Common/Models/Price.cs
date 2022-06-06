using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the price of an item on BGG.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Price
    {
        /// <summary>
        /// The currency denomination used.
        /// </summary>
        [XmlAttribute("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Price value of the item.
        /// </summary>
        [XmlAttribute("value")]
        public decimal Value;
    }
}
