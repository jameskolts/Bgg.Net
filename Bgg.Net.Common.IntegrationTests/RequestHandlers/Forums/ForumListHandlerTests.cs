using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Forums;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Forums
{
    [TestClass]
    public class ForumListHandlerTests : HandlerTestBase
    {
        private ForumListHandler? _handler;

        [TestMethod]
        public async Task ForumListHandler_GetsForumList()
        {
            //Arrange
            var request = new ForumListRequest
            {
                Id = 1,
                Type = "thing"
            };

            _handler = _serviceProvider.GetRequiredService<ForumListHandler>();

            //Act
            var result = await _handler.GetForumList(request);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Id.Should().Be(1);
        }
    }
}
