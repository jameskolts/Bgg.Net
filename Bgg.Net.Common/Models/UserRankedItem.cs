using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// An item a user may have in their user lists.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class UserRankedItem
    {
        /// <summary>
        /// The rank this item holds.
        /// </summary>
        [XmlAttribute("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// The type of this item.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The id of this item.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of this item.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
