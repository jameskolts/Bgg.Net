using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// The base class for versions represents in BGG.
    /// </summary>
    /// //TODO: NOT SERIALIZINGpos
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Version
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("releasedate")]
        public string ReleaseDate { get; set; }

        [XmlElement("link")]
        public List<Link> Links { get; set; } = new();

        [XmlElement("name")]
        public List<BggName> Name { get; set; }

        [XmlElement("yearpublished")]
        public BggInteger YearPublished { get; set; }

        [XmlElement("productcode")]
        public BggString ProductCode { get; set; }

        [XmlElement("width")]
        public BggDouble Width { get; set; }

        [XmlElement("length")]
        public BggDouble Length { get; set; }

        [XmlElement("depth")]
        public BggDouble Depth { get; set; }

        [XmlElement("weight")]
        public BggDouble Weight { get; set; }
    }
}
