﻿using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using System.Net;

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
            MockValidatorFactory(new HotItemRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.HotXml), HttpStatusCode.OK);
            MockDeserializerFactory(
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

            _handler = new HotItemHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetHotItemsByType(HotItemType.BoardGame);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/hot?type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Item.Count.Should().Be(2);
            result.Item.Item[0].Id.Should().Be(1);
            result.Item.Item[1].Id.Should().Be(2);
        }

        [TestMethod]
        public async Task GetHot_Success()
        {
            //Arrange
            var request = new HotItemRequest("boardgame");

            MockValidatorFactory(new HotItemRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.HotXml), HttpStatusCode.OK);
            MockDeserializerFactory(
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

            _handler = new HotItemHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetHotItems(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/hot?type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Item.Item.Count.Should().Be(2);
            result.Item.Item[0].Id.Should().Be(1);
            result.Item.Item[1].Id.Should().Be(2);
        }
    }
}
