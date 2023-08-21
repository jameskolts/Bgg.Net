using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.RequestHandlers.Login;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Login
{
    [TestClass]
    public class BggLoginHandlerTests : HandlerTestBase
    {
        private IBggLoginHandler? _handler;

        [TestMethod]
        public async Task BggLoginHandler_LogsIn()
        {
            //Arrange
            var config = Configuration.InitConfiguration();
            var username = config["testUser:credentials:username"];
            var password = config["testUser:credentials:password"];

            _handler = _serviceProvider.GetRequiredService<IBggLoginHandler>();

            //Act
            var result = await _handler.Login(username, password);

            //Assert
            result.Should().NotBeNull();
            result.Item.UserNameCookie.Should().Be($"bggusername={username}");
            result.Item.PasswordCookie.Should().NotBeNullOrWhiteSpace();
            result.Item.SessionIdCookie.Should().NotBeNullOrWhiteSpace();
        }
    }
}
