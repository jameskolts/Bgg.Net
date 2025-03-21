﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a collection of Videos.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class VideoList
    {
        /// <summary>
        /// The total number of videos across all pages.
        /// </summary>
        [XmlAttribute("total")]
        public int Total { get; set; }

        /// <summary>
        /// The list of videos.
        /// </summary>
        [XmlElement("video")]
        public List<Video> Video { get; set; } = new();
    }
}
