using Bgg.Net.Common.RequestHandlers.Threads;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Threads
{
    [TestClass]
    public class ThreadHandlerTests : HandlerTestBase
    {
        private ThreadHandler? _handler;

        [TestMethod]
        public async Task ThreadHandler_getsThread()
        {
            //Arrange

            _handler = _serviceProvider.GetRequiredService<ThreadHandler>();

            //Act
            var result = await _handler.GetThreadById(1);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Id.Should().Be(1);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
