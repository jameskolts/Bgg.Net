using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a list of buddies in the BGG XML API 2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class BuddyList
    {
        /// <summary>
        /// The total number of buddies across all pages.
        /// </summary>
        [XmlAttribute("total")]
        public int Total { get; set; }

        /// <summary>
        /// The page of buddies in this result.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        /// <summary>
        /// The list of buddy results for this page.
        /// </summary>
        [XmlElement("buddy")]
        public List<UserItem> Buddy { get; set; } = new List<UserItem>();
    }
}
