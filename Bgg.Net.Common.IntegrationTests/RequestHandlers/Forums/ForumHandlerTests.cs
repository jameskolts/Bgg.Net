using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Forums;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Forums
{
    [TestClass]
    public class ForumHandlerTests : HandlerTestBase
    {
        private ForumHandler? _handler;

        [TestMethod]
        public async Task ForumHandler_GetsForum()
        {
            //Arrange
            var request = new ForumRequest(2);

            _handler = _serviceProvider.GetRequiredService<ForumHandler>();

            //Act
            var result = await _handler.GetForum(request);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Should().NotBeNull();
            result.Item.Id.Should().Be(2);
        }
    }
}
