using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Serilog;
using System.Xml;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Deserializes objects of type <seealso cref="Thing"/>.
    /// </summary>
    public class ThingDeserializer : DeserializerBase, IThingDeserializer
    {
        /// <summary>
        /// Creates a new instance of <see cref="ThingDeserializer"/>.
        /// </summary>
        /// <param name="logger">The logging instance.</param>
        public ThingDeserializer(ILogger logger)
            : base(logger)
        {
        }

        /// <inheritdoc/>
        public List<Thing> Deserialize(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            var things = new List<Thing>();
            var document = new XmlDocument();

            document.LoadXml(xml);
            var root = document.DocumentElement;

            foreach (XmlNode itemNode in root.ChildNodes)
            {
                var item = DeserializeThing(itemNode);

                if (item != null)
                {
                    things.Add(item);
                }
            }

            return things.Any() ? things : null;
        }       

        private Thing DeserializeThing(XmlNode itemNode)
        {
            var item = new Thing
            {
                Type = DeserializeStringAttribute("type", itemNode),
                Id = DeserializeIntAttribute("id", itemNode),
                YearPublished = DeserializeIntAttribute("value", itemNode.SelectSingleNode("yearpublished")),
                MinPlayers = DeserializeIntAttribute("value", itemNode.SelectSingleNode("minplayers")),
                MaxPlayers = DeserializeIntAttribute("value", itemNode.SelectSingleNode("maxplayers")),
                PlayingTime = DeserializeIntAttribute("value", itemNode.SelectSingleNode("playingtime")),
                MinPlayTime = DeserializeIntAttribute("value", itemNode.SelectSingleNode("minplaytime")),
                MaxPlayTime = DeserializeIntAttribute("value", itemNode.SelectSingleNode("maxplaytime")),
                MinAge = DeserializeIntAttribute("value", itemNode.SelectSingleNode("minage")),
                Poll = DeserializePolls(itemNode.SelectNodes("poll")),
                Name = DeserializeBggNames(itemNode.SelectNodes("name")),
                Thumbnail = DeserializeStringInnerText(itemNode.SelectSingleNode("thumbnail")),
                Image = DeserializeStringInnerText(itemNode.SelectSingleNode("image")),
                Description = DeserializeStringInnerText(itemNode.SelectSingleNode("description")),
                Link = DeserializeLink(itemNode.SelectNodes("link")),
                Versions = DeserializeVersions(itemNode.SelectSingleNode("versions")),
                Comments = DeserializeComments(itemNode.SelectSingleNode("comments")),
                MarketplaceListing = DeserializeMarketplaceListings(itemNode.SelectSingleNode("marketplacelistings")),
                Videos = DeserializeVideos(itemNode.SelectSingleNode("videos")),
                Statistics = DeserializeStatistics(itemNode.SelectSingleNode("statistics"))
            };

            if (item != null &&
                    (!string.IsNullOrWhiteSpace(item.Type) || item.Id.HasValue || item.YearPublished.HasValue ||
                    item.MinPlayers.HasValue || item.MaxPlayers.HasValue || item.PlayingTime.HasValue ||
                    item.MinPlayTime.HasValue || item.MaxPlayTime.HasValue || item.MinAge.HasValue ||
                    item.Poll.Any() || item.Name.Any() || !string.IsNullOrWhiteSpace(item.Thumbnail) ||
                    !string.IsNullOrWhiteSpace(item.Image) || !string.IsNullOrWhiteSpace(item.Description) ||
                    item.Link.Any() || item.Versions.Any() || item.Comments != null || item.MarketplaceListing.Any() ||
                    item.Videos != null || item.Statistics != null))
            {
                return item;
            }

            return null;
        }
    }
}
