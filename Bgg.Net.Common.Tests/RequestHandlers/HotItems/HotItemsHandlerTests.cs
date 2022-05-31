using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.HotItems
{
    [TestClass]
    public class HotItemsHandlerTests : HandlerTestBase
    {
        private IHotItemsHandler? _handler;

        [TestMethod]
        public async Task GetHotItemsByType_Success()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.HotXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new HotItemList
                {
                    Item = new List<HotItem>
                    {
                        new HotItem
                        {
                            Id = 1,
                        },
                        new HotItem
                        {
                            Id = 2
                        }
                    }
                });

            _handler = new HotItemHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetHotItemsByType(HotItemType.BoardGame);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("hot?type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Item.Count.Should().Be(2);
            result.Item.Item[0].Id.Should().Be(1);
            result.Item.Item[1].Id.Should().Be(2);
        }

        [TestMethod]
        public async Task GetHotItemsExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"type", new List<string> { "boardgame" } }
                }
            };

            MockValidatorFactory(new HotItemRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.HotXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new HotItemList
                {
                    Item = new List<HotItem>
                    {
                        new HotItem
                        {
                            Id = 1,
                        },
                        new HotItem
                        {
                            Id = 2
                        }
                    }
                });

            _handler = new HotItemHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetHotItemsExtensible(extension);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("hot?type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Item.Count.Should().Be(2);
            result.Item.Item[0].Id.Should().Be(1);
            result.Item.Item[1].Id.Should().Be(2);
        }

        [TestMethod]
        public async Task GetHotItemsExtensible_BadParam()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"type", new List<string> { "boardgame" } },
                    {"badParam", new List<string> { "boardgame" } }
                }
            };

            MockValidatorFactory(new HotItemRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.HotXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new HotItemList
                {
                    Item = new List<HotItem>
                    {
                        new HotItem
                        {
                            Id = 1,
                        },
                        new HotItem
                        {
                            Id = 2
                        }
                    }
                });

            _handler = new HotItemHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetHotItemsExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().BeNull();
            result.Errors.Count.Should().Be(1);
            result.Errors[0].Should().Be("'badParam' parameter is not supported for GetHotItemsExtensible.");
            result.Item.Should().BeNull();
        }
    }
}
