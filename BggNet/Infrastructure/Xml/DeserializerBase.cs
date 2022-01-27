using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Polls;
using Bgg.Net.Common.Models.Polls.PollResults;
using Bgg.Net.Common.Models.Versions;
using Bgg.Net.Common.Types;
using System.Xml;
using Version = Bgg.Net.Common.Models.Versions.Version;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Abstract base class implementing common Deserialization functions.
    /// </summary>
    public abstract class DeserializerBase
    {
        protected readonly string _rootXpath;

        /// <summary>
        /// Constructs a new instance of <see cref="DeserializerBase"/>.
        /// </summary>
        /// <param name="rootXpath">The root xpath string.</param>
        public DeserializerBase(string rootXpath)
        {
            _rootXpath = rootXpath;
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
                    new XmlException("Invalid xml encountered while deserializing LanguageDependencePoll.");
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
                return node.Attributes.GetNamedItem(propertyName)?.Value;
            }

            return null;
        }

        /// <summary>
        /// Deserializes the attribute value of a given node.
        /// </summary>
        /// <param name="propertyName">The attribute to deserialize.</param>
        /// <param name="node">The <see cref="XmlNode"/> to deserialize.</param>
        /// <returns>The <see cref="int"/> value of the attribute.</returns>
        protected int? DeserializeIntAttribute(string propertyName, XmlNode node)
        {
            if (node != null)
            {
                return node.Attributes.GetNamedItem(propertyName)?.Value.ToNullableInt();
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
                        SortIndex = nameNode.Attributes.GetNamedItem("sortIndex")?.Value.ToNullableInt(),
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

            switch (versionType)
            {
                case VersionType.BoardGame:
                    return DeserializeBoardGameVersion(item);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Deserializes a boardgameversion from the given node.
        /// </summary>
        /// <param name="item">The node to deserialize.</param>
        /// <returns>A <see cref="BoardGameVersion"/> object.</returns>
        protected BoardGameVersion DeserializeBoardGameVersion(XmlNode item)
        {
            var version = new BoardGameVersion()
            {
                Type = VersionType.BoardGame,
                Id = item.Attributes.GetNamedItem("id")?.Value.ToNullableInt()
            };

            foreach (XmlNode child in item.ChildNodes)
            {
                if (child.Name == "thumbnail")
                {
                    version.Thumbnail = DeserializeStringInnerText(child);
                    continue;
                }

                if (child.Name == "image")
                {
                    version.Image = DeserializeStringInnerText(child);
                    continue;
                }

                if (child.Name == "link")
                {
                    version.Links = DeserializeLink(child.SelectNodes("link"));
                    continue;
                }

                if (child.Name == "name")
                {
                    version.Name = DeserializeBggNames(child.SelectNodes("name"));
                    continue;
                }

                if (child.Name == "yearpublished")
                {
                    version.YearPublished = DeserializeIntAttribute("yearpublished", child);
                    continue;
                }

                if (child.Name == "productcode")
                {
                    version.ProductCode = DeserializeStringAttribute("productcode", child);
                    continue;
                }

                if (child.Name == "width")
                {
                    version.Width = child.Attributes[0]?.Value.ToNullableDouble();
                    continue;
                }

                if (child.Name == "length")
                {
                    version.Length = child.Attributes[0]?.Value.ToNullableDouble();
                    continue;
                }

                if (child.Name == "depth")
                {
                    version.Depth = child.Attributes[0]?.Value.ToNullableDouble();
                    continue;
                }

                if (child.Name == "weight")
                {
                    version.Weight = child.Attributes[0]?.Value.ToNullableDouble();
                    continue;
                }
            }

            return version;
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
        protected List<Comment> DeserializeCommentList(XmlNode node)
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
                    if (childNode.Name == "listdate")
                    {
                        listing.ListDate = childNode.Value.ToNullabeDateTime();
                    }
                    else if (childNode.Name == "price")
                    {
                        listing.Price = new Price
                        {
                            Currency = childNode.Attributes.GetNamedItem("currency")?.Value,
                            Value = childNode.Attributes.GetNamedItem("value")?.Value.ToNullableDouble()
                        };
                    }
                    else if (childNode.Name == "condition")
                    {
                        listing.Condition = childNode.Value;
                    }
                    else if (childNode.Name == "notes")
                    {
                        listing.Notes = childNode.Value;
                    }
                    else if (childNode.Name == "link")
                    {
                        listing.Link = new ListingLink
                        {
                            Href = childNode.Attributes.GetNamedItem("href")?.Value,
                            Title = childNode.Attributes.GetNamedItem("title")?.Value,
                        };
                    }
                }
            }

            return listing;
        }
    }
}
