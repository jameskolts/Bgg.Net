using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Search;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Search
{
    [TestClass]
    public class SearchHandlerTests : HandlerTestBase
    {
        private ISearchHandler? _handler;

        [TestMethod]
        public async Task Search_Success()
        {
            //Arrange
            var request = new SearchRequest("ark nova")
            {
                Exact = true,
                Type = new List<string> { "boardgame", "boardgameexpansion" }
            };

            MockValidatorFactory(new SearchRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.SearchXml), HttpStatusCode.OK);
            MockDeserializerFactory(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.Search(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/search?query=ark nova&type=boardgame,boardgameexpansion&exact=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQuery_Success()
        {
            //Arrange
            MockValidatorFactory(new SearchRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockDeserializerFactory(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.SearchByQuery("ark nova");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/search?query=ark nova"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQueryAndType_Success()
        {
            //Arrange
            MockValidatorFactory(new SearchRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockDeserializerFactory(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.SearchByQueryAndType("ark nova", new List<SearchType> { SearchType.BoardGame, SearchType.BoardGameExpansion });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/search?query=ark nova&type=boardgame,boardgameexpansion"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQueryExact_Success()
        {
            //Arrange
            MockValidatorFactory(new SearchRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockDeserializerFactory(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.SearchByQueryExact("ark nova");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/search?query=ark nova&exact=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }
    }
}
