using Bgg.Net.Common.Infrastructure.Exceptions;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Tests.TestFiles;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;
using System.Linq;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    [TestClass]
    public class BggDeserializerTests
    {
        private readonly IBggDeserializer _deserializer;

        public BggDeserializerTests()
        {
            _deserializer = new BggDeserializer(Mock.Of<ILogger>());
        }

        [TestMethod]
        public void Deserialize_Null()
        {
            //Act
            var result = _deserializer.Deserialize<Forum>(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void Deserialize_Whitespace()
        {
            //Act
            var result = _deserializer.Deserialize<Forum>(" ");

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void Deserialize_ThrowsException()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.MultipleBoardGameXml); //Bad xml for this deserilization;

            //Act
            Action act = () => _deserializer.Deserialize<Forum>(xml);

            //Assert
            act.Should().Throw<XmlDeserializationException>()                
                .WithMessage("There is an error in XML document (2, 2).")
                .WithInnerException(typeof(InvalidOperationException));
        }

        [TestMethod]
        public void Deserialize_ThingList()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml);

            //Act
            var result = _deserializer.Deserialize<ThingList>(xml);

            //Assert
            result.Should().NotBeNull();
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Things.Count.Should().Be(1);

            var thing = result.Things[0];
            thing.Thumbnail.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__thumb/img/YT6svCVsWqLrDitcMEtyazVktbQ=/fit-in/200x150/filters:strip_icc()/pic4718279.jpg");
            thing.Image.Should().Be("https://cf.geekdo-images.com/rpwCZAjYLD940NWwP3SRoA__original/img/yR0aoBVKNrAmmCuBeSzQnMflLYg=/0x0/filters:format(jpeg)/pic4718279.jpg");
            thing.Name.Count.Should().Be(3);
            thing.Type.Should().Be("boardgame");
            thing.Id.Should().Be(1);
            thing.Name[0].Type.Should().Be("primary");
            thing.Name[0].SortIndex.Should().Be(5);
            thing.Name[0].Value.Should().Be("Die Macher");
            thing.Name[1].Value.Should().Be("德国大选");
            thing.Name[2].Value.Should().Be("디 마허");
            thing.Description.Should().StartWith("Die Macher is a game about seven sequential political");
            thing.YearPublished.Value.Should().Be(1986);
            thing.MinPlayers.Value.Should().Be(3);
            thing.MaxPlayers.Value.Should().Be(5);
            thing.Poll.Count.Should().Be(3);
            thing.Poll[0].Title.Should().Be("User Suggested Number of Players");
            thing.Poll[0].Name.Should().Be("suggested_numplayers");
            thing.Poll[0].TotalVotes.Should().Be(132);
            thing.Poll[0].Results.Count.Should().Be(6);
            thing.Poll[0].Results[0].NumPlayers.Should().Be("1");
            thing.Poll[0].Results[0].Result.Count.Should().Be(3);
            thing.Poll[0].Results[0].Result[0].Value.Should().Be("Best");
            thing.Poll[0].Results[0].Result[0].NumVotes.Should().Be(0);
            thing.Poll[0].Results[0].Result[0].Level.Should().BeNull();
            thing.Poll[0].Results[0].Result[1].NumVotes.Should().Be(1);
            thing.Poll[0].Results[0].Result[1].Value.Should().Be("Recommended");
            thing.Poll[0].Results[0].Result[2].NumVotes.Should().Be(83);
            thing.Poll[0].Results[0].Result[2].Value.Should().Be("Not Recommended");
            thing.Poll[0].Results[1].NumPlayers.Should().Be("2");
            thing.Poll[0].Results.Last().NumPlayers.Should().Be("5+");
            thing.Poll[1].Name.Should().Be("suggested_playerage");
            thing.Poll[1].Title.Should().Be("User Suggested Player Age");
            thing.Poll[1].TotalVotes.Should().Be(30);
            thing.Poll[1].Results.Count.Should().Be(1);
            thing.Poll[1].Results[0].Result.Count.Should().Be(12);
            thing.Poll[1].Results[0].Result[0].Value.Should().Be("2");
            thing.Poll[1].Results[0].Result[0].NumVotes.Should().Be(0);
            thing.Poll[1].Results[0].Result[0].Level.Should().BeNull();
            thing.Poll[1].Results[0].Result.Last().Value.Should().Be("21 and up");
            thing.Poll[1].Results[0].Result.Last().NumVotes.Should().Be(1);
            thing.Poll[2].Name.Should().Be("language_dependence");
            thing.Poll[2].Title.Should().Be("Language Dependence");
            thing.Poll[2].TotalVotes.Should().Be(48);
            thing.Poll[2].Results.Count.Should().Be(1);
            thing.Poll[2].Results[0].Result.Count.Should().Be(5);
            thing.Poll[2].Results[0].Result[0].Level.Should().Be("1");
            thing.Poll[2].Results[0].Result[0].Value.Should().Be("No necessary in-game text");
            thing.Poll[2].Results[0].Result[0].NumVotes.Should().Be(36);
            thing.PlayingTime.Value.Should().Be(240);
            thing.MaxPlayTime.Value.Should().Be(240);
            thing.MinPlayTime.Value.Should().Be(240);
            thing.MinAge.Value.Should().Be(14);
            thing.Links.Count.Should().Be(23);
            thing.Links[0].Type.Should().Be("boardgamecategory");
            thing.Links[0].Id.Should().Be(1021);
            thing.Links[0].Value.Should().Be("Economic");
            thing.Videos.Total.Should().Be(31);
            thing.Videos.Video.Count.Should().Be(15);
            thing.Videos.Video[0].Id.Should().Be(331304);
            thing.Videos.Video[0].Title.Should().Be("Die Macher Learn to Play");
            thing.Videos.Video[0].Category.Should().Be("instructional");
            thing.Videos.Video[0].Language.Should().Be("English");
            thing.Videos.Video[0].Link.Should().Be("http://www.youtube.com/watch?v=fg1IiX41UKs");
            thing.Videos.Video[0].UserName.Should().Be("PieLoGic");
            thing.Videos.Video[0].UserId.Should().Be(1054024);
            thing.Videos.Video[0].PostDate.Should().Be("2021-06-26T17:38:47-05:00");
            thing.Versions.Count.Should().Be(8);
            thing.Versions[0].Type.Should().Be("boardgameversion");
            thing.Versions[0].Id.Should().Be(456543);
            thing.Versions[0].Thumbnail.Should().Be("https://cf.geekdo-images.com/0bTB2RY9SP54L5Ua1l174A__thumb/img/LQtHKp9cFcT-Np632hh_02dtH28=/fit-in/200x150/filters:strip_icc()/pic4814244.jpg");
            thing.Versions[0].Image.Should().Be("https://cf.geekdo-images.com/0bTB2RY9SP54L5Ua1l174A__original/img/z0GNyPQ69Sg6pds22vmGXUfhnEM=/0x0/filters:format(jpeg)/pic4814244.jpg");
            thing.Versions[0].Links.Count.Should().Be(3);
            thing.Versions[0].Links[0].Type.Should().Be("boardgameversion");
            thing.Versions[0].Links[0].Id.Should().Be(1);
            thing.Versions[0].Links[0].Value.Should().Be("Die Macher");
            thing.Versions[0].Name.Count.Should().Be(1);
            thing.Versions[0].Name[0].Type.Should().Be("primary");
            thing.Versions[0].Name[0].Value.Should().Be("Chinese edition");
            thing.Versions[0].Name[0].SortIndex.Should().Be(1);
            thing.Comments.Page.Should().Be(1);
            thing.Comments.TotalItems.Should().Be(2018);
            thing.Comments.Comment.Count.Should().Be(100);
            thing.Comments.Comment[0].UserName.Should().Be(".JcK.");
            thing.Comments.Comment[0].Rating.Should().Be("9");
            thing.Comments.Comment[0].Value.Should().StartWith("Die Macher is one of the very few long games");
            thing.Statistics.Page.Should().Be(1);
            thing.Statistics.Ratings.UsersRated.Value.Should().Be(5381);
            thing.Statistics.Ratings.Average.Value.Should().Be(7.61485);
            thing.Statistics.Ratings.BayesAverage.Value.Should().Be(7.10199);
            thing.Statistics.Ratings.Ranks.Count.Should().Be(2);
            thing.Statistics.Ratings.Ranks[0].Type.Should().Be("subtype");
            thing.Statistics.Ratings.Ranks[0].Name.Should().Be("boardgame");
            thing.Statistics.Ratings.Ranks[0].FriendlyName.Should().Be("Board Game Rank");
            thing.Statistics.Ratings.Ranks[0].Value.Should().Be(323);
            thing.Statistics.Ratings.Ranks[0].BayesAverage.Should().Be(7.10199);
            thing.Statistics.Ratings.StdDeviation.Value.Should().Be(1.57893);
            thing.Statistics.Ratings.Median.Value.Should().Be(0);
            thing.Statistics.Ratings.Owned.Value.Should().Be(7546);
            thing.Statistics.Ratings.Trading.Value.Should().Be(250);
            thing.Statistics.Ratings.Wanting.Value.Should().Be(506);
            thing.Statistics.Ratings.Wishing.Value.Should().Be(2064);
            thing.Statistics.Ratings.NumComments.Value.Should().Be(2018);
            thing.Statistics.Ratings.NumWeights.Value.Should().Be(761);
            thing.Statistics.Ratings.AverageWeights.Value.Should().Be(4.3206);
            thing.MarketplaceListing.Count.Should().Be(53);
            thing.MarketplaceListing[0].ListDate.Value.Should().Be("Wed, 18 Mar 2015 11:45:57 +0000");
            thing.MarketplaceListing[0].Price.Currency.Should().Be("GBP");
            thing.MarketplaceListing[0].Price.Value.Should().Be((decimal)75.00);
            thing.MarketplaceListing[0].Condition.Value.Should().Be("verygood");
            thing.MarketplaceListing[0].Notes.Value.Should().Be("Shipping costs paid by buyer");
            thing.MarketplaceListing[0].Link.Href.Should().Be("https://boardgamegeek.com/geekmarket/product/718811");
            thing.MarketplaceListing[0].Link.Title.Should().Be("marketlisting");
        }

        [TestMethod]
        public void Deserialize_ThingList_Multiple()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.MultipleBoardGameXml);

            //Act
            var result = _deserializer.Deserialize<ThingList>(xml);

            //Assert
            result.Should().NotBeNull();
            result.Things.Count.Should().Be(2);
            result.Things[0].Id.Should().Be(1);
            result.Things[1].Id.Should().Be(2);
        }

        [TestMethod]
        public void Deserialize_Family()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.FamilyXml);

            //Act
            var result = _deserializer.Deserialize<FamilyList>(xml);

            //Assert
            result.Should().NotBeNull();
            result.TermsOfUse.Should().EndWith("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Families.Count.Should().Be(2);

            result.Families[0].Type.Should().Be("boardgamefamily");
            result.Families[0].Id.Should().Be(4);
            result.Families[0].Thumbnail.Should().Be("https://cf.geekdo-images.com/TeW2-Qo-yWwe19v-RaUnLQ__thumb/img/jTctkjj7ajx3Jhd0OBe4nPz5K9Q=/fit-in/200x150/filters:strip_icc()/pic680679.jpg");
            result.Families[0].Image.Should().Be("https://cf.geekdo-images.com/TeW2-Qo-yWwe19v-RaUnLQ__original/img/4U5hid4FIsZUoRZlIJCYQRLvY-I=/0x0/filters:format(jpeg)/pic680679.jpg");
            result.Families[0].Name.Count.Should().Be(4);
            result.Families[0].Name[0].Type.Should().Be("primary");
            result.Families[0].Name[0].SortIndex.Should().Be(1);
            result.Families[0].Name[0].Value.Should().Be("Series: The Chicken Family of Zoch");
            result.Families[0].Name[1].Value.Should().Be("Series: Chicken World");
            result.Families[0].Name[2].Value.Should().Be("Series: Die Hühnerfamilie von Zoch");
            result.Families[0].Description.Should().StartWith("The Chicken Family of Zoch (Die");
            result.Families[0].Links.Count.Should().Be(18);
            result.Families[0].Links[0].Type.Should().Be("boardgamefamily");
            result.Families[0].Links[0].Id.Should().Be(3507);
            result.Families[0].Links[0].Value.Should().Be("By Golly!");
            result.Families[0].Links[0].Inbound.Should().Be(true);

            result.Families[1].Type.Should().Be("boardgamefamily");
            result.Families[1].Id.Should().Be(5);
            result.Families[1].Links.Count.Should().Be(49);
        }

        [TestMethod]
        public void Deserialize_Forum()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml);

            //Act
            var result = _deserializer.Deserialize<Forum>(xml);

            //Assert
            result.Should().NotBeNull();
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Id.Should().Be(2);
            result.Title.Should().Be("General");
            result.NumThreads.Should().Be(4);
            result.NumPosts.Should().Be(10);
            result.LastPostDate.Should().Be("Thu, 01 Jan 1970 00:00:00 +0000");
            result.NoPosting.Should().Be(false);
            result.Threads.Count.Should().Be(4);
            result.Threads[0].Id.Should().Be(2504878);
            result.Threads[0].Subject.Should().Be("A gallery for all the cards in SPANC?");
            result.Threads[0].Author.Should().Be("N/A");
            result.Threads[0].NumArticles.Should().Be(2);
            result.Threads[0].PostDate.Should().Be("Thu, 17 Sep 2020 05:03:54 +0000");
            result.Threads[0].LastPostDate.Should().Be("Thu, 17 Sep 2020 18:51:53 +0000");
        }

        [TestMethod]
        public void Deserialize_ForumList()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumListXml);

            //Act
            var result = _deserializer.Deserialize<ForumList>(xml);

            //Assert
            result.Should().NotBeNull();
            result.Type.Should().Be("thing");
            result.Id.Should().Be(2);
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Forums.Count.Should().Be(10);
            result.Forums[0].Id.Should().Be(23176);
            result.Forums[0].GroupId.Should().Be(0);
            result.Forums[0].Title.Should().Be("Reviews");
            result.Forums[0].NoPosting.Should().Be(false);
            result.Forums[0].Description.Should().StartWith("Post your game reviews in this forum.");
            result.Forums[0].NumThreads.Should().Be(5);
            result.Forums[0].NumPosts.Should().Be(48);
            result.Forums[0].LastPostDate.Should().Be("Wed, 02 Mar 2022 07:25:00 +0000");
        }

        [TestMethod]
        public void Deserialize_Thread()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml);

            //Act
            var result = _deserializer.Deserialize<Thread>(xml);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(25);
            result.NumArticles.Should().Be(1);
            result.Link.Should().Be("https://boardgamegeek.com/thread/25");
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Subject.Should().Be("User Review");
            result.Articles.Count.Should().Be(8);
            result.Articles[0].Id.Should().Be(24);
            result.Articles[0].Username.Should().Be("BoardGameGeek");
            result.Articles[0].Link.Should().Be("https://boardgamegeek.com/thread/25/article/24#24");
            result.Articles[0].PostDate.Should().Be("2000-07-09T13:09:35-05:00");
            result.Articles[0].EditDate.Should().Be("2000-07-09T13:09:35-05:00");
            result.Articles[0].NumEdits.Should().Be(0);
            result.Articles[0].Subject.Should().Be("User Review");
            result.Articles[0].Body.Should().StartWith("A quick, light rummy-variant for two-4 players. Rating 6.5");
        }

        [TestMethod]
        public void Deserialize_User()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml);

            //Act
            var result = _deserializer.Deserialize<User>(xml);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1014881);
            result.Name.Should().Be("Jimmydm90");
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.FirstName.Value.Should().BeEmpty();
            result.LastName.Value.Should().BeEmpty();
            result.AvatarLink.Value.Should().Be("https://cf.geekdo-static.com/avatars/avatar_id121793.png");
            result.YearRegistered.Value.Should().Be(2015);
            result.LastLogin.Value.Should().Be("2022-05-20");
            result.StateOrProvince.Value.Should().Be("California");
            result.Country.Value.Should().Be("United States");
            result.WebAddress.Value.Should().BeEmpty();
            result.XboxAccount.Value.Should().BeEmpty();
            result.WiiAccount.Value.Should().BeEmpty();
            result.PsnNetwork.Value.Should().Be("Jimmydm90");
            result.BattleNetAccount.Value.Should().BeEmpty();
            result.SteamAccount.Value.Should().BeEmpty();
            result.TradeRating.Value.Should().Be(2);
            result.MarketRating.Value.Should().Be(1);
            result.Buddies.Total.Should().Be(40);
            result.Buddies.Page.Should().Be(1);
            result.Buddies.Buddy.Count.Should().Be(40);
            result.Buddies.Buddy[0].Id.Should().Be(1246415);
            result.Buddies.Buddy[0].Name.Should().Be("alflossomisersdream");
            result.Guilds.Total.Should().Be(7);
            result.Guilds.Page.Should().Be(1);
            result.Guilds.Guild.Count.Should().Be(7);
            result.Guilds.Guild[0].Id.Should().Be(24);
            result.Guilds.Guild[0].Name.Should().Be("The Dice Tower");
            result.Top.Domain.Should().Be("boardgame");
            result.Top.Item.Count.Should().Be(10);
            result.Top.Item[0].Rank.Should().Be(1);
            result.Top.Item[0].Type.Should().Be("thing");
            result.Top.Item[0].Id.Should().Be(132531);
            result.Top.Item[0].Name.Should().Be("Roll for the Galaxy");
            result.Hot.Domain.Should().Be("boardgame");
            result.Hot.Item.Count.Should().Be(10);
            result.Hot.Item[0].Rank.Should().Be(1);
            result.Hot.Item[0].Type.Should().Be("thing");
            result.Hot.Item[0].Id.Should().Be(182874);
            result.Hot.Item[0].Name.Should().Be("Grand Austria Hotel");
        }

        [TestMethod]
        public void Deserialize_Guild()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml);

            //Act
            var result = _deserializer.Deserialize<Guild>(xml);

            //Assert
            result.Id.Should().Be(24);
            result.Name.Should().Be("The Dice Tower");
            result.Created.Should().Be("Thu, 14 Jun 2007 01:46:53 +0000");
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Category.Should().Be("podcast");
            result.Website.Should().Be("http://www.dicetower.com");
            result.Description.Should().StartWith("A forum for all Dice Tower fans.");
            result.Location.Address1.Should().Be("The Dice Tower");
            result.Location.Address2.Should().Be("3640 NE 1st St.");
            result.Location.City.Should().Be("Homestead");
            result.Location.StateOrProvince.Should().Be("FL");
            result.Location.PostalCode.Should().Be("33033");
            result.Location.Country.Should().Be("USA");
            result.Members.Count.Should().Be(11376);
            result.Members.Page.Should().Be(2);
            result.Members.Member[0].Name.Should().Be("269Hawkmoon");
            result.Members.Member[0].Date.Should().Be("Sun, 08 Mar 2015 04:35:14 +0000");
        }

        [TestMethod]
        public void Deserialize_Plays()
        {
            //Arrange
            var xml = XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml);

            //Act
            var result = _deserializer.Deserialize<PlayList>(xml);

            //Assert
            result.Should().NotBeNull();
            result.UserName.Should().Be("Jimmydm90");
            result.UserId.Should().Be(1014881);
            result.Total.Should().Be(1958);
            result.Page.Should().Be(1);
            result.TermsOfUse.Should().Be("https://boardgamegeek.com/xmlapi/termsofuse");
            result.Play.Count.Should().Be(3);
            result.Play[0].Id.Should().Be(60784259);
            result.Play[0].Date.Should().Be("2022-05-17");
            result.Play[0].Quantity.Should().Be(1);
            result.Play[0].Length.Should().Be(0);
            result.Play[0].Incomplete.Should().BeFalse();
            result.Play[0].NowInStats.Should().BeFalse();
            result.Play[0].Item.Name.Should().Be("Marvel Champions: The Card Game");
            result.Play[0].Item.ObjectType.Should().Be("thing");
            result.Play[0].Item.Id.Should().Be(285774);
            result.Play[0].Item.SubTypes.Count.Should().Be(1);
            result.Play[0].Item.SubTypes[0].Value.Should().Be("boardgame");
            result.Play[0].Comment.Should().Be("Hela default");
            result.Play[0].Players.Count.Should().Be(1);
            result.Play[0].Players[0].UserName.Should().Be("Jimmydm90");
            result.Play[0].Players[0].Id.Should().Be(0);
            result.Play[0].Players[0].Name.Should().Be("Jimmy");
            result.Play[0].Players[0].StartPosition.Should().Be("good");
            result.Play[0].Players[0].Color.Should().Be("Wolverine aggression*");
            result.Play[0].Players[0].Score.Should().Be("25");
            result.Play[0].Players[0].New.Should().BeFalse();
            result.Play[0].Players[0].Rating.Should().Be("0");
            result.Play[0].Players[0].Win.Should().BeTrue();
        }
    }
}
