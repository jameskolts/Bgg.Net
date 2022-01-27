using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Polls;
using System.Collections.Generic;
using System.Xml;

namespace Bgg.Net.Common.Tests.TestWrappers
{
    public class DeserializerBaseTestWrapper : DeserializerBase
    {
        public DeserializerBaseTestWrapper(string rootpath) : base(rootpath) { }

        public List<Link> DeseralizeLink(XmlNodeList nodeList)
        {
            return base.DeserializeLink(nodeList);
        }

        public new List<Poll> DeserializePolls(XmlNodeList nodeList)
        {
            return base.DeserializePolls(nodeList);
        }
    }
}
