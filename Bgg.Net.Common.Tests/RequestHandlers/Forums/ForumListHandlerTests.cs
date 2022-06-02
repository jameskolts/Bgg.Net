using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Forums;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Forums
{
    [TestClass]
    public class ForumListHandlerTests : HandlerTestBase
    {
        private IForumListHandler? _handler;

        [TestMethod]
        public async Task GetForumListByIdAndType_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumListXml), HttpStatusCode.OK);
            MockBggDeserializer(new ForumList { Id = 100 });

            _handler = new ForumListHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetForumListByIdAndType(100, ItemType.Thing);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("forumlist?id=100&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetForumList_Success()
        {
            //Arrange
            var request = new ForumListRequest
            {
                Id = 100,
            };

            MockValidatorFactory(new ForumListRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ForumListXml), HttpStatusCode.OK);
            MockBggDeserializer(new ForumList { Id = 100 });

            _handler = new ForumListHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetForumList(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("forumlist?id=100&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Id.Should().Be(100);
        }
    }
}
