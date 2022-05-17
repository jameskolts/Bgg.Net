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
        [XmlElement("forum")]
        public Forum[] Forums { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("termsofuse")]
        public string TermsOfUse { get; set; }
    }
}
