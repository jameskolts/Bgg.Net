using Bgg.Net.Common.Models.Bgg;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the comments of an item.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class CommentList
    {
        /// <summary>
        /// Which page of comments represented.
        /// </summary>
        [XmlAttribute("page")]
        public int Page { get; set; }

        /// <summary>
        /// The total number of comments across all pages.
        /// </summary>
        [XmlAttribute("totalitems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// The comments included in this page.
        /// </summary>
        [XmlElement("comment")]
        public List<Comment> Comment { get; set; } = new();
    }
}
