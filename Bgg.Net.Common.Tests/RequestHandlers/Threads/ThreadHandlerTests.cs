using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Threads;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Threads
{
    [TestClass]
    public class ThreadHandlerTests : HandlerTestBase
    {
        private IThreadHandler? _handler;

        [TestMethod]
        public async Task GetThread_Success()
        {
            //Arrange
            var request = new ThreadRequest(100)
            {
                Count = 1,
                MinArticleDateTime = "2020-01-01",
                MinArticleId = 1
            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetThread(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thread?id=100&minarticleid=1&minarticledatetime=2020-01-01&count=1"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetThreadExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "100" } }
                }
            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetThreadExtensible(extension);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thread?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetThreadExtensible_BadParameter()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"badparam", new List<string> { "sam" } }
                }
            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetThreadExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Should().Contain("'badparam' parameter is not supported for GetThreadExtensible.");
            result.Item.Should().BeNull();
        }

        [TestMethod]
        public async Task GetThreadById_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetThreadById(100);

            //Asserrt
            _httpClientMock.Verify(x => x.GetAsync("thread?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }
    }
}
