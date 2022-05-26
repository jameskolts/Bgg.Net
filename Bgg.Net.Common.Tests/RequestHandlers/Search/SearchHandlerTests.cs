using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Search;
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

namespace Bgg.Net.Common.Tests.RequestHandlers.Search
{
    [TestClass]
    public class SearchHandlerTests : HandlerTestBase
    {
        private ISearchHandler _handler;

        [TestMethod]
        public async Task Search_Success()
        {
            //Arrange
            var request = new SearchRequest("ark nova")
            {
                Exact = true,
                Type = new List<SearchType> { SearchType.BoardGame, SearchType.BoardGameExpansion }
            };

            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            var bggDeserializerMock = MockBggDeserializer(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(bggDeserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.Search(request);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("search?query=ark nova&type=boardgame,boardgameexpansion&exact=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQuery_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            var bggDeserializerMock = MockBggDeserializer(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(bggDeserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.SearchByQuery("ark nova");

            //Assert
            httpClientMock.Verify(x => x.GetAsync("search?query=ark nova"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQueryAndType_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            var bggDeserializerMock = MockBggDeserializer(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(bggDeserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.SearchByQueryAndType("ark nova", new List<SearchType> { SearchType.BoardGame, SearchType.BoardGameExpansion});

            //Assert
            httpClientMock.Verify(x => x.GetAsync("search?query=ark nova&type=boardgame,boardgameexpansion"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchByQueryExact_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            var bggDeserializerMock = MockBggDeserializer(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(bggDeserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.SearchByQueryExact("ark nova");

            //Assert
            httpClientMock.Verify(x => x.GetAsync("search?query=ark nova&exact=1"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }

        [TestMethod]
        public async Task SearchExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"query", new List<string> { "ark nova" } },
                    {"type", new List<string> { "boardgame" } }
                }
            };

            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            var bggDeserializerMock = MockBggDeserializer(new SearchResultList { Total = 100 });

            _handler = new SearchHandler(bggDeserializerMock.Object, Mock.Of<ILogger>(), httpClientMock.Object);

            //Act
            var result = await _handler.SearchExtensible(extension);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("search?query=ark nova&type=boardgame"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Total.Should().Be(100);
        }
    }
}
