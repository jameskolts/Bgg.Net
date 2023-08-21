using Bgg.Net.Common.RequestHandlers.HotItems;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.HotItems
{
    [TestClass]
    public class HotItemHandlerTests : HandlerTestBase
    {
        private HotItemHandler? _handler;

        [TestMethod]
        public async Task HotItemHandler_GetsHotItems()
        {
            //Arrange

            _handler = _serviceProvider.GetRequiredService<HotItemHandler>();

            //Act
            var result = await _handler.GetHotItemsByType(Types.HotItemType.BoardGame);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Item.Count.Should().Be(50);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
