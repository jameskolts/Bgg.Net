using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Versions;
using Bgg.Net.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Version = Bgg.Net.Common.Models.Versions.Version;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Deserializes objects of type <seealso cref="Thing"/>.
    /// </summary>
    public class ThingDeserializer : DeserializerBase, IBggDeserializer
    {
        public ThingDeserializer(string rootXpath)
            : base(rootXpath)
        {
        }

        /// <inheritdoc/>
        public BggBase Deserialize(string xml)
        {
            var thing = new Thing();

            var document = new XmlDocument();
            document.LoadXml(xml);

            var root = document.DocumentElement;
            var nodes = root.SelectNodes(_rootXpath);

            SetItemAttributes(nodes[0].Attributes, thing);
            SetStringProperty(thing, "thumbnail", root);
            SetStringProperty(thing, "image", root);
            SetStringProperty(thing, "description", root);
            SetIntAttribute(thing, "yearPublished", root);
            SetIntAttribute(thing, "minPlayers", root);
            SetIntAttribute(thing, "maxPlayers", root);
            SetIntAttribute(thing, "playingTime", root);
            SetIntAttribute(thing, "minPlayTime", root);
            SetIntAttribute(thing, "maxPlayTime", root);
            SetIntAttribute(thing, "minAge", root);
            thing.Name = DeserializeBggNames(root);
            SetPoll(thing, root);
            thing.Link = DeserializeLink(root);
            thing.Versions = DeserializeVersions(root);
            thing.Comments = DeserializeComments(root.SelectSingleNode($"{_rootXpath}/comments"));
            thing.MarketplaceListing = DeserializeMarketplaceListings(root.SelectSingleNode($"{_rootXpath}/marketplacelistings"));

            return thing;
        }

        /// <summary>
        /// Sets the Poll property of a thing.
        /// </summary>
        /// <param name="thing">The thing to set the properties of.</param>
        /// <param name="root">The root xmlelement.</param>
        private void SetPoll(Thing thing, XmlElement root)
        {
            var nodes = root.SelectNodes($"{_rootXpath}/poll");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    var poll = new Poll
                    {
                        Name = node.Attributes.GetNamedItem("name")?.Value,
                        Title = node.Attributes.GetNamedItem("title")?.Value,
                        TotalVotes = node.Attributes.GetNamedItem("totalvotes")?.Value.ToNullableInt()
                    };

                    foreach (XmlNode resultList in node.ChildNodes)
                    {
                        var pollResults = new PollResults
                        {
                            NumPlayers = resultList.Attributes?.GetNamedItem("numplayers")?.Value.ToNullableInt(),
                        };

                        foreach (XmlNode individualResult in resultList.ChildNodes)
                        {
                            var pollResult = new PollResult
                            {
                                Value = individualResult.Attributes?.GetNamedItem("value")?.Value,
                                NumVotes = individualResult.Attributes?.GetNamedItem("numvotes")?.Value.ToNullableInt()
                            };

                            pollResults.Results.Add(pollResult);
                        }

                        poll.Results.Add(pollResults);
                    }

                    thing.Poll.Add(poll);
                }
            }
        }       

        private void SetItemAttributes(XmlAttributeCollection attributeCollection, Thing thing)
        {
            foreach (XmlAttribute attribute in attributeCollection)
            {
                switch (attribute.Name)
                {
                    case "type":
                        thing.Type = attribute.Value;
                        break;
                    case "id":
                        thing.Id = int.Parse(attribute.Value);
                        break;
                    default:
                        throw new InvalidOperationException($"Cannot set attribute of {attribute.Name}");
                }
            }
        }
    }
}
