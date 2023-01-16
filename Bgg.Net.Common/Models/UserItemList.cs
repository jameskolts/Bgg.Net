using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// The list of a users top of an item.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class UserItemList
    {
        /// <summary>
        /// The domain of this list, eg: boardgame, rpg, videogame.
        /// </summary>
        [XmlAttribute("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// The items that are top.
        /// </summary>
        [XmlElement("item")]
        public List<UserRankedItem> Item { get; set; } = new();
    }
}
