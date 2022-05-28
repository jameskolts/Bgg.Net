﻿using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Things;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Things
{
    [TestClass]
    public class ThingHandlerTests : HandlerTestBase
    {
        private IThingHandler? _handler;

        [TestMethod]
        public async Task GetThing()
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
            MockBggDeserializer(
               new ThingList
               {
                   Things = new List<Thing>
                   {
                        new Thing { Id = 1 },
                        new Thing { Id = 2 },
                        new Thing { Id = 3 }
                   }
               });

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetThing(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thing?id=1,2,3&stats=1"), Times.Once);
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
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new ThingList
                {
                    Things = new List<Thing>
                    {
                        new Thing { Id = 1 }
                    }
                });

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thing?id=1"), Times.Once);
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
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new ThingList
                {
                    Things = new List<Thing>
                    {
                        new Thing { Id = 1 },
                        new Thing { Id = 2 },
                        new Thing { Id = 3 }
                    }
                });

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetThingsById(new List<long> { 1, 2, 3 });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thing?id=1,2,3"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Things.Count.Should().Be(3);
            result.Item.Things[0].Id.Should().Be(1);
            result.Item.Things[1].Id.Should().Be(2);
            result.Item.Things[2].Id.Should().Be(3);
        }

        [TestMethod]
        public async Task GetThingsExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string> { "1", "2", "3" } },
                    {"type", new List<string> { "boardgame" } }
                }
            };

            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new ThingList
                {
                    Things = new List<Thing>
                    {
                        new Thing { Id = 1 },
                        new Thing { Id = 2 },
                        new Thing { Id = 3 }
                    }
                });

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("thing?id=1,2,3&type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Things.Count.Should().Be(3);
            result.Item.Things[0].Id.Should().Be(1);
            result.Item.Things[1].Id.Should().Be(2);
            result.Item.Things[2].Id.Should().Be(3);
        }

        [TestMethod]
        public async Task GetThingsExtensible_BadParameter()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"badParam", new List<string> { "1,2,3" } },
                }
            };

            MockValidatorFactory(new ThingRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.BoardGameXml), HttpStatusCode.OK);
            _deserializerMock = new Mock<IBggDeserializer>();

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetThingsExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().BeNull();
            result.Errors.Count.Should().Be(1);
            result.Errors[0].Should().Be("'badParam' parameter is not supported for GetThingExtensible.");
            result.Item.Should().BeNull();
        }

        [TestMethod]
        public async Task GetThingById_NoContent()
        {
            //Arrange            
            MockHttpClientGet("", HttpStatusCode.NotFound);
            _deserializerMock.Setup(x => x.Deserialize<ThingList>(It.IsAny<string>()))
                .Throws(new Exception("exception"));

            _handler = new ThingHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

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
