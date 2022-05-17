using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Serilog;
using System.Xml;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public class ForumDeserializer : DeserializerBase, IForumDeserializer
    {
        private readonly IThreadDeserializer _threadDeserializer;

        public ForumDeserializer(ILogger logger, IThreadDeserializer threadDeserializer) : base(logger)
        { 
            _threadDeserializer = threadDeserializer;
        }

        public List<Forum> Deserialize(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var root = GetRoot(xml);
            var forums = new List<Forum>();

            foreach (XmlNode forumNode in root.ChildNodes)
            {
                if(forumNode.Name != "forum")
                {
                    var errorMessage = $"Node '{forumNode}' cannot be deserialized into a forum.";
                    _logger.Error(errorMessage);
                    throw new XmlException(errorMessage);
                }

                var forum = DeserializeForum(forumNode.ToString());

                if (forum != null)
                {
                    forums.Add(forum);
                }
            }

            return forums.Any() ? forums : null;
        }

        public Forum DeserializeForum(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var root = GetRoot(xml);
            var forumNode = root.SelectSingleNode("forum");

            var forum = new Forum
            {
                //Id = DeserializeIntAttribute("id", forumNode),
                //Title = DeserializeStringAttribute("title", forumNode),
                //NoPosting = forumNode.Attributes["nopositing"]?.Value.ToNullableBool(),
                ////Description = DeserializeStringAttribute("description", forumNode),
                //NumThreads = DeserializeIntAttribute("numthreads", forumNode),
                //NumPosts = DeserializeIntAttribute("numposts", forumNode),
                //LastPostDate = DeserializeDtoAttribute("lastpostdate", forumNode),
                ////Threads = _threadDeserializer.DeserializeThreadSummaries(root.ToString())
            };

            return forum;
        }
    }
}
