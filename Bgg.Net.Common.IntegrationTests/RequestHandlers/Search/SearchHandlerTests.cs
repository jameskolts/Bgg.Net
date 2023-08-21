using Bgg.Net.Common.RequestHandlers.Search;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Search
{
    [TestClass]
    public class SearchHandlerTests : HandlerTestBase
    {
        private SearchHandler? _handler;

        [TestMethod]
        public async Task SearchHandler_Searches()
        {
            //Arrange

            _handler = _serviceProvider.GetRequiredService<SearchHandler>();

            //Act
            var result = await _handler.SearchByQuery("monopoly");

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.HttpResponseCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Item.Item.Should().NotBeNullOrEmpty();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
