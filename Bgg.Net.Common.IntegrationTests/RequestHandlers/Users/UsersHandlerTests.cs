using Bgg.Net.Common.RequestHandlers.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Users
{
    [TestClass]
    public class UserHandlerTests : HandlerTestBase
    {
        private UserHandler? _handler;

        [TestMethod]
        public async Task ThingHandler_GetsThings()
        {
            //Arrange
            var config = Configuration.InitConfiguration();
            var username = config["testUser:credentials:username"];

            _handler = _serviceProvider.GetRequiredService<UserHandler>();

            //Act
            var result = await _handler.GetUserByName(username);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
