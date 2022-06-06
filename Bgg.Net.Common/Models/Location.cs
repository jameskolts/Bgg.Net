using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a location in the BGG Xml API2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Location
    {
        /// <summary>
        /// The first portion of the address.
        /// </summary>
        [XmlElement("addr1")]
        public string Address1 { get; set; }

        /// <summary>
        /// The second portion of the address.
        /// </summary>
        [XmlElement("addr2")]
        public string Address2 { get; set; }

        /// <summary>
        /// The city of the address..
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// The state or province of the address.
        /// </summary>
        [XmlElement("stateorprovince")]
        public string StateOrProvince { get; set; }

        /// <summary>
        /// The postal or zip code for the address.
        /// </summary>
        [XmlElement("postalcode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country for the address.
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }
    }
}
