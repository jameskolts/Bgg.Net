using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Bgg.Net.Common.Tests.RequestHandlers.Things
{
    [TestClass]
    public class ThingHandlerTests : HandlerTestBase
    {
        private IThingHandler? _handler;

        [TestMethod]
        public async Task GetThing_FailsValidation()
        {
            //Arrange
            var request = new ThingRequest()
            {
                Id = new List<long>(),
                Stats = true
            };

            MockValidatorFactory(new ThingRequestValidator());

            _handler = new ThingHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThing(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Never);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().BeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Item.Should().BeNull();
            result.Errors.Should().NotBeNullOrEmpty();
            result.Errors.Should().Contain("Missing required element for ThingRequest: id");
        }

        [TestMethod]
        public async Task GetThing_Success()
        {
            //Arrange
            var request = new ThingRequest()
            {
                Id = new List<long>
                {
                    1,2,3
                },
                Stats = true
            };

            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockDeserializerFactory(
               new ThingList
               {
                   Things = new List<Thing>
                   {
                        new Thing { Id = 1 },
                        new Thing { Id = 2 },
                        new Thing { Id = 3 }
                   }
               });

            _handler = new ThingHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThing(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/thing?id=1,2,3&stats=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Things.Count.Should().Be(3);
            result.Item.Things[0].Id.Should().Be(1);
            result.Item.Things[1].Id.Should().Be(2);
            result.Item.Things[2].Id.Should().Be(3);
        }

        [TestMethod]
        public async Task GetThingById_Success()
        {
            //Arrange           
            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockDeserializerFactory(
                new ThingList
                {
                    Things = new List<Thing>
                    {
                        new Thing { Id = 1 }
                    }
                });

            _handler = new ThingHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/thing?id=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Things.Count.Should().Be(1);
            result.Item.Things[0].Id.Should().Be(1);
        }

        [TestMethod]
        public async Task GetThingsById_Success()
        {
            //Arrange
            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockDeserializerFactory(
                new ThingList
                {
                    Things = new List<Thing>
                    {
                        new Thing { Id = 1 },
                        new Thing { Id = 2 },
                        new Thing { Id = 3 }
                    }
                });

            _handler = new ThingHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThingsById(new List<long> { 1, 2, 3 });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/thing?id=1,2,3"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Things.Count.Should().Be(3);
            result.Item.Things[0].Id.Should().Be(1);
            result.Item.Things[1].Id.Should().Be(2);
            result.Item.Things[2].Id.Should().Be(3);
        }

        [TestMethod]
        public async Task GetThingById_NoContent()
        {
            //Arrange
            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet("", HttpStatusCode.NotFound);
            _deserializerMock.Setup(x => x.Deserialize<ThingList>(It.IsAny<string>()))
                .Throws(new Exception("exception"));

            _handler = new ThingHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.Should().NotBeNull();
            result.Errors.Count.Should().Be(1);
            result.Item.Should().BeNull();
            result.IsSuccessful.Should().BeFalse();
        }
    }
}
