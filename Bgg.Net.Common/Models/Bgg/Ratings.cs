using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents ratings from board game geek.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("ratings", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Ratings
    {
        /// <summary>
        /// The number of users who've rated.
        /// </summary>
        [XmlElement("usersrated")]
        public BggLong UsersRated { get; set; }

        /// <summary>
        /// The average rating.
        /// </summary>
        [XmlElement("average")]
        public BggDouble Average { get; set; }

        /// <summary>
        /// The bayesaverage rating.
        /// </summary>
        [XmlElement("bayesaverage")]
        public BggDouble BayesAverage { get; set; }

        /// <summary>
        /// A list of ranks.
        /// </summary>
        [XmlArray("ranks")]
        [XmlArrayItem("rank")]
        public List<Rank> Ranks { get; set; } = new();

        /// <summary>
        /// The Standard Deviation of the ratings.
        /// </summary>
        [XmlElement("stddev")]
        public BggDouble StdDeviation { get; set; }

        /// <summary>
        /// The median rating.
        /// </summary>
        [XmlElement("median")]
        public BggDouble Median { get; set; }

        /// <summary>
        /// How many users own the item.
        /// </summary>
        [XmlElement("owned")]
        public BggLong Owned { get; set; }

        /// <summary>
        /// How many users are trading this item.
        /// </summary>
        [XmlElement("trading")]
        public BggLong Trading { get; set; }

        /// <summary>
        /// How many users are wanting this item.
        /// </summary>
        [XmlElement("wanting")]
        public BggLong Wanting { get; set; }

        /// <summary>
        /// How many users are wishing for this item.
        /// </summary>
        [XmlElement("wishing")]
        public BggLong Wishing { get; set; }

        /// <summary>
        /// The number of comments for this item.
        /// </summary>
        [XmlElement("numcomments")]
        public BggLong NumComments { get; set; }

        /// <summary>
        /// The number of weights for this item.
        /// </summary>
        [XmlElement("numweights")]
        public BggLong NumWeights { get; set; }

        /// <summary>
        /// The average weights for this item.
        /// </summary>
        [XmlElement("averageweight")]
        public BggDouble AverageWeights { get; set; }
    }
}
