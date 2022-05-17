using Bgg.Net.Common.Models.Links;
using System.Xml;
using System;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    public partial class FamilyList : BggBase
    {
        [XmlElement("item")]
        public List<Family> Families { get; set; }
    }

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
