using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class UserItem
    {
        /// <summary>
        /// The Id of the guild.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the guild.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
