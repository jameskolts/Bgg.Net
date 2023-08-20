using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Validation;
using System.Net;

namespace Bgg.Net.Common.Tests.RequestHandlers.Forums
{
    [TestClass]
    public class ForumHandlerTests : HandlerTestBase
    {
        private IForumHandler? _handler;

        [TestMethod]
        public async Task GetForumById_Success()
        {
            //Arrange
            MockValidatorFactory(new ForumRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Forum { Id = 100 });

            _handler = new ForumHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetForumById(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/forum?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetForumByIdAndPage_Success()
        {
            //Arrange
            MockValidatorFactory(new ForumRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Forum { Id = 100 });

            _handler = new ForumHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetForumByIdAndPage(100, 2);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/forum?id=100&page=2"), Times.Once);
            result.Should().NotBeNull();
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetForum_Success()
        {
            //Arrange
            var request = new ForumRequest
            {
                Id = 100,
            };

            MockValidatorFactory(new ForumRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Forum { Id = 100 });

            _handler = new ForumHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetForum(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/forum?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Id.Should().Be(100);
        }
    }
}
