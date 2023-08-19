using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a thread from the BGG XmlAPI2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("thread", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class Thread : BggBase
    {
        /// <summary>
        /// The id of the thread.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The number of articles in the thread.
        /// </summary>
        [XmlAttribute("numarticles")]
        public int NumArticles { get; set; }

        /// <summary>
        /// The url of the thread.
        /// </summary>
        [XmlAttribute("link")]
        public string Link { get; set; }

        /// <summary>
        /// The subject/topic of the thread.
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The Articles of this thread.
        /// </summary>
        [XmlArray("articles")]
        [XmlArrayItem("article")]
        public List<Article> Articles { get; set; } = new();


    }
}
