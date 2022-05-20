using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// The base type for Poll objects.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("poll", AnonymousType = true)]
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
        [XmlArray("results")]
        [XmlArrayItem("result")]
        //TODO: Doesn't work for suggested playerage poll because of age attribute.  Losing age attribute title, language is loos level.
        public List<PollResult> Results { get; set; } = new List<PollResult>();
    }
}
