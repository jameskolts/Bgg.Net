using Bgg.Net.Common.Models;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Deserializes objects of type <seealso cref="Thing"/>.
    /// </summary>
    public class ThingDeserializer : DeserializerBase, IThingDeserializer
    {
        public ThingDeserializer(string rootXpath, ILogger logger)
            : base(rootXpath, logger)
        {
        }

        /// <summary>
        /// Deserializes the given xml.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>A <see cref="Thing"/> object from the deserialized xml.</returns>
        public Thing Deserialize(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var document = new XmlDocument();

            document.LoadXml(xml);
            var root = document.DocumentElement;

            var thing = new Thing
            {
                Type = DeserializeStringAttribute("type", root.SelectSingleNode(_rootXpath)),
                Id = DeserializeIntAttribute("id", root.SelectSingleNode(_rootXpath)),
                YearPublished = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/yearpublished")),
                MinPlayers = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/minplayers")),
                MaxPlayers = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/maxplayers")),
                PlayingTime = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/playingtime")),
                MinPlayTime = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/minplaytime")),
                MaxPlayTime = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/maxplaytime")),
                MinAge = DeserializeIntAttribute("value", root.SelectSingleNode($"{_rootXpath}/minage")),
                Poll = DeserializePolls(root.SelectNodes($"{_rootXpath}/poll")),
                Name = DeserializeBggNames(root.SelectNodes($"{_rootXpath}/name")),
                Thumbnail = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/thumbnail")),
                Image = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/image")),
                Description = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/description")),
                Link = DeserializeLink(root.SelectNodes($"{_rootXpath}/link")),
                Versions = DeserializeVersions(root.SelectSingleNode($"{_rootXpath}/versions")),
                Comments = DeserializeComments(root.SelectSingleNode($"{_rootXpath}/comments")),
                MarketplaceListing = DeserializeMarketplaceListings(root.SelectSingleNode($"{_rootXpath}/marketplacelistings")),
                Videos = DeserializeVideos(root.SelectSingleNode($"{_rootXpath}/videos"))
            };

            //TODO: Add Videos, statistics

            return thing;
        }
    }
}
