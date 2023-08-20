using Bgg.Net.Common.Infrastructure.Exceptions;
using Bgg.Net.Common.Infrastructure.Http;
using System.Net;

namespace Bgg.Net.Common.Tests.Infrastructure.Http
{
    [TestClass]
    public class CollectionClientTests
    {
        private ICollectionClient? _client;

        [TestMethod]
        public async Task GetAsync_WithRetries()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            httpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Accepted
                });

            _client = new CollectionClient(httpClient.Object);

            //Act
            Func<Task> f = async () => await _client.GetAsync("someUrl");

            //Assert
            await f.Should().ThrowAsync<AttemptsExceededException>();
            httpClient.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Exactly(6));
        }

        [TestMethod]
        public async Task GetAsync()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            httpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            _client = new CollectionClient(httpClient.Object);

            //Act
            var result = await _client.GetAsync("someUrl");

            //Assert
            httpClient.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public async Task PostAsync()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            _client = new CollectionClient(httpClient.Object);

            //Act
            var result = await _client.PostAsync("someurl", new StringContent("string"));

            //Assert
            httpClient.Verify(x => x.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            _client = new CollectionClient(httpClient.Object);

            //Act
            var result = await _client.DeleteAsync("someurl");

            //Assert
            httpClient.Verify(x => x.DeleteAsync(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task PutAsync()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            _client = new CollectionClient(httpClient.Object);

            //Act
            var result = await _client.PutAsync("someurl", new StringContent("string"));

            //Assert
            httpClient.Verify(x => x.PutAsync(It.IsAny<string>(), It.IsAny<HttpContent>()), Times.Once);
        }

        [TestMethod]
        public async Task SendAsync()
        {
            //Arrange
            var httpClient = new Mock<BggClient>();
            _client = new CollectionClient(httpClient.Object);

            //Act
            var result = await _client.SendAsync(new HttpRequestMessage());

            //Assert
            httpClient.Verify(x => x.SendAsync(It.IsAny<HttpRequestMessage>()), Times.Once);
        }
    }
}
