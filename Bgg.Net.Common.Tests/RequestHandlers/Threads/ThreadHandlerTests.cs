using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Threads;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
                MinArticleDate = new DateTime(2020, 01, 01),
                MinArticleId = 1
            };

            MockValidatorFactory(new ThreadRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThread(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/thread?id=100&minarticleid=1&minarticledate=2020-01-01 00:00:00&count=1"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetThreadById_Success()
        {
            //Arrange
            MockValidatorFactory(new ThreadRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.ThreadXml), HttpStatusCode.OK);
            MockDeserializerFactory(new Thread { Id = 100 });

            _handler = new ThreadHandler(_deserializerFactory.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetThreadById(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/thread?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }
    }
}
