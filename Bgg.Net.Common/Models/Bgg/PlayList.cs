using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a users plays of games from the Bgg XML API2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("plays", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class PlayList : BggBase
    {
        /// <summary>
        /// The username the plays are for.
        /// </summary>
        [XmlAttribute("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The id of the user the plays are for.
        /// </summary>
        [XmlAttribute("userid")]
        public long UserId { get; set; }

        /// <summary>
        /// The total number of plays for this user across all pages.
        /// </summary>
        [XmlAttribute("total")]
        public int Total { get; set; }

        /// <summary>
        /// The page of plays included in this result.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        [XmlElement("play")]
        public List<Play> Play { get; set; }
    }
}
