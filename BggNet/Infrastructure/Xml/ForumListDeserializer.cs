using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Serilog;
using System.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Deserializes objects of type <seealso cref="ForumList"/>.
    /// </summary>
    public class ForumListDeserializer : DeserializerBase, IForumListDeserializer
    {
        private readonly IForumDeserializer _forumDeserializer;

        /// <summary>
        /// Creates a new instance of <see cref="ForumListDeserializer"/>.
        /// </summary>
        /// <param name="logger">The logging instance.</param>
        public ForumListDeserializer(ILogger logger, IForumDeserializer forumDeserializer) : base(logger)
        {
            _forumDeserializer = forumDeserializer;
        }

        /// <inheritdoc/>
        ForumList IForumListDeserializer.Deserialize(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var document = new XmlDocument();

            document.LoadXml(xml);
            var root = document.DocumentElement;

            var forumList = new ForumList
            {
                Id = root.Attributes["id"]?.Value.ToNullableInt(),
                Type = root.Attributes["type"]?.Value,
                Forums = _forumDeserializer.Deserialize(root.ToString())
            };

            if (!(forumList.Id.HasValue || !string.IsNullOrWhiteSpace(forumList.Type) || forumList.Forums.Any()))
            {
                return null;
            }

            return forumList;

        }
    }
}
