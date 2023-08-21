using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Families;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.IntegrationTests.RequestHandlers.Family
{
    [TestClass]
    public class FamilyHandlerTests : HandlerTestBase
    {
        private FamilyHandler? _handler;

        [TestMethod]
        public async Task FamilyHandler_GetsFamily()
        {
            //Arrange
            var request = new FamilyRequest
            {
                Id = new List<long> { 1, 2, 3 },
            };

            _handler = _serviceProvider.GetRequiredService<FamilyHandler>();

            //Act
            var result = await _handler.GetFamily(request);

            //Assert
            result.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(3);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
