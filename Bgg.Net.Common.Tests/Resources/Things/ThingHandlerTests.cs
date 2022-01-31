using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Resources.Things;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using FluentAssertions;
using Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
                MockIThingDeserializer(true).Object);

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
                MockIThingDeserializer(null, new Exception("exception")).Object);

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
                Value = new Dictionary<string, int>
                {
                    { "id", 1 }
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
                Value = new Dictionary<string, int>
                {
                    { "id", 1 },
                    { "versions", 1 }
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
        public async Task GetThingsExtensible_BadParameter()
        {
            //Arrange
            _handler = new ThingHandler(
                MockHttpClientGet(XmlGenerator.GenerateBoardGameXmlString(), HttpStatusCode.OK).Object,
                Mock.Of<ILogger>(),
                MockIThingDeserializer().Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, int>
                {
                    { "id", 1 },
                    { "badparameter", 1 }
                }
            };

            //Act
            Func<Task> f = async () => await _handler.GetThingsExtensible(extension);

            //Assert
            await f.Should().ThrowAsync<NotSupportedException>().WithMessage("'badparameter' parameter is not supported.");
        }
    }
}
