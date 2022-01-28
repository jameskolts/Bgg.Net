using Bgg.Net.Common.Resources.Things;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.Resources.Things
{
    [TestClass]
    public class ThingHandlerTests : HandlerTestBase
    {
        private readonly IThingHandler _handler;

        public ThingHandlerTests()
        {            
            _handler = new ThingHandler(MockSuccessfulHttpClient().Object, Mock.Of<ILogger>());
        }

        [TestMethod]
        public async Task GetThingById_Success()
        {
            //Act
            var result = await _handler.GetThingById(1);

            //Assert
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Items.Count.Should().Be(1);
            result.Items[0].Type.Should().Be("boardgame");
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
