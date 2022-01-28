using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
            result.Id.Should().Be(1);
            result.Type.Should().Be("boardgame");
            result.Thumbnail.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__thumb/img/YT6svCVsWqLrDitcMEtyazVktbQ=/fit-in/200x150/filters:strip_icc()/pic4718279.jpg");
            result.Image.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__original/img/yR0aoBVKNrAmmCuBeSzQnMflLYg=/0x0/filters:format(jpeg)/pic4718279.jpg");
            result.Name.Count.Should().Be(3);
            result.Description.Should().StartWith("Die Macher is a game about seven sequential political races in different regions of Germany. Players are in charge of national political parties, and must manage ");
            result.YearPublished.Should().Be(1986);
            result.MinPlayers.Should().Be(3);
            result.MaxPlayers.Should().Be(5);
            result.Poll.Count.Should().Be(3);
            result.PlayingTime.Should().Be(240);
            result.MaxPlayTime.Should().Be(240);
            result.MinPlayTime.Should().Be(240);
            result.MinAge.Should().Be(14);
            result.Link.Count.Should().Be(23);
            result.Versions.Count.Should().Be(8);
            result.Comments.TotalItems.Should().Be(2018);
            result.Comments.Comment.Count.Should().Be(100);
            result.MarketplaceListing.Count.Should().Be(53);
            result.Videos.Total.Should().Be(31);
            result.Videos.Video.Count.Should().Be(15);
            result.Videos.Video[0].Id.Should().Be(331304);
            result.Videos.Video[0].Id.Should().Be(331304);
            result.Videos.Video[0].Title.Should().Be("Die Macher Learn to Play");
            result.Videos.Video[0].Category.Should().Be("instructional");
            result.Videos.Video[0].Language.Should().Be("English");
            result.Videos.Video[0].Link.Should().Be("http://www.youtube.com/watch?v=fg1IiX41UKs");
            result.Videos.Video[0].UserId.Should().Be(1054024);
            result.Videos.Video[0].UserName.Should().Be("PieLoGic");
            result.Videos.Video[0].PostDate.Should().Be(DateTimeOffset.Parse("2021-06-26T17:38:47-05:00"));
            result.Statistics.Page.Should().Be(1);
            result.Statistics.Ratings.Should().NotBeNull();
            result.Statistics.Ratings.UsersRated.Should().Be(5381);
            result.Statistics.Ratings.Average.Should().Be(7.61485);
            result.Statistics.Ratings.BayesAverage.Should().Be(7.10199);
            result.Statistics.Ratings.Ranks.Count.Should().Be(2);
            result.Statistics.Ratings.Ranks[0].Type.Should().Be("subtype");
            result.Statistics.Ratings.Ranks[0].Id.Should().Be(1);
            result.Statistics.Ratings.Ranks[0].Name.Should().Be("boardgame");
            result.Statistics.Ratings.Ranks[0].FriendlyName.Should().Be("Board Game Rank");
            result.Statistics.Ratings.Ranks[0].Value.Should().Be(323);
            result.Statistics.Ratings.Ranks[0].BayesAverage.Should().Be(7.10199);
            result.Statistics.Ratings.StdDeviation.Should().Be(1.57893);
            result.Statistics.Ratings.Median.Should().Be(0);
            result.Statistics.Ratings.Owned.Should().Be(7546);
            result.Statistics.Ratings.Trading.Should().Be(250);
            result.Statistics.Ratings.Wanting.Should().Be(506);
            result.Statistics.Ratings.Wishing.Should().Be(2064);
            result.Statistics.Ratings.NumComments.Should().Be(2018);
            result.Statistics.Ratings.NumWeights.Should().Be(761);
            result.Statistics.Ratings.AverageWeights.Should().Be(4.3206);
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
