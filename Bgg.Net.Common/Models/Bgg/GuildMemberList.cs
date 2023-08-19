using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a list of guild members in the Bgg XML API2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class GuildMemberList
    {
        /// <summary>
        /// The count of members across all pages.
        /// </summary>
        [XmlAttribute("count")]
        public int Count { get; set; }

        /// <summary>
        /// Which page of members is included in this list.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        [XmlElement("member")]
        public List<GuildMember> Member = new();
    }
}
