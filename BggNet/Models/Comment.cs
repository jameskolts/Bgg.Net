﻿using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a user comment.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Comment
    {
        /// <summary>
        /// The user making the comment.
        /// </summary>
        [XmlAttribute("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The rating of the comment.
        /// </summary>
        [XmlAttribute("rating")]
        public string Rating { get; set; }

        /// <summary>
        /// The value of the comment.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
