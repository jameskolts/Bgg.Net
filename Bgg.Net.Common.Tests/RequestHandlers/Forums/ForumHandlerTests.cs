using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Forums
{
    [TestClass]
    public class ForumHandlerTests : HandlerTestBase
    {
        private IForumHandler? _handler;

        [TestMethod]
        public async Task GetForumById_Success()
        {
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml), HttpStatusCode.OK);
            MockBggDeserializer(new Forum { Id = 100 });

            _handler = new ForumHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetForumById(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("forum?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetForumByIdAndPage_Success()
        {
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumXml), HttpStatusCode.OK);
            MockBggDeserializer(new Forum { Id = 100 });

            _handler = new ForumHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetForumByIdAndPage(100, 2);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("forum?id=100&page=2"), Times.Once);
            result.Should().NotBeNull();
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }
    }
}
