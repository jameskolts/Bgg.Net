using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a ForumList from the BGG API
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("forums", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public partial class ForumList : BggBase
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlElement("forum")]
        public List<Forum> Forums { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

    }
}
