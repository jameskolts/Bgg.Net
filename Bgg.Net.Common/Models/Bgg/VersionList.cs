using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("versions", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class VersionList
    {
        [XmlElement("item")]
        public List<Version> Versions { get; set; } = new();
    }
}
