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
    public abstract class DeserializerBase
    {
        protected readonly string _rootXpath;

        public DeserializerBase(string rootXpath)
        {
            _rootXpath = rootXpath;
        }

        /// <summary>
        /// Used to set a string property thats value matches to the innertext of an xml node.
        /// </summary>
        /// <param name="obj">The object to set the properties of.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="root">The root xmlelement.</param>
        protected void SetStringProperty(object obj, string propertyName, XmlElement root)
        {
            var node = root.SelectSingleNode($"{_rootXpath}/{propertyName.ToLower()}");
            if (node != null)
            {
                obj.GetType().GetProperty(propertyName.FirstCharToUpper()).SetValue(obj, node.InnerText);
            }
        }

        /// <summary>
        /// Used to set an int? property that's value comes from a single attribute.
        /// </summary>
        /// <param name="thing">The thing to set the properties of.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="root">The root xmlelement.</param>
        protected void SetIntAttribute(Thing thing, string propertyName, XmlElement root)
        {
            var node = root.SelectSingleNode($"{_rootXpath}/{propertyName.ToLower()}");
            if (node != null)
            {
                thing.GetType().GetProperty(propertyName.FirstCharToUpper()).SetValue(thing, node.Attributes[0]?.Value.ToNullableInt());
            }
        }

        /// <summary>
        /// Given the <see cref="XmlNodeList"/> of links, deserializes the values into a list of objects.
        /// </summary>
        /// <param name="nodeList">The <see cref="XmlNodeList"/> of links.</param>
        /// <returns>A <see cref="List{Link}"/> containing the deserialized objects.</returns>
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

        protected List<BggName> DeserializeBggNames(XmlElement root)
        {
            var names = new List<BggName>();

            var nodes = root.SelectNodes($"{_rootXpath}/name");
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

            return names;
        }

        protected List<Version> DeserializeVersions(XmlElement root)
        {
            var versions = new List<Version>();

            var node = root.SelectSingleNode($"{_rootXpath}/versions");
            if (node != null)
            {
                foreach (XmlElement item in node.ChildNodes)
                {
                    var version = DeserializeVersion(item);

                    if (version != null)
                    {
                        versions.Add(version);
                    }
                }
            }

            return versions;
        }

        protected Version DeserializeVersion(XmlElement item)
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
                    version.Thumbnail = child.InnerText;
                }

                if (child.Name == "image")
                {
                    version.Image = child.InnerText;
                }

                if (child.Name == "link")
                {
                    version.Links = DeserializeLink(child.SelectNodes("link"));
                }

                if (child.Name == "name")
                {
                    version.Name = DeserializeBggNames((XmlElement)child);
                }

                if (child.Name == "yearpublished")
                {
                    version.YearPublished = child.Attributes[0]?.Value.ToNullableInt();
                }

                if (child.Name == "productcode")
                {
                    version.ProductCode = child.Attributes[0]?.Value;
                }

                if (child.Name == "width")
                {
                    version.Width = child.Attributes[0]?.Value.ToNullableDouble();
                }

                if (child.Name == "length")
                {
                    version.Length = child.Attributes[0]?.Value.ToNullableDouble();
                }

                if (child.Name == "depth")
                {
                    version.Depth = child.Attributes[0]?.Value.ToNullableDouble();
                }

                if (child.Name == "weight")
                {
                    version.Weight = child.Attributes[0]?.Value.ToNullableDouble();
                }
            }

            return version;
        }

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
