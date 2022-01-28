using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Polls;
using Bgg.Net.Common.Models.Versions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Xml;

namespace Bgg.Net.Common.Tests.TestWrappers
{
    public class DeserializerBaseTestWrapper : DeserializerBase
    {
        public DeserializerBaseTestWrapper(string rootpath, ILogger logger) : base(rootpath, logger) { }

        public new List<Link> DeserializeLink(XmlNodeList nodeList)
        {
            return base.DeserializeLink(nodeList);
        }

        public new List<Poll> DeserializePolls(XmlNodeList nodeList)
        {
            return base.DeserializePolls(nodeList);
        }

        public new string DeserializeStringInnerText(XmlNode node)
        {
            return base.DeserializeStringInnerText(node);
        }

        public new string DeserializeStringAttribute(string propertyName, XmlNode node)
        {
            return base.DeserializeStringAttribute(propertyName, node);
        }

        public new int? DeserializeIntAttribute(string propertyName, XmlNode node)
        {
            return base.DeserializeIntAttribute(propertyName, node);
        }

        public new List<BggName> DeserializeBggNames(XmlNodeList nodes)
        {
            return base.DeserializeBggNames(nodes);
        }

        public new List<Version> DeserializeVersions(XmlNode node)
        {
            return base.DeserializeVersions(node);
        }

        public new Comments DeserializeComments(XmlNode node)
        {
            return base.DeserializeComments(node);
        }

        public new List<Listing> DeserializeMarketplaceListings(XmlNode node)
        {
            return base.DeserializeMarketplaceListings(node);
        }

        public new Videos DeserializeVideos(XmlNode node)
        {
            return base.DeserializeVideos(node);
        }

        public new Statistics DeserializeStatistics(XmlNode node)
        {
            return base.DeserializeStatistics(node);
        }
    }
}
