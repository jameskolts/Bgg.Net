using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Collection
{
    [TestClass]
    public class CollectionHandlerTests : HandlerTestBase
    {
        private Mock<ICollectionClient> _collectionClientMock = new();
        private ICollectionHandler? _handler;

        [TestMethod]
        public async Task GetBriefCollectionByUserName_Success()
        {
            //Arrange

            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });
            MockValidatorFactory(new CollectionRequestValidator());

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetBriefCollectionByUserName("user");

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&brief=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetCollection_Success()
        {
            //Arrange
            var request = new CollectionRequest
            {
                UserName = "user",
                Version = false,
                Subtype = "boardgame",
                ExcludeSubtype = "videogame",
                Id = new List<long>
                {
                    1, 2, 3
                },
                Brief = true,
                Stats = true,
                Own = true,
                Played = false,
                Comment = true,
                Trade = true,
                Want = true,
                WishList = true,
                WishListPriority = 3,
                PreOrdered = true,
                WantToPlay = true,
                WantToBuy = true,
                PrevOwned = true,
                HasParts = true,
                WantParts = true,
                Rating = 3,
                MinRating = 3,
                MinBggRating = 3,
                BggRating = 3,
                MinPlays = 3,
                MaxPlays = 3,
                ShowPrivate = true,
                CollId = 125,
                ModifiedSince = new DateTime(2020, 01, 01)
            };

            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });
            MockValidatorFactory(new CollectionRequestValidator());

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetCollection(request);

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync(
                $"{Constants.XmlApi2Route}/collection?username=user&version=0&subtype=boardgame&excludesubtype=videogame&id=1,2,3&brief=1&stats=1&own=1&played=0&comment=1&trade=1&want=1&wishlist=1&wishlistpriority=3&preordered=1&wanttoplay=1&wanttobuy=1&prevowned=1&hasparts=1&wantparts=1&rating=3&minrating=3&minbggrating=3&bggrating=3&minplays=3&maxplays=3&showprivate=1&collid=125&modifiedsince=2020-01-01 00:00:00"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetCollectionByUserName_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetCollectionByUserName("user");

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetCollectionByUserNameAndId_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetCollectionByUserNameAndId("user", new List<long> { 1, 2 });

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&id=1,2"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetCollectionByUserNameAndType_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetCollectionByUserNameAndSubtype("user", CollectionSubType.RpgItem);

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&subtype=rpgitem"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetCollectionStatsByUserName_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetCollectionStatsByUserName("user");

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&stats=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetPlayedCollectionByUserName_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlayedCollectionByUserName("user");

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&played=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }

        [TestMethod]
        public async Task GetWishListCollectionByUserName_Success()
        {
            //Arrange
            MockValidatorFactory(new CollectionRequestValidator());
            _collectionClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage());
            MockBggDeserializer(new Models.Collection { TotalItems = 100 });

            _handler = new CollectionHandler(_deserializerMock.Object, _loggerMock.Object, _collectionClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetWishListCollectionByUserName("user");

            //Assert
            _collectionClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/collection?username=user&wishlist=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.TotalItems.Should().Be(100);
        }
    }
}
