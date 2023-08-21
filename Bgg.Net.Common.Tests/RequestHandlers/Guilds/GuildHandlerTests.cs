using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Bgg.Net.Common.Tests.RequestHandlers.Guilds
{
    [TestClass]
    public class GuildHandlerTests : HandlerTestBase
    {
        private IGuildHandler? _handler;

        [TestMethod]
        public async Task GetGuild_Success()
        {
            //Arrange
            var request = new GuildRequest
            {
                Id = 2005,
                Members = true,
                Page = 2,
                Sort = "username"
            };

            MockValidatorFactory(new GuildRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetGuild(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/guild?id=2005&members=1&sort=username&page=2"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetGuildById()
        {
            //Arrange
            MockValidatorFactory(new GuildRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetGuildById(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/guild?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetGuildByIdWithMembers()
        {
            //Arrange
            MockValidatorFactory(new GuildRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetGuildByIdWithMembers(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/guild?id=100&members=1&sort=username&page=1"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
