using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("item", AnonymousType = true)]
    public partial class Family
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("name")]
        public BggName Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("link")]
        public List<FamilyLink> Links { get; set; } = new List<FamilyLink>();

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}