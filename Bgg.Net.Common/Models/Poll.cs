using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a poll from board game geek.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("poll", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Poll
    {
        /// <summary>
        /// The name of the poll.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The title of the poll.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// The Total number of votes in this poll.
        /// </summary>
        [XmlAttribute("totalvotes")]
        public long TotalVotes { get; set; }

        /// <summary>
        /// The results of this poll.
        /// </summary>
        [XmlElement("results")]
        public List<PollResultList> Results { get; set; } = new();
    }
}
