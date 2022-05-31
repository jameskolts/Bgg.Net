using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Plays;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

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
            MockBggDeserializer(
                new PlayList
                {
                    Play = new List<Play>
                    {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                    }
                });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlays(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user&mindate=2020-01-12"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserName_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByUserName("user");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndDate_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndDate("user", new DateOnly(2010, 01, 01), new DateOnly(2020, 05, 28));

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user&mindate=2010-01-01&maxdate=2020-05-28"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndId_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndId("user", 2500);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user&id=2500"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndTypeAndSubType_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndType("user", ItemType.Thing, PlaysSubType.BoardGame);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user&type=thing&subtype=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByUserNameAndType_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByUserNameAndType("user", ItemType.Thing);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?username=user&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }

        [TestMethod]
        public async Task GetPlaysByIdAndType_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);
            MockBggDeserializer(
               new PlayList
               {
                   Play = new List<Play>
                   {
                        new Play { Id = 1 },
                        new Play { Id = 2 },
                        new Play { Id = 3 }
                   }
               });

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysByIdAndType(2500, ItemType.Thing);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("plays?id=2500&type=thing"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Play.Count.Should().Be(3);
        }


        [TestMethod]
        public async Task GetPlaysExtensible_BadParameter()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"badParam", new List<string> { "1,2,3" } },
                }
            };

            MockValidatorFactory(new PlayRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.PlaysXml), HttpStatusCode.OK);

            _handler = new PlaysHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetPlaysExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().BeNull();
            result.Errors.Count.Should().Be(2);
            result.Errors.Should().Contain("'badParam' parameter is not supported for GetPlaysExtensible.");
            result.Item.Should().BeNull();
        }
    }
}
