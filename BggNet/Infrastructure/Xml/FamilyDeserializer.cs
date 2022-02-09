using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models.Links;
using Serilog;
using System.Xml;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Deserializes objects of type <seealso cref="Family"/>.
    /// </summary>
    public class FamilyDeserializer : DeserializerBase, IFamilyDeserializer
    {
        /// <summary>
        /// Creates a new instance of <see cref="FamilyDeserializer"/>.
        /// </summary>
        /// <param name="logger">The logging instance.</param>
        public FamilyDeserializer(ILogger logger) : base(logger)
        {
        }

        /// <inheritdoc/>
        public List<Family> Deserialize(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var families = new List<Family>();
            var document = new XmlDocument();

            document.LoadXml(xml);
            var root = document.DocumentElement;

            foreach (XmlNode itemNode in root.ChildNodes)
            {
                var item = DeserializeFamily(itemNode);

                if (item != null)
                {
                    families.Add(item);
                }
            }

            return families.Any() ? families : null;
        }

        private Family DeserializeFamily(XmlNode familyNode)
        {
            if (familyNode == null)
            {
                return null;
            }

            var family = new Family
            {
                Type = DeserializeStringAttribute("type", familyNode),
                Id = DeserializeIntAttribute("id", familyNode),
                Thumbnail = DeserializeStringInnerText(familyNode.SelectSingleNode("thumbnail")),
                Image = DeserializeStringInnerText(familyNode.SelectSingleNode("image")),
                Name = DeserializeBggNames(familyNode.SelectNodes("name")),
                Description = DeserializeStringInnerText(familyNode.SelectSingleNode("description")),
                Link = DeserializeFamilyLink(familyNode.SelectNodes("link"))
            };

            if (family != null &&
                    (!string.IsNullOrWhiteSpace(family.Type) || family.Id.HasValue || family.Name.Any() || 
                    !string.IsNullOrWhiteSpace(family.Thumbnail) || !string.IsNullOrWhiteSpace(family.Image) ||
                    !string.IsNullOrWhiteSpace(family.Description) || family.Link.Any()))
            {
                return family;
            }

            return null;
        }

        private List<FamilyLink> DeserializeFamilyLink(XmlNodeList nodeList)
        {
            List<FamilyLink> familyLinks = new List<FamilyLink>();

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    var link = new FamilyLink
                    {
                        Id = node.Attributes.GetNamedItem("id")?.Value.ToNullableInt(),
                        Type = node.Attributes.GetNamedItem("type")?.Value,
                        Value = node.Attributes.GetNamedItem("value")?.Value,
                        Inbound = node.Attributes.GetNamedItem("inbound")?.Value.ToNullableBool()
                    };

                    if (link.Id.HasValue || !string.IsNullOrWhiteSpace(link.Type) || !string.IsNullOrWhiteSpace(link.Value) || link.Inbound.HasValue)
                    {
                        familyLinks.Add(link);
                    }
                }
            }

            return familyLinks.Any() ? familyLinks : null;
        }
    }
}
