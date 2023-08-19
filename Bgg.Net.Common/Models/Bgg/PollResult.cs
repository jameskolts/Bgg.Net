using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// The poll result.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("result", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class PollResult
    {
        /// <summary>
        /// The string value.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        /// The number of votes for this value.
        /// </summary>
        [XmlAttribute("numvotes")]
        public long NumVotes { get; set; }

        /// <summary>
        /// The level of proficency required.
        /// </summary>
        /// <remarks>
        /// Only used for language dependence polls.
        /// </remarks>
        [XmlAttribute("level")]
        public string Level { get; set; }
    }
}