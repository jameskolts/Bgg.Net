using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using Bgg.Net.Common.RequestHandlers.Plays;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Newtonsoft.Json;
using System.Net;

namespace Bgg.Net.Common.Tests.RequestHandlers.Plays
{
    [TestClass]
    public class PlayHandlerTests : HandlerTestBase
    {
        private IPlaysHandler? _handler;

        [TestMethod]
        public async Task GetPlays()
        {
            //Arrange
            var request = new PlaysRequest
            {
                UserName = "user",
                MinDate = new DateOnly(2020, 1, 12)
            };

            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
                new PlayList
                {
                    Play = new List<Play>
                    {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                    }
                });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlays(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?username=user&mindate=2020-01-12"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserName_Success()
        {
            //Arrange
            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlaysByUserName("user");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?username=user"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndDate_Success()
        {
            //Arrange
            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndDate("user", new DateOnly(2010, 01, 01), new DateOnly(2020, 05, 28));

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?username=user&mindate=2010-01-01&maxdate=2020-05-28"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndTypeAndSubType_Success()
        {
            //Arrange
            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndType("user", ItemType.Thing, PlaysSubType.BoardGame);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?username=user&type=thing&subtype=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndType_Success()
        {
            //Arrange
            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndType("user", ItemType.Thing);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?username=user&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByIdAndType_Success()
        {
            //Arrange
            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetPlaysByIdAndType(2500, ItemType.Thing);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/plays?id=2500&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task LogPlay_Success()
        {
            //Arrange
            var request = new LogPlayRequest
            {
                ObjectId = 1,
            };

            var mockCookie = new BggLoginCookie
            {
                Password = "password",
                UserName = "username",
                SessionId = "session",
            };

            var mockResponse = new BggPlayLogResponse { PlayId = 100, NumPlays = 1, Html = "html" };
            var validatorMock = new Mock<IPlayRequestValidator>();
            validatorMock.Setup(x => x.Validate(It.IsAny<LogPlayRequest>()))
                .Returns(new ValidationResult(true));
            MockValidatorFactory(validatorMock.Object);
            MockHttpClientPost(JsonConvert.SerializeObject(mockResponse), HttpStatusCode.OK);
            MockDeserializerFactory(mockResponse);

            _handler = new PlaysHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.LogPlay(mockCookie, request);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.PlayId.Should().Be(100);
            result.Item.NumPlays.Should().Be(1);
            result.Item.Html.Should().Be("html");

            validatorMock.Verify(x => x.Validate(It.IsAny<LogPlayRequest>()), Times.Once);
            _httpClientMock.Verify(x => x.PostAsync(It.Is<string>(x => x == Constants.BggLogPlayRoute), It.IsAny<HttpContent>()), Times.Once);
            _deserializerMock.Verify(x => x.Deserialize<BggPlayLogResponse>(It.IsAny<string>()), Times.Once);
        }
    }
}
