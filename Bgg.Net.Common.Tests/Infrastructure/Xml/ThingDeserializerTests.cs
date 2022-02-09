using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    [TestClass]
    public class ThingDeserializerTests
    {
        private readonly IThingDeserializer deserializer;

        public ThingDeserializerTests()
        {
            deserializer = new ThingDeserializer(Mock.Of<ILogger>());
        }

        [TestMethod]
        public void DeserializeThings_Success()
        {
            //Act
            var result = deserializer.Deserialize(XmlGenerator.GenerateBoardGameXmlString());

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(1);
            result[0].Id.Should().Be(1);
            result[0].Type.Should().Be("boardgame");
            result[0].Thumbnail.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__thumb/img/YT6svCVsWqLrDitcMEtyazVktbQ=/fit-in/200x150/filters:strip_icc()/pic4718279.jpg");
            result[0].Image.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__original/img/yR0aoBVKNrAmmCuBeSzQnMflLYg=/0x0/filters:format(jpeg)/pic4718279.jpg");
            result[0].Name.Count.Should().Be(3);
            result[0].Name[0].Value.Should().Be("Die Macher");
            result[0].Name[1].Value.Should().Be("德国大选");
            result[0].Name[2].Value.Should().Be("디 마허");
            result[0].Description.Should().StartWith("Die Macher is a game about seven sequential political races in different regions of Germany. Players are in charge of national political parties, and must manage ");
            result[0].YearPublished.Should().Be(1986);
            result[0].MinPlayers.Should().Be(3);
            result[0].MaxPlayers.Should().Be(5);
            result[0].Poll.Count.Should().Be(3);
            result[0].PlayingTime.Should().Be(240);
            result[0].MaxPlayTime.Should().Be(240);
            result[0].MinPlayTime.Should().Be(240);
            result[0].MinAge.Should().Be(14);
            result[0].Link.Count.Should().Be(23);
            result[0].Versions.Count.Should().Be(8);
            result[0].Comments.TotalItems.Should().Be(2018);
            result[0].Comments.Comment.Count.Should().Be(100);
            result[0].MarketplaceListing.Count.Should().Be(53);
            result[0].Videos.Total.Should().Be(31);
            result[0].Videos.Video.Count.Should().Be(15);
            result[0].Videos.Video[0].Id.Should().Be(331304);
            result[0].Videos.Video[0].Id.Should().Be(331304);
            result[0].Videos.Video[0].Title.Should().Be("Die Macher Learn to Play");
            result[0].Videos.Video[0].Category.Should().Be("instructional");
            result[0].Videos.Video[0].Language.Should().Be("English");
            result[0].Videos.Video[0].Link.Should().Be("http://www.youtube.com/watch?v=fg1IiX41UKs");
            result[0].Videos.Video[0].UserId.Should().Be(1054024);
            result[0].Videos.Video[0].UserName.Should().Be("PieLoGic");
            result[0].Videos.Video[0].PostDate.Should().Be(DateTimeOffset.Parse("2021-06-26T17:38:47-05:00"));
            result[0].Statistics.Page.Should().Be(1);
            result[0].Statistics.Ratings.Should().NotBeNull();
            result[0].Statistics.Ratings.UsersRated.Should().Be(5381);
            result[0].Statistics.Ratings.Average.Should().Be(7.61485);
            result[0].Statistics.Ratings.BayesAverage.Should().Be(7.10199);
            result[0].Statistics.Ratings.Ranks.Count.Should().Be(2);
            result[0].Statistics.Ratings.Ranks[0].Type.Should().Be("subtype");
            result[0].Statistics.Ratings.Ranks[0].Id.Should().Be(1);
            result[0].Statistics.Ratings.Ranks[0].Name.Should().Be("boardgame");
            result[0].Statistics.Ratings.Ranks[0].FriendlyName.Should().Be("Board Game Rank");
            result[0].Statistics.Ratings.Ranks[0].Value.Should().Be(323);
            result[0].Statistics.Ratings.Ranks[0].BayesAverage.Should().Be(7.10199);
            result[0].Statistics.Ratings.StdDeviation.Should().Be(1.57893);
            result[0].Statistics.Ratings.Median.Should().Be(0);
            result[0].Statistics.Ratings.Owned.Should().Be(7546);
            result[0].Statistics.Ratings.Trading.Should().Be(250);
            result[0].Statistics.Ratings.Wanting.Should().Be(506);
            result[0].Statistics.Ratings.Wishing.Should().Be(2064);
            result[0].Statistics.Ratings.NumComments.Should().Be(2018);
            result[0].Statistics.Ratings.NumWeights.Should().Be(761);
            result[0].Statistics.Ratings.AverageWeights.Should().Be(4.3206);
        }

        [TestMethod]
        public void DeseralizeTest_Success_Multiple()
        {
            //Act
            var result = deserializer.Deserialize(XmlGenerator.GenerateMultipleItemXmlString());

            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].Id.Should().Be(1);
            result[0].Type.Should().Be("boardgame");
            result[0].Thumbnail.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__thumb/img/YT6svCVsWqLrDitcMEtyazVktbQ=/fit-in/200x150/filters:strip_icc()/pic4718279.jpg");
            result[0].Image.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__original/img/yR0aoBVKNrAmmCuBeSzQnMflLYg=/0x0/filters:format(jpeg)/pic4718279.jpg");
            result[0].Name.Count.Should().Be(3);
            result[0].Name[0].Value.Should().Be("Die Macher");
            result[0].Name[1].Value.Should().Be("德国大选");
            result[0].Name[2].Value.Should().Be("디 마허");
            result[0].Description.Should().StartWith("Die Macher is a game about seven sequential political races in different regions of Germany. Players are in charge of national political parties, and must manage ");
            result[0].YearPublished.Should().Be(1986);
            result[0].MinPlayers.Should().Be(3);
            result[0].MaxPlayers.Should().Be(5);
            result[0].Poll.Count.Should().Be(3);
            result[0].PlayingTime.Should().Be(240);
            result[0].MaxPlayTime.Should().Be(240);
            result[0].MinPlayTime.Should().Be(240);
            result[0].MinAge.Should().Be(14);
            result[0].Link.Count.Should().Be(23);
            result[0].Versions.Should().BeNullOrEmpty();
            result[0].Comments.Should().BeNull();
            result[0].MarketplaceListing.Should().BeNullOrEmpty();
            result[0].Videos.Should().BeNull();
            result[0].Statistics.Should().BeNull(); ;

            result[1].Id.Should().Be(2);
            result[1].Type.Should().Be("boardgame");
            result[1].Thumbnail.Should().Be("https://cf.geekdo-images.com/oQYhaJx5Lg3KcGis2reuWQ__thumb/img/3bIZnNfVM1viwH9A9d2Rrip1Y80=/fit-in/200x150/filters:strip_icc()/pic4001505.jpg");
            result[1].Image.Should().Be("https://cf.geekdo-images.com/oQYhaJx5Lg3KcGis2reuWQ__original/img/owag4VgJDPyPt2ciYB9Hc5l4GnQ=/0x0/filters:format(jpeg)/pic4001505.jpg");
            result[1].Name.Count.Should().Be(1);
            result[1].Name[0].Value.Should().Be("Dragonmaster");
            result[1].Description.Should().StartWith("Dragonmaster is a trick-taking card game based on an older game called Coup");
            result[1].YearPublished.Should().Be(1981);
            result[1].MinPlayers.Should().Be(3);
            result[1].MaxPlayers.Should().Be(4);
            result[1].Poll.Count.Should().Be(3);
            result[1].PlayingTime.Should().Be(30);
            result[1].MaxPlayTime.Should().Be(30);
            result[1].MinPlayTime.Should().Be(30);
            result[1].MinAge.Should().Be(12);
            result[1].Link.Count.Should().Be(11);
            result[1].Versions.Should().BeNullOrEmpty();
            result[1].Comments.Should().BeNull();
            result[1].MarketplaceListing.Should().BeNullOrEmpty();
            result[1].Videos.Should().BeNull();
            result[1].Statistics.Should().BeNull();
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
