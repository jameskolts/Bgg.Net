using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a ranking from board game geek.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Rank
    {
        /// <summary>
        /// The type of the ranking.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The id of the ranking.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the ranking.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The friendly name of the ranking.
        /// </summary>
        [XmlAttribute("friendlyname")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The value of the ranking.
        /// </summary>
        [XmlAttribute("value")]
        public long Value { get; set; }

        /// <summary>
        /// The BayesAverage of the ranking.
        /// </summary>
        [XmlAttribute("bayesaverage")]
        public double BayesAverage { get; set; }
    }
}
