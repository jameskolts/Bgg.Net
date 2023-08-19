using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.RequestHandlers.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers
{
    [TestClass]
    public class LoginHandlerTests
    {
        [TestMethod]
        public async Task LoginWIP()
        {
            var handler = new BggLoginHandler(new BggClient());
            var result = await handler.Login("JusticiarIV", "Godzilla");
        }
    }
}
