using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.RequestHandlers.Login;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Login
{
    [TestClass]
    public class BggLoginHandlerTests
    {
        private BggLoginHandler? _handler;

        [TestMethod]
        public async Task BggLoginHandler_LogsIn()
        {
            //Arrange
            var config = Configuration.InitConfiguration();
            var username = config["testUser:credentials:username"];
            var password = config["testUser:credentials:password"];

            _handler = new BggLoginHandler(new BggClient(), Mock.Of<ILogger<BggLoginHandler>>());

            //Act
            var result = await _handler.Login(username, password);

            //Assert
            result.Should().NotBeNull();
            result.Item.UserName.Should().Be($"bggusername={username}");
            result.Item.Password.Should().NotBeNullOrWhiteSpace();
            result.Item.SessionId.Should().NotBeNullOrWhiteSpace();
        }
    }
}
