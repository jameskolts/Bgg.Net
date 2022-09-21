using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class PollResultList
    {
        /// <summary>
        /// The number of players the results are for
        /// </summary>
        /// <remarks>
        /// Null unless the <see cref="Poll"/> containing this object is a suggested_numplayers poll.
        /// </remarks>
        [XmlAttribute("numplayers")]
        public string NumPlayers { get; set; }

        /// <summary>
        /// The detailed results of this poll.
        /// </summary>
        [XmlElement("result")]
        public List<PollResult> Result { get; set; } = new List<PollResult>();
    }
}
