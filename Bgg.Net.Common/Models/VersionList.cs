using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using Version = Bgg.Net.Common.Models.Version;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("versions", AnonymousType = true)]
    public class VersionList
    {      
        [XmlElement("item")]
        public List<Version> Versions { get; set; }
    }
}
