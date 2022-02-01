using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Resources.Things;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.Resources.Things
{
    [TestClass]
    public class ThingHandlerTests : HandlerTestBase
    {
        private IThingHandler? _handler;

        [TestMethod]
        public async Task GetThingsById_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateMultipleItemXmlString(), HttpStatusCode.OK);

            _handler = new ThingHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer(XmlGenerator.GenerateMultipleItemXmlString()).Object);

            //Act
            var result = await _handler.GetThingsById(new List<int> { 1, 2 });

            //Assert
            httpClientMock.Verify(x => x.GetAsync("thing?id=1,2"), Times.Once());
            result.Should().NotBeNull();
            result.Items.Count.Should().Be(2);
        }

        [TestMethod]
        public async Task GetThingById_Success()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK).Object, 
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Count.Should().Be(1);
            result.Items[0].Type.Should().Be("boardgame");
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetThingById_Failure()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(" ", HttpStatusCode.NotFound).Object, 
                Mock.Of<ILogger>(),
                MockIThingDeserializer(null, true).Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task GetThingById_DeserializationError()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(" ", HttpStatusCode.OK).Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer(null, null, new Exception("exception")).Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Items.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetThingsExtensible_Success()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK).Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1 } }
                }
            };

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Count.Should().Be(1);
            result.Items[0].Type.Should().Be("boardgame");
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetThingsExtensible_MultipleParams()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK).Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1 } },
                    { "versions", new List<int> { 1 }}
                }
            };

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Count.Should().Be(1);
            result.Items[0].Type.Should().Be("boardgame");
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetThingsExtensible_MultipleParams_Repeating()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK);

            _handler = new ThingHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1,2,3 } },
                    { "versions", new List<int> { 1 } },
                }
            };

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Count.Should().Be(1);
            result.Items[0].Type.Should().Be("boardgame");
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            httpClientMock.Verify(x => x.GetAsync("thing?id=1,2,3&versions=1"), Times.Once());
        }

        [TestMethod]
        public async Task GetThingsExtensible_BadParameter()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK).Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1 } },
                    { "badparameter", new List<int> { 1 } }
                }
            };

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Should().Contain("'badparameter' parameter is not supported.");
            result.Items.Should().BeNullOrEmpty();
        }
    }
}
