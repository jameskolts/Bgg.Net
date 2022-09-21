using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an article from the BGG API.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class Article
    {
        /// <summary>
        /// The Id of the article.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The username of the poster.
        /// </summary>
        [XmlAttribute("username")]
        public string Username { get; set; }

        /// <summary>
        /// A link to the article.
        /// </summary>
        [XmlAttribute("link")]
        public string Link { get; set; }

        /// <summary>
        /// The date the article was posted.
        /// </summary>
        [XmlAttribute("postdate")]
        public string PostDate { get; set; }

        /// <summary>
        /// The date of the last edit to the article, if any, otherwise 
        /// the same as the post date.
        /// </summary>
        [XmlAttribute("editdate")]
        public string EditDate { get; set; }

        /// <summary>
        /// The number of times the article has been edited.
        /// </summary>
        [XmlAttribute("numedits")]
        public int NumEdits { get; set; }

        /// <summary>
        /// The subject of the article.
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The body of the article. Contains the text of the post.
        /// </summary>
        [XmlElement("body")]
        public string Body { get; set; }
    }
}
