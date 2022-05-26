using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.RequestHandlers.Threads;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Tests.RequestHandlers.Threads
{
    [TestClass]
    public class ThreadHandlerTests : HandlerTestBase
    {
        private IThreadHandler _handler;

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

            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            var deserializerMock = MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(deserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.GetThread(request);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("thread?id=100&minarticleid=1&minarticledatetime=2020-01-01&count=1"), Times.Once);
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

            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            var deserializerMock = MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(deserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.GetThreadExtensible(extension);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("thread?id=100"), Times.Once);
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

            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            var deserializerMock = MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(deserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

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
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            var deserializerMock = MockBggDeserializer(new Thread { Id = 100 });

            _handler = new ThreadHandler(deserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.GetThreadById(100);

            //Asserrt
            httpClientMock.Verify(x => x.GetAsync("thread?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }
    }
}
