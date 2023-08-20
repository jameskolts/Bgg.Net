using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.RequestHandlers.Login;
using Bgg.Net.Common.RequestHandlers.Plays;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers
{
    [TestClass]
    public class LoginHandlerTests
    {
        //TODO Integreation test, remove this.
        [TestMethod]
        public async Task LoginWIP()
        {
            var handler = new BggLoginHandler(new BggClient(), Mock.Of<ILogger<BggLoginHandler>>());
            var cookie = await handler.Login("JusticiarIV", "Godzilla");

            var playHandler = new PlaysHandler(Mock.Of<IDeserializerFactory>(), Mock.Of<ILogger>(), new BggClient(), Mock.Of<IRequestValidatorFactory>(), Mock.Of<IQueryBuilder>());
            var logplayResult = await playHandler.LogPlay(cookie, new Models.Requests.LogPlayRequest
            {
                Ajax = 1,
                ObjectType = "thing",
                Action = "save",
                Quantity = 1,
                Length = 10,
                ObjectId = 342942,
                PlayDate = DateTime.Now,
                Location = "internet",
                Incomplete = false,
                Comments = "a comment",
                Players = new System.Collections.Generic.List<Models.Bgg.Player>
                {
                    new Models.Bgg.Player
                    {
                        Name ="Jimbo"
                    }
                }
            });
        }
    }
}
