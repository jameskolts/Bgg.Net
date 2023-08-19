using Bgg.Net.Common.Models.Bgg;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class GuildList
    {
        /// <summary>
        /// The total number of guilds across all pages.
        /// </summary>
        [XmlAttribute("total")]
        public int Total { get; set; }

        /// <summary>
        /// The page of results contained in this GuildList.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        /// <summary>
        /// The list of guilds returned in this page.
        /// </summary>
        [XmlElement("guild")]
        public List<UserItem> Guild { get; set; } = new();
    }
}
