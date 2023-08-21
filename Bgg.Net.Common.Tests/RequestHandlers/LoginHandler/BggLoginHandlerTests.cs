using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.RequestHandlers.Login;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Bgg.Net.Common.Tests.RequestHandlers.LoginHandler
{
    [TestClass]
    public class BggLoginHandlerTests : HandlerTestBase
    {
        private BggLoginHandler? _handler;

        [DataTestMethod]
        [DataRow("", "password")]
        [DataRow("username", "")]
        public async Task Login_ThrowsException_MissingParams(string username, string password)
        {
            //Arrange
            _handler = new BggLoginHandler(Mock.Of<IHttpClient>(), Mock.Of<ILogger<BggLoginHandler>>());

            //Act
            Func<Task> act = async () => { await _handler.Login(username, password); };

            //Asssert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task Login_Null_NotSuccessful()
        {
            //Arrange
            MockHttpClientPost("content", System.Net.HttpStatusCode.BadRequest);

            _handler = new BggLoginHandler(_httpClientMock.Object, Mock.Of<ILogger<BggLoginHandler>>());

            //Act
            var result = await _handler.Login("username", "password");

            //Assert
            result.Should().NotBeNull();
            result.Item.Should().BeNull();
            result.IsSuccessful.Should().BeFalse();
            result.HttpResponseCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
