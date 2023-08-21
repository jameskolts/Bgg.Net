using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Guilds
{
    [TestClass]
    public class GuildHandlerTests : HandlerTestBase
    {
        private GuildHandler? _handler;

        [TestMethod]
        public async Task GuildHandler_GetsGuild()
        {
            //Arrange
            var request = new GuildRequest
            {
                Id = 1
            };

            _handler = _serviceProvider.GetRequiredService<GuildHandler>();

            //Act
            var result = await _handler.GetGuild(request);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Id.Should().Be(1);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
