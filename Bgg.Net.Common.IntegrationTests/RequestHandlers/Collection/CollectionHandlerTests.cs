using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Collection;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Collection
{
    [TestClass]
    public class CollectionHandlerTests : HandlerTestBase
    {
        private CollectionHandler? _handler;

        [TestMethod]
        public async Task CollectionHandler_GetsCollection()
        {
            //Arrange
            var config = Configuration.InitConfiguration();
            var username = config["testUser:credentials:username"];

            var request = new CollectionRequest
            {
                UserName = username
            };

            _handler = _serviceProvider.GetRequiredService<CollectionHandler>();

            //Act
            var bggResult = await _handler.GetCollection(request);

            //Assert
            bggResult.Should().NotBeNull();
            bggResult.IsSuccessful.Should().BeTrue();
            bggResult.Errors.Should().BeNullOrEmpty();
            bggResult.Item.Should().NotBeNull();
            bggResult.Item.Items.Should().NotBeNullOrEmpty();
        }
    }
}
