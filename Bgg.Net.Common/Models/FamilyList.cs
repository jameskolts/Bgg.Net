using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class FamilyList : BggBase
    {
        [XmlElement("item")]
        public List<Family> Families { get; set; } = new List<Family>();
    }
}
