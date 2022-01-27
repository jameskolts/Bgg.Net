using Bgg.Net.Common.Models.Polls;
using Bgg.Net.Common.Tests.TestWrappers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml;

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
            var result = deserializer.DeseralizeLink(nodeList);

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
            var result = deserializer.DeseralizeLink(null);

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


    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
