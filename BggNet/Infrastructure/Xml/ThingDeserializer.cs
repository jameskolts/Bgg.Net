using Bgg.Net.Common.Models;
using System.Xml;

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

        /// <summary>
        /// Deserializes the given xml.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>A <see cref="Thing"/> object from the deserialized xml.</returns>
        public BggBase Deserialize(string xml)
        {
            var document = new XmlDocument();

            document.LoadXml(xml);
            var root = document.DocumentElement;

            var thing = new Thing
            {
                Type = DeserializeStringAttribute("type", root.SelectSingleNode(_rootXpath)),
                Id = DeserializeIntAttribute("id", root.SelectSingleNode(_rootXpath)),
                YearPublished = DeserializeIntAttribute("yearpublished", root),
                MinPlayers = DeserializeIntAttribute("minplayers", root),
                MaxPlayers = DeserializeIntAttribute("maxplayers", root),
                PlayingTime = DeserializeIntAttribute("playingtime", root),
                MinPlayTime = DeserializeIntAttribute("minplaytime", root),
                MaxPlayTime = DeserializeIntAttribute("maxplaytime", root),
                MinAge = DeserializeIntAttribute("minage", root),
                Poll = DeserializePolls(root.SelectNodes($"{_rootXpath}/poll")),
                Name = DeserializeBggNames(root.SelectNodes($"{_rootXpath}/name")),
                Thumbnail = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/thumbnail")),
                Image = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/image")),
                Description = DeserializeStringInnerText(root.SelectSingleNode($"{_rootXpath}/description")),
                Link = DeserializeLink(root.SelectNodes($"{_rootXpath}/link")),
                Versions = DeserializeVersions(root.SelectSingleNode($"{_rootXpath}/versions")),
                Comments = DeserializeComments(root.SelectSingleNode($"{_rootXpath}/comments")),
                MarketplaceListing = DeserializeMarketplaceListings(root.SelectSingleNode($"{_rootXpath}/marketplacelistings"))
            };

            return thing;
        }
    }
}
