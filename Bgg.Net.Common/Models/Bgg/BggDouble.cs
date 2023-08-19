using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class BggDouble
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
    }
}