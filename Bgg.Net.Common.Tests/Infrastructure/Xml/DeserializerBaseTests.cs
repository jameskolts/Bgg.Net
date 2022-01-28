using Bgg.Net.Common.Models.Polls;
using Bgg.Net.Common.Models.Versions;
using Bgg.Net.Common.Tests.TestWrappers;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml;
using System;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{

    [TestClass]
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public class DeserializerBaseTests
    {
        private readonly DeserializerBaseTestWrapper deserializer;
        private readonly XmlElement root;
        private const string _rootXpath = "//items/item";

        public DeserializerBaseTests()
        {
            deserializer = new DeserializerBaseTestWrapper("//items/item");
            root = XmlGenerator.GenerateThingXmlElement();
        }

        [TestMethod]
        public void DeserializeLink_Success()
        {
            //Arrange
            var nodeList = root.SelectNodes($"{_rootXpath}/link");

            //Act
            var result = deserializer.DeserializeLink(nodeList);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(23);
            result[0].Type.Should().Be("boardgamecategory");
            result[0].Id.Should().Be(1021);
            result[0].Value.Should().Be("Economic");
            result[1].Type.Should().Be("boardgamecategory");
            result[1].Id.Should().Be(1026);
            result[1].Value.Should().Be("Negotiation");
            result[2].Type.Should().Be("boardgamecategory");
            result[2].Id.Should().Be(1001);
            result[2].Value.Should().Be("Political");
        }

        [TestMethod]
        public void DeserializeLink_Null()
        {
            //Act
            var result = deserializer.DeserializeLink(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializePolls_Success()
        {
            //Arrange
            var nodeList = root.SelectNodes($"{_rootXpath}/poll");

            //Act
            var result = deserializer.DeserializePolls(nodeList);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(3);
            result[0].Name.Should().Be("suggested_numplayers");
            result[0].Title.Should().Be("User Suggested Number of Players");
            result[0].TotalVotes.Should().Be(132);

            result[0].Should().BeAssignableTo<PlayerCountPoll>();
            var playerCountPoll = result[0] as PlayerCountPoll;
            Assert.IsNotNull(playerCountPoll);
            playerCountPoll.Results.Count.Should().Be(6);

            playerCountPoll.Results[0].NumPlayers.Should().Be(1);
            playerCountPoll.Results[0].Results.Count().Should().Be(3);
            playerCountPoll.Results[0].Results[0].Value.Should().Be("Best");
            playerCountPoll.Results[0].Results[0].NumVotes.Should().Be(0);
            playerCountPoll.Results[0].Results[1].Value.Should().Be("Recommended");
            playerCountPoll.Results[0].Results[1].NumVotes.Should().Be(1);
            playerCountPoll.Results[0].Results[2].Value.Should().Be("Not Recommended");
            playerCountPoll.Results[0].Results[2].NumVotes.Should().Be(83);

            playerCountPoll.Results[1].NumPlayers.Should().Be(2);
            playerCountPoll.Results[1].Results.Count.Should().Be(3);
            playerCountPoll.Results[1].Results[0].Value.Should().Be("Best");
            playerCountPoll.Results[1].Results[0].NumVotes.Should().Be(0);
            playerCountPoll.Results[1].Results[1].Value.Should().Be("Recommended");
            playerCountPoll.Results[1].Results[1].NumVotes.Should().Be(1);
            playerCountPoll.Results[1].Results[2].Value.Should().Be("Not Recommended");
            playerCountPoll.Results[1].Results[2].NumVotes.Should().Be(85);

            result[1].Name.Should().Be("suggested_playerage");
            result[1].Title.Should().Be("User Suggested Player Age");
            result[1].TotalVotes.Should().Be(30);

            result[1].Should().BeAssignableTo<PlayerAgePoll>();
            var playerAgePoll = result[1] as PlayerAgePoll;
            Assert.IsNotNull(playerAgePoll);

            playerAgePoll.Results.Count.Should().Be(12);
            playerAgePoll.Results[0].Value.Should().Be("2");
            playerAgePoll.Results[0].NumVotes.Should().Be(0);
            playerAgePoll.Results[1].Value.Should().Be("3");
            playerAgePoll.Results[1].NumVotes.Should().Be(0);
            playerAgePoll.Results[2].Value.Should().Be("4");
            playerAgePoll.Results[2].NumVotes.Should().Be(0);
            playerAgePoll.Results[3].Value.Should().Be("5");
            playerAgePoll.Results[3].NumVotes.Should().Be(0);
            playerAgePoll.Results[4].Value.Should().Be("6");
            playerAgePoll.Results[4].NumVotes.Should().Be(0);
            playerAgePoll.Results[5].Value.Should().Be("8");
            playerAgePoll.Results[5].NumVotes.Should().Be(0);
            playerAgePoll.Results[6].Value.Should().Be("10");
            playerAgePoll.Results[6].NumVotes.Should().Be(0);
            playerAgePoll.Results[7].Value.Should().Be("12");
            playerAgePoll.Results[7].NumVotes.Should().Be(6);
            playerAgePoll.Results[8].Value.Should().Be("14");
            playerAgePoll.Results[8].NumVotes.Should().Be(17);
            playerAgePoll.Results[9].Value.Should().Be("16");
            playerAgePoll.Results[9].NumVotes.Should().Be(4);
            playerAgePoll.Results[10].Value.Should().Be("18");
            playerAgePoll.Results[10].NumVotes.Should().Be(2);
            playerAgePoll.Results[11].Value.Should().Be("21 and up");
            playerAgePoll.Results[11].NumVotes.Should().Be(1);

            result[2].Name.Should().Be("language_dependence");
            result[2].Title.Should().Be("Language Dependence");
            result[2].TotalVotes.Should().Be(48);
            result[2].Should().BeAssignableTo<LanguageDependencePoll>();
            var languagePoll = result[2] as LanguageDependencePoll;
            Assert.IsNotNull(languagePoll);

            languagePoll.Results.Count.Should().Be(5);
            languagePoll.Results[0].Level.Should().Be(1);
            languagePoll.Results[0].Value.Should().Be("No necessary in-game text");
            languagePoll.Results[0].NumVotes.Should().Be(36);
            languagePoll.Results[1].Level.Should().Be(2);
            languagePoll.Results[1].Value.Should().Be("Some necessary text - easily memorized or small crib sheet");
            languagePoll.Results[1].NumVotes.Should().Be(5);
        }

        [TestMethod]
        public void DeserializePoll_Null()
        {
            //Act
            var result = deserializer.DeserializePolls(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStringInnerText_Null()
        {
            //Act
            var result = deserializer.DeserializeStringInnerText(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStringInnerText_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/description");

            //Act
            var result = deserializer.DeserializeStringInnerText(node);

            //Assert
            result.Should().StartWith("Die Macher is a game about seven sequential political races in different regions of Germany.");
        }

        [TestMethod]
        public void DeserializeStringAttribute_NullProperty()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeStringAttribute(null, node);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStringAttribute_WhitespaceProperty()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeStringAttribute(" ", node);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStringAttribute_NullNode()
        {
            //Act
            var result = deserializer.DeserializeStringAttribute("type", null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStringAttribute_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeStringAttribute("type", node);

            //Assert
            result.Should().Be("boardgame");
        }

        [TestMethod]
        public void DeserializeIntAttribute_WrongProperty()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeIntAttribute("type", node);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeIntAttribute_WhitespaceProperty()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeIntAttribute(" ", node);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeIntAttribute_NullNode()
        {
            //Act
            var result = deserializer.DeserializeIntAttribute("id", null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeIntAttribute_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}");

            //Act
            var result = deserializer.DeserializeIntAttribute("id", node);

            //Assert
            result.Should().Be(1);
        }

        [TestMethod]
        public void DeserializeBggNames_Success()
        {
            //Arrange
            var nodes = root.SelectNodes($"{_rootXpath}/name");

            //Act
            var result = deserializer.DeserializeBggNames(nodes);

            //Assert
            result.Count.Should().Be(3);
            result[0].Type.Should().Be("primary");
            result[0].SortIndex.Should().Be(5);
            result[0].Value.Should().Be("Die Macher");
            result[1].Type.Should().Be("alternate");
            result[1].Value.Should().NotBeNullOrWhiteSpace();
            result[1].SortIndex.Should().Be(1);
            result[2].Type.Should().Be("alternate");
            result[2].Value.Should().NotBeNullOrWhiteSpace();
            result[2].SortIndex.Should().Be(1);
        }

        [TestMethod]
        public void DeserializeBggNames_Null()
        {
            //Act
            var result = deserializer.DeserializeBggNames(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializVersions_Null()
        {
            //Act
            var result = deserializer.DeserializeVersions(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeVersion_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/versions");

            //Act
            var result = deserializer.DeserializeVersions(node);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(8);

            result[0].Should().BeAssignableTo<BoardGameVersion>();
            var firstVersion = result[0] as BoardGameVersion;
            Assert.IsNotNull(firstVersion);

            firstVersion.Type.Should().Be(VersionType.BoardGame);
            firstVersion.Id.Should().Be(456543);
            firstVersion.Thumbnail.Should().Be("https://cf.geekdo-images.com/0bTB2RY9SP54L5Ua1l174A__thumb/img/LQtHKp9cFcT-Np632hh_02dtH28=/fit-in/200x150/filters:strip_icc()/pic4814244.jpg");
            firstVersion.Image.Should().Be("https://cf.geekdo-images.com/0bTB2RY9SP54L5Ua1l174A__original/img/z0GNyPQ69Sg6pds22vmGXUfhnEM=/0x0/filters:format(jpeg)/pic4814244.jpg");
            firstVersion.Links.Count.Should().Be(3);
            firstVersion.Links[0].Type.Should().Be("boardgameversion");
            firstVersion.Links[0].Id.Should().Be(1);
            firstVersion.Links[0].Value.Should().Be("Die Macher");
            firstVersion.Links[1].Type.Should().Be("boardgamepublisher");
            firstVersion.Links[1].Id.Should().Be(8147);
            firstVersion.Links[1].Value.Should().Be("YOKA Games");
            firstVersion.Links[2].Value.Should().Be("Chinese");
            firstVersion.Links[2].Type.Should().Be("language");
            firstVersion.Links[2].Id.Should().Be(2181);
            firstVersion.Name.Count.Should().Be(1);
            firstVersion.Name[0].Type.Should().Be("primary");
            firstVersion.Name[0].SortIndex.Should().Be(1);
            firstVersion.Name[0].Value.Should().Be("Chinese edition");
            firstVersion.YearPublished.Should().Be(2019);
            firstVersion.ProductCode.Should().BeNullOrWhiteSpace();
            firstVersion.Width.Should().Be(0);
            firstVersion.Length.Should().Be(0);
            firstVersion.Depth.Should().Be(0);
            firstVersion.Weight.Should().Be(0);

            result[1].Should().BeAssignableTo<BoardGameVersion>();
            var secondVersion = result[1] as BoardGameVersion;
            Assert.IsNotNull(secondVersion);

            secondVersion.Name.Count.Should().Be(1);
            secondVersion.Name[0].Value.Should().Be("German-only first edition");
            secondVersion.Length.Should().Be(12.5);
            secondVersion.Depth.Should().Be(2);
            secondVersion.Weight.Should().Be(0);
        }

        [TestMethod]
        public void DeserializeComments_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/comments");

            //Act
            var result = deserializer.DeserializeComments(node);

            //Assert
            result.Should().NotBeNull();
            result.Page.Should().Be(1);
            result.TotalItems.Should().Be(2018);
            result.Comment.Count.Should().Be(100);
            result.Comment[0].UserName.Should().Be(".JcK.");
            result.Comment[0].Rating.Should().Be(9);
            result.Comment[0].Value.Should().StartWith("Die Macher is one of the very few long games that I");
        }

        [TestMethod]
        public void DeserializeComments_Null()
        {
            //Act
            var result = deserializer.DeserializeComments(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeMarketplaceListings_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/marketplacelistings");

            //Act
            var result = deserializer.DeserializeMarketplaceListings(node);

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(53);
            result[0].ListDate.Should().Be(new DateTime(2015, 3, 18,7,45,57));
            result[0].Price.Currency.Should().Be("GBP");
            result[0].Price.Value.Should().Be(75);
            result[0].Condition.Should().Be("verygood");
            result[0].Notes.Should().Be("Shipping costs paid by buyer");
            result[0].Link.Href.Should().Be("https://boardgamegeek.com/geekmarket/product/718811");
            result[0].Link.Title.Should().Be("marketlisting");
        }

        [TestMethod]
        public void DeserializeMarketplacelistings_Null()
        {
            //Act
            var result = deserializer.DeserializeMarketplaceListings(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeVideos_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/videos");

            //Act
            var result = deserializer.DeserializeVideos(node);

            //Assert
            result.Should().NotBeNull();
            result.Total.Should().Be(31);
            result.Video.Count.Should().Be(15);
            result.Video[0].Id.Should().Be(331304);
            result.Video[0].Title.Should().Be("Die Macher Learn to Play");
            result.Video[0].Category.Should().Be("instructional");
            result.Video[0].Language.Should().Be("English");
            result.Video[0].Link.Should().Be("http://www.youtube.com/watch?v=fg1IiX41UKs");
            result.Video[0].UserId.Should().Be(1054024);
            result.Video[0].UserName.Should().Be("PieLoGic");
            result.Video[0].PostDate.Should().Be(DateTimeOffset.Parse("2021-06-26T17:38:47-05:00"));
        }

        [TestMethod]
        public void DeserializeVideos_Null()
        {
            //Act
            var result = deserializer.DeserializeVideos(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeStatistics_Success()
        {
            //Arrange
            var node = root.SelectSingleNode($"{_rootXpath}/statistics");

            //Act
            var result = deserializer.DeserializeStatistics(node);

            //Assert
            result.Should().NotBeNull();
            result.Page.Should().Be(1);
            result.Ratings.Should().NotBeNull();
            result.Ratings.UsersRated.Should().Be(5381);
            result.Ratings.Average.Should().Be(7.61485);
            result.Ratings.BayesAverage.Should().Be(7.10199);
            result.Ratings.Ranks.Count.Should().Be(2);
            result.Ratings.Ranks[0].Type.Should().Be("subtype");
            result.Ratings.Ranks[0].Id.Should().Be(1);
            result.Ratings.Ranks[0].Name.Should().Be("boardgame");
            result.Ratings.Ranks[0].FriendlyName.Should().Be("Board Game Rank");
            result.Ratings.Ranks[0].Value.Should().Be(323);
            result.Ratings.Ranks[0].BayesAverage.Should().Be(7.10199);
            result.Ratings.StdDeviation.Should().Be(1.57893);
            result.Ratings.Median.Should().Be(0);
            result.Ratings.Owned.Should().Be(7546);
            result.Ratings.Trading.Should().Be(250);
            result.Ratings.Wanting.Should().Be(506);
            result.Ratings.Wishing.Should().Be(2064);
            result.Ratings.NumComments.Should().Be(2018);
            result.Ratings.NumWeights.Should().Be(761);
            result.Ratings.AverageWeights.Should().Be(4.3206);
        }

        [TestMethod]
        public void DeserializeStatistics_Null()
        {
            //Act
            var result = deserializer.DeserializeStatistics(null);

            //Assert
            result.Should().BeNull();
        }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
