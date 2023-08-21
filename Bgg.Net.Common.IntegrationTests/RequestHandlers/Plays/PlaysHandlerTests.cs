using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Login;
using Bgg.Net.Common.RequestHandlers.Plays;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Plays
{
    [TestClass]
    public class PlaysHandlerTests : HandlerTestBase
    {
        private PlaysHandler? _handler;

        [TestMethod]
        public async Task PlaysHandler_GetsPlays()
        {
            //Arrange
            var config = Configuration.InitConfiguration();

            _handler = _serviceProvider.GetRequiredService<PlaysHandler>();

            //Act
            var result = await _handler.GetPlaysByUserName(config["testUser:credentials:username"]);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.UserName.Should().BeEquivalentTo(config["testUser:credentials:username"]);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task PlaysHandler_LogsPlays() 
        {
            //Arrange
            var config = Configuration.InitConfiguration();

            var loginHandler = _serviceProvider.GetRequiredService<BggLoginHandler>();
            _handler = _serviceProvider.GetRequiredService<PlaysHandler>();

            //Act
            var cookieResult = await loginHandler.Login(config["testUser:credentials:username"], config["testUser:credentials:password"]);
            var result = await _handler.LogPlay(cookieResult.Item, new LogPlayRequest(1));

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Item.Should().NotBeNull();
        }
    }
}
