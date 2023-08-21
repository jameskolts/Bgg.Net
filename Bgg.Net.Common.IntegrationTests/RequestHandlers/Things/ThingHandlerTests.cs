using Bgg.Net.Common.RequestHandlers.Things;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Things
{
    [TestClass]
    public class ThingHandlerTests : HandlerTestBase
    {
        private ThingHandler? _handler;

        [TestMethod]
        public async Task ThingHandler_GetsThings()
        {
            //Arrange

            _handler = _serviceProvider.GetRequiredService<ThingHandler>();

            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Things.Count.Should().Be(1);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
