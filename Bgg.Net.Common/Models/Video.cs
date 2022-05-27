using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents an individual video.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Video
    {
        /// <summary>
        /// The Id of the video.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The Title of the video.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// The category of the video.
        /// </summary>
        [XmlAttribute("category")]
        public string Category { get; set; }

        /// <summary>
        /// The language of the video.
        /// </summary>
        [XmlAttribute("language")]
        public string Language { get; set; }

        /// <summary>
        /// The link to the video.
        /// </summary>
        [XmlAttribute("link")]
        public string Link { get; set; }

        /// <summary>
        /// The username of the poster.
        /// </summary>
        [XmlAttribute("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The userid of the poster.
        /// </summary>
        [XmlAttribute("userid")]
        public long UserId { get; set; }

        /// <summary>
        /// The datetime the video was posted.
        /// </summary>
        [XmlAttribute("postdate")]
        public string PostDate { get; set; }
    }
}
