using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents Statistics from board game geek.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Statistics
    {
        /// <summary>
        /// The number of pages.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        /// <summary>
        /// The user ratings.
        /// </summary>
        [XmlElement("ratings")]
        public Ratings Ratings { get; set; }
    }
}
