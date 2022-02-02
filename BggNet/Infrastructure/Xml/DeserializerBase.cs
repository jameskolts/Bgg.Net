using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Links;
using Bgg.Net.Common.Models.Polls;
using Bgg.Net.Common.Models.Polls.PollResults;
using Bgg.Net.Common.Models.Versions;
using Bgg.Net.Common.Types;
using Serilog;
using System.Xml;
using Version = Bgg.Net.Common.Models.Versions.Version;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Abstract base class implementing common Deserialization functions.
    /// </summary>
    public abstract class DeserializerBase
    {
        protected readonly ILogger _logger;


        /// <summary>
        /// Constructs a new instance of <see cref="DeserializerBase"/>.
        /// </summary>
        /// <param name="logger">The logging instance.</param>
        public DeserializerBase(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Deserializes the Poll objects from the given XmlNodeList.
        /// </summary>
        /// <param name="pollNodes">The <see cref="XmlNodeList"/> of polls.</param>
        /// <returns>A <see cref="List{Poll}"/> containing the Polls.</returns>
        protected List<Poll> DeserializePolls(XmlNodeList pollNodes)
        {
            var polls = new List<Poll>();

            if (pollNodes != null)
            {
                foreach (XmlNode pollNode in pollNodes)
                {
                    var poll = DeserializePoll(pollNode);

                    if (poll != null)
                    {
                        polls.Add(poll);
                    }
                }
            }

            return polls.Any() ? polls : null;
        }

        /// <summary>
        /// Deserializes a poll of any type from the given poll XmlNode.
        /// </summary>
        /// <param name="pollNode">The poll <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="Poll"/> of the correct type.</returns>
        protected Poll DeserializePoll(XmlNode pollNode)
        {
            if (pollNode != null && !string.IsNullOrWhiteSpace(pollNode.Name))
            {
                switch (pollNode.Attributes.GetNamedItem("name").Value)
                {
                    case "suggested_numplayers":
                        return DeserializePlayerCountPoll(pollNode);
                    case "suggested_playerage":
                        return DeserializePlayerAgePoll(pollNode);
                    case "language_dependence":
                        return DeserializeLanguagePoll(pollNode);
                }
            }

            return null;
        }

        /// <summary>
        /// Deserializes a LanguageDependencePoll from a given poll XmlNodeList.
        /// </summary>
        /// <param name="pollNode">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="LanguageDependencePoll"/> with the deserialized data.</returns>
        protected LanguageDependencePoll DeserializeLanguagePoll(XmlNode pollNode)
        {
            LanguageDependencePoll languagePoll = null;

            if (pollNode != null)
            {
                languagePoll = new LanguageDependencePoll();

                if (pollNode.ChildNodes.Count != 1)
                {
                    throw new XmlException("Invalid xml encountered while deserializing LanguageDependencePoll.");
                }

                foreach (XmlNode node in pollNode.ChildNodes[0])
                {
                    var pollResult = new LanguageResult
                    {
                        Value = node.Attributes?.GetNamedItem("value")?.Value,
                        NumVotes = node.Attributes?.GetNamedItem("numvotes")?.Value.ToNullableInt(),
                        Level = node.Attributes?.GetNamedItem("level")?.Value.ToNullableInt()
                    };

                    languagePoll.Results.Add(pollResult);
                }

                languagePoll.Name = pollNode.Attributes.GetNamedItem("name")?.Value;
                languagePoll.Title = pollNode.Attributes.GetNamedItem("title")?.Value;
                languagePoll.TotalVotes = pollNode.Attributes.GetNamedItem("totalvotes")?.Value.ToNullableInt();
            }

            return languagePoll;
        }

        /// <summary>
        /// Deserializes a PlayerAgePoll from a given poll XmlNodeList.
        /// </summary>
        /// <param name="pollNode">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="PlayerAgePoll"/> with the deserialized data.</returns>
        protected PlayerAgePoll DeserializePlayerAgePoll(XmlNode pollNode)
        {
            PlayerAgePoll playerAgePoll = null;

            if (pollNode != null)
            {
                playerAgePoll = new PlayerAgePoll();

                if (pollNode.ChildNodes.Count != 1)
                {
                    throw new XmlException("Invalid xml encountered while deserializing playeragepoll.");
                }

                foreach (XmlNode node in pollNode.ChildNodes[0])
                {
                    var pollResult = new PollResult
                    {
                        Value = node.Attributes?.GetNamedItem("value")?.Value,
                        NumVotes = node.Attributes?.GetNamedItem("numvotes")?.Value.ToNullableInt()
                    };

                    playerAgePoll.Results.Add(pollResult);
                }

                playerAgePoll.Name = pollNode.Attributes.GetNamedItem("name")?.Value;
                playerAgePoll.Title = pollNode.Attributes.GetNamedItem("title")?.Value;
                playerAgePoll.TotalVotes = pollNode.Attributes.GetNamedItem("totalvotes")?.Value.ToNullableInt();
            }

            return playerAgePoll;
        }

        /// <summary>
        /// Deserializes a PlayerCountPoll from a given poll XmlNodeList.
        /// </summary>
        /// <param name="pollNode">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="PlayerCountPoll"/> with the deserialized data.</returns>
        protected PlayerCountPoll DeserializePlayerCountPoll(XmlNode pollNode)
        {
            PlayerCountPoll playerCountPoll = null;
            var resultsNodes = pollNode.ChildNodes;

            if (resultsNodes != null)
            {
                playerCountPoll = new PlayerCountPoll();

                foreach (XmlNode node in resultsNodes)
                {
                    var playerCountResult = new PlayerCountResult
                    {
                        NumPlayers = node.Attributes?.GetNamedItem("numplayers")?.Value.ToNullableInt(),
                        Results = DeserializePollResultList(node.ChildNodes)
                    };

                    if (playerCountResult.NumPlayers != null || playerCountResult.Results.Any())
                    {
                        playerCountPoll.Results.Add(playerCountResult);
                    }
                }

                playerCountPoll.Name = pollNode.Attributes.GetNamedItem("name")?.Value;
                playerCountPoll.Title = pollNode.Attributes.GetNamedItem("title")?.Value;
                playerCountPoll.TotalVotes = pollNode.Attributes.GetNamedItem("totalvotes")?.Value.ToNullableInt();
            }

            return playerCountPoll;
        }
        
        /// <summary>
        /// Deserializes the PollResults objects from the given XmlNodeList.
        /// </summary>
        /// <param name="xmlNodeList">The <see cref="XmlNodeList"/> of PollResult.</param>
        /// <returns>A <see cref="List{PollResult}"/> containing the <see cref="PollResult"/>.</returns>
        private List<PollResult> DeserializePollResultList(XmlNodeList xmlNodeList)
        {
            var pollResultList = new List<PollResult>();

            if (xmlNodeList != null)
            {
                foreach (XmlNode pollResultNode in xmlNodeList)
                {
                    var pollResult = new PollResult
                    {
                        Value = pollResultNode.Attributes?.GetNamedItem("value")?.Value,
                        NumVotes = pollResultNode.Attributes?.GetNamedItem("numvotes")?.Value.ToNullableInt()
                    };

                    pollResultList.Add(pollResult);
                }
            }

            return pollResultList.Any() ? pollResultList : null;
        }

        /// <summary>
        /// Deserializes the innerText of a given node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The <see cref="string"/> value of the inner text.</returns>
        protected string DeserializeStringInnerText(XmlNode node)
        {
            if (node != null)
            {
                return node.InnerText;
            }

            return null;
        }

        /// <summary>
        /// Deserializes the attribute value of a given node.
        /// </summary>
        /// <param name="propertyName">The attribute to deserialize.</param>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The <see cref="string"/> value of the attribute.</returns>
        protected string DeserializeStringAttribute(string propertyName, XmlNode node)
        {
            if (node != null)
            {
                return node.Attributes?.GetNamedItem(propertyName)?.Value;
            }

            return null;
        }

        /// <summary>
        /// Deserializes the attribute value of a given node.
        /// </summary>
        /// <param name="attributeName">The attribute to deserialize.</param>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The <see cref="int"/> value of the attribute.</returns>
        protected int? DeserializeIntAttribute(string attributeName, XmlNode node)
        {
            if (node != null)
            {
                return node.Attributes?.GetNamedItem(attributeName)?.Value.ToNullableInt();
            }

            return null;
        }

        protected double? DeserializeDoubleAttribute(string attributeName, XmlNode node)
        {
            if (node != null)
            {
                return node.Attributes?.GetNamedItem(attributeName)?.Value.ToNullableDouble();
            }

            return null;
        }

        /// <summary>
        /// Deserializes the attribute value of a given node.
        /// </summary>
        /// <param name="attributeName">The attribute to deserialize.</param>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The <see cref="int"/> value of the attribute.</returns>
        protected long? DeserializeLongAttribute(string attributeName, XmlNode node)
        {
            if (node != null)
            {
                return node.Attributes?.GetNamedItem(attributeName)?.Value.ToNullableLong();
            }

            return null;
        }

        /// <summary>
        /// Deserializes the Links of a given node.
        /// </summary>
        /// <param name="nodeList">The <see cref="XmlNodeList"/> of links.</param>
        /// <returns>A <see cref="List{Link}"/> containing the deserialized <see cref="Link"/>.</returns>
        protected List<Link> DeserializeLink(XmlNodeList nodeList)
        {
            var links = new List<Link>();
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    var link = new Link
                    {
                        Id = node.Attributes.GetNamedItem("id")?.Value.ToNullableInt(),
                        Type = node.Attributes.GetNamedItem("type")?.Value,
                        Value = node.Attributes.GetNamedItem("value")?.Value
                    };

                    if (link.Id.HasValue || !string.IsNullOrWhiteSpace(link.Type) || !string.IsNullOrWhiteSpace(link.Value))
                    {
                        links.Add(link);
                    }
                }
            }

            return links.Any() ? links : null;
        }

        /// <summary>
        /// Deserializes the Names of a given node.
        /// </summary>
        /// <param name="nodes">The <see cref="XmlNodeList"/> of names.</param>
        /// <returns>A <see cref="List{BggName}"/> containing the deserialized <see cref="BggName"/>.</returns>
        protected List<BggName> DeserializeBggNames(XmlNodeList nodes)
        {
            var names = new List<BggName>();

            if (nodes != null)
            {
                foreach (XmlNode nameNode in nodes)
                {
                    var name = new BggName
                    {
                        Type = nameNode.Attributes.GetNamedItem("type")?.Value,
                        SortIndex = nameNode.Attributes.GetNamedItem("sortindex")?.Value.ToNullableInt(),
                        Value = nameNode.Attributes.GetNamedItem("value")?.Value
                    };

                    if (!string.IsNullOrWhiteSpace(name.Type) || name.SortIndex.HasValue || !string.IsNullOrWhiteSpace(name.Value))
                    {
                        names.Add(name);
                    }
                }
            }

            return names.Any() ? names : null;
        }

        /// <summary>
        /// Deserializes the Versions of a given node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> of versions.</param>
        /// <returns>A <see cref="List{Version}"/> containing the deserialized <see cref="Version"/>.</returns>
        protected List<Version> DeserializeVersions(XmlNode node)
        {
            var versions = new List<Version>();

            if (node != null)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    var version = DeserializeVersion(item);

                    if (version != null)
                    {
                        versions.Add(version);
                    }
                }
            }

            return versions.Any() ? versions : null;
        }

        /// <summary>
        /// Determines the type of version to deserialize and processis it accordingly.
        /// </summary>
        /// <param name="item">The item to deserialize.</param>
        /// <returns>A <see cref="Version"/> object.</returns>
        private Version DeserializeVersion(XmlNode item)
        {
            var versionType = item.Attributes.GetNamedItem("type")?.Value.ToVersionType();

            return versionType switch
            {
                VersionType.BoardGame => DeserializeBoardGameVersion(item),
                _ => null,
            };
        }

        /// <summary>
        /// Deserializes a boardgameversion from the given node.
        /// </summary>
        /// <param name="item">The node to deserialize.</param>
        /// <returns>A <see cref="BoardGameVersion"/> object.</returns>
        protected BoardGameVersion DeserializeBoardGameVersion(XmlNode item)
        {
            return new BoardGameVersion()
            {
                Type = VersionType.BoardGame,
                Id = item.Attributes.GetNamedItem("id")?.Value.ToNullableInt(),
                Links = DeserializeLink(item.SelectNodes("link")),
                Name = DeserializeBggNames(item.SelectNodes("name")),
                Thumbnail = DeserializeStringInnerText(item.SelectSingleNode("thumbnail")),
                Image = DeserializeStringInnerText(item.SelectSingleNode("image")),
                YearPublished = DeserializeIntAttribute("value", item.SelectSingleNode("yearpublished")),
                ProductCode = DeserializeStringAttribute("value", item.SelectSingleNode("productcode")),
                Width = item.SelectSingleNode("width").Attributes[0]?.Value.ToNullableDouble(),
                Length = item.SelectSingleNode("length").Attributes[0]?.Value.ToNullableDouble(),
                Depth = item.SelectSingleNode("depth").Attributes[0]?.Value.ToNullableDouble(),
                Weight = item.SelectSingleNode("weight").Attributes[0]?.Value.ToNullableDouble()
            };
        }

        /// <summary>
        /// Deserializes comments given an XmlNode.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> of the comment.</param>
        /// <returns>A <see cref="Comments"/> object.</returns>
        protected Comments DeserializeComments(XmlNode node)
        {
            Comments comments = null;

            if (node != null)
            {
                comments = new Comments
                {
                    Page = node.Attributes.GetNamedItem("page")?.Value.ToNullableInt(),
                    TotalItems = node.Attributes.GetNamedItem("totalitems")?.Value.ToNullableInt(),
                    Comment = DeserializeCommentList(node)
                };
            }

            return comments;
        }

        /// <summary>
        /// Deserializes the list of comment given an XmlNode.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Comment"/>.</returns>
        private List<Comment> DeserializeCommentList(XmlNode node)
        {
            var commentList = new List<Comment>();

            if (node != null)
            {
                foreach (XmlNode commentNode in node.SelectNodes("comment"))
                {
                    var comment = new Comment
                    {
                        Rating = commentNode.Attributes.GetNamedItem("rating")?.Value.ToNullableDouble(),
                        UserName = commentNode.Attributes.GetNamedItem("username")?.Value,
                        Value = commentNode.Attributes.GetNamedItem("value")?.Value
                    };

                    commentList.Add(comment);
                }
            }

            return commentList.Any() ? commentList : null;
        }

        /// <summary>
        /// Deserializes a list of listings given an XmlNode.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Listing"/>.</returns>
        protected List<Listing> DeserializeMarketplaceListings(XmlNode node)
        {
            var marketplaceListings = new List<Listing>();

            if (node != null)
            {
                foreach (XmlNode listingNode in node)
                {
                    var listing = DeserializeListing(listingNode);

                    if (listing != null)
                    {
                        marketplaceListings.Add(listing);
                    }
                }
            }

            return marketplaceListings.Any() ? marketplaceListings : null;
        }

        /// <summary>
        /// Deserializes a listing given an XmlNode.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="Listing"/>.</returns>
        protected Listing DeserializeListing(XmlNode node)
        {
            Listing listing = null;

            if (node != null)
            {
                listing = new Listing();

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "listdate":
                            listing.ListDate = childNode.Attributes.GetNamedItem("value").Value.ToNullableDateTime();
                            break;
                        case "price":
                            listing.Price = new Price
                            {
                                Currency = childNode.Attributes.GetNamedItem("currency")?.Value,
                                Value = childNode.Attributes.GetNamedItem("value")?.Value.ToNullableDouble()
                            };
                            break;
                        case "condition":
                            listing.Condition = childNode.Attributes.GetNamedItem("value")?.Value;
                            break;
                        case "notes":
                            listing.Notes = childNode.Attributes.GetNamedItem("value")?.Value;
                            break;
                        case "link":
                            listing.Link = new ListingLink
                            {
                                Href = childNode.Attributes.GetNamedItem("href")?.Value,
                                Title = childNode.Attributes.GetNamedItem("title")?.Value,
                            };
                            break;
                    }
                }
            }

            return listing;
        }

        /// <summary>
        /// Deserializes videos given an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Videos"/>.</returns>
        protected Videos DeserializeVideos(XmlNode node)
        {
            Videos videos = null;

            if (node != null)
            {
                videos = new Videos();
                videos.Total = node.Attributes.GetNamedItem("total")?.Value.ToNullableInt();

                foreach (XmlNode videoNode in node.ChildNodes)
                {
                    var video = DeserializeVideo(videoNode);

                    if (video != null)
                    {
                        videos.Video.Add(video);
                    }
                }
            }

            return videos;
        }

        /// <summary>
        /// Deserializes a video given an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Video"/>.</returns>
        protected Video DeserializeVideo(XmlNode node)
        {
            Video video = null;

            if (node != null)
            {
                video = new Video
                {
                    Id = DeserializeIntAttribute("id", node),
                    Title = DeserializeStringAttribute("title", node),
                    Category = DeserializeStringAttribute("category", node),
                    Language = DeserializeStringAttribute("language", node),
                    Link = DeserializeStringAttribute("link", node),
                    UserName = DeserializeStringAttribute("username", node),
                    UserId = DeserializeLongAttribute("userid", node),
                    PostDate = node.Attributes.GetNamedItem("postdate")?.Value.ToNullableDateTimeOffset()
                };
            }

            return video;
        }

        /// <summary>
        /// Deserializes Statistics given an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Statistics"/>.</returns>
        protected Statistics DeserializeStatistics(XmlNode node)
        {
            Statistics statistics = null;

            if (node != null)
            {
                if (node.ChildNodes.Count != 1)
                {
                    throw new XmlException("Invalid xml encountered while deserializing Statistic.");
                }

                statistics = new Statistics
                {
                    Page = DeserializeIntAttribute("page", node),
                    Ratings = DeserializeRatings(node.ChildNodes[0])
                };
            }

            return statistics;
        }

        /// <summary>
        /// Deserializes Ratings given an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Ratings"/>.</returns>
        protected Ratings DeserializeRatings(XmlNode node)
        {
            Ratings ratings = null;

            if (node != null)
            {
                ratings = new Ratings
                {
                    UsersRated = DeserializeLongAttribute("value", node.SelectSingleNode("usersrated")),
                    Average = DeserializeDoubleAttribute("value", node.SelectSingleNode("average")),
                    BayesAverage = DeserializeDoubleAttribute("value", node.SelectSingleNode("bayesaverage")),
                    Ranks = DeserializeRanks(node.SelectSingleNode("ranks")),
                    StdDeviation = DeserializeDoubleAttribute("value", node.SelectSingleNode("stddev")),
                    Median = DeserializeDoubleAttribute("value", node.SelectSingleNode("median")),
                    Owned = DeserializeLongAttribute("value", node.SelectSingleNode("owned")),
                    Wishing = DeserializeLongAttribute("value", node.SelectSingleNode("wishing")),
                    Trading = DeserializeLongAttribute("value", node.SelectSingleNode("trading")),
                    Wanting = DeserializeLongAttribute("value", node.SelectSingleNode("wanting")),
                    NumComments = DeserializeLongAttribute("value", node.SelectSingleNode("numcomments")),
                    NumWeights = DeserializeLongAttribute("value", node.SelectSingleNode("numweights")),
                    AverageWeights = DeserializeDoubleAttribute("value", node.SelectSingleNode("averageweight"))
                };
            }

            return ratings;
        }

        /// <summary>
        /// Deserializes rankings given an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Rank"/>.</returns>
        protected List<Rank> DeserializeRanks(XmlNode node)
        {
            List<Rank> ranks = null;

            if (node != null)
            {
                ranks = new List<Rank>();

                foreach (XmlNode child in node.ChildNodes)
                {
                    var rank = DeserializeRank(child); 

                    ranks.Add(rank);
                }  
            }

            return ranks;
        }

        /// <summary>
        /// Deserializes a rankgiven an xml node.
        /// </summary>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The deserialized <see cref="Rank"/>.</returns>
        protected Rank DeserializeRank(XmlNode node)
        {
            return new Rank
            {
                Type = DeserializeStringAttribute("type", node),
                Id = DeserializeLongAttribute("id", node),
                Name = DeserializeStringAttribute("name", node),
                FriendlyName = DeserializeStringAttribute("friendlyname", node),
                Value = DeserializeLongAttribute("value", node),
                BayesAverage = DeserializeDoubleAttribute("bayesaverage", node)
            };
        }
    }
}
