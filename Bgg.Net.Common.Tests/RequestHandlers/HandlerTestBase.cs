using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Serilog;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bgg.Net.Common.Infrastructure.Http;

namespace Bgg.Net.Common.Tests.Resources
{
    /// <summary>
    /// Base Class for testing handlers.
    /// </summary>
    public abstract class HandlerTestBase
    {
        public Mock<IHttpClient> MockHttpClientGet(string content, HttpStatusCode statusCode)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content),
            };

            var bggclientMock = new Mock<IHttpClient>();
            bggclientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));

            return bggclientMock;
        }

        public Mock<IBggDeserializer> MockBggDeserializer<T>(T? obj = null)
            where T : BggBase
        {
            var returnObject = obj;

            var mock = new Mock<IBggDeserializer>();
#pragma warning disable CS8604 // Possible null reference argument.
            mock.Setup(x => x.Deserialize<T>(It.IsAny<string>()))
                .Returns(returnObject);
#pragma warning restore CS8604 // Possible null reference argument.


            return mock;            
        }
    }
}
