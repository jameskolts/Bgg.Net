using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    [TestClass]
    public class ThingDeserializerTests
    {
        private readonly IThingDeserializer deserializer;

        public ThingDeserializerTests()
        {
            deserializer = new ThingDeserializer("//items/item", Mock.Of<ILogger>());
        }

        [TestMethod]
        public void DeseralizeTest_Success()
        {
            //Act
            var result = deserializer.Deserialize(XmlGenerator.GenerateBoardGameXmlString());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Thing>();

            var thingResult = result as Thing;
            Assert.IsNotNull(thingResult);

            thingResult.Id.Should().Be(1);
            thingResult.Type.Should().Be("boardgame");
            thingResult.Thumbnail.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__thumb/img/YT6svCVsWqLrDitcMEtyazVktbQ=/fit-in/200x150/filters:strip_icc()/pic4718279.jpg");
            thingResult.Image.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__original/img/yR0aoBVKNrAmmCuBeSzQnMflLYg=/0x0/filters:format(jpeg)/pic4718279.jpg");
            thingResult.Name.Count.Should().Be(3);
            thingResult.Description.Should().StartWith("Die Macher is a game about seven sequential political races in different regions of Germany. Players are in charge of national political parties, and must manage ");
            thingResult.YearPublished.Should().Be(1986);
            thingResult.MinPlayers.Should().Be(3);
            thingResult.MaxPlayers.Should().Be(5);
            thingResult.Poll.Count.Should().Be(3);
            thingResult.PlayingTime.Should().Be(240);
            thingResult.MaxPlayTime.Should().Be(240);
            thingResult.MinPlayTime.Should().Be(240);
            thingResult.MinAge.Should().Be(14);
            thingResult.Link.Count.Should().Be(23);
            thingResult.Versions.Count.Should().Be(8);
            thingResult.Comments.TotalItems.Should().Be(2018);
            thingResult.Comments.Comment.Count.Should().Be(100);
            thingResult.MarketplaceListing.Count.Should().Be(53);
        }

        [TestMethod]
        public void DeserializeTest_Null()
        {
            //Act
            var result = deserializer.Deserialize(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeTest_Whitespace()
        {
            //Act
            var result = deserializer.Deserialize(" ");

            //Assert
            result.Should().BeNull();
        }
    }
}
