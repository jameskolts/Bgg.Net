using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

        public Mock<IThingDeserializer> MockIThingDeserializer(bool? returnsNull = false, Exception? exception = null)
        {
            var deserializerMock = new Mock<IThingDeserializer>();

            if (exception != null)
            {
                deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                    .Throws(exception);
            }
            else if (returnsNull.HasValue && returnsNull.Value == true)
            {
                deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                    .Returns((Thing)null);
            }
            else
            {
                deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                    .Returns(new ThingDeserializer("//items/item", Mock.Of<ILogger>()).Deserialize(XmlGenerator.GenerateBoardGameXmlString()));
            }

            return deserializerMock;
        }
    }
}
