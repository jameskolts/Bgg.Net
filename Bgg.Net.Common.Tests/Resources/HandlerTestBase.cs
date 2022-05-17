using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Serilog;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            mock.Setup(x => x.Deserialize<T>(It.IsAny<string>()))
                .Returns(returnObject);


            return mock;            
        }

        /// <summary>
        /// Mocks a Thing Deserializer and it's response.
        /// </summary>
        /// <param name="resultString">The xmlString to parse and return as the mocked result. </param>
        /// <param name="returnsNull">If the deserializer should return null.</param>
        /// <param name="exception">The exception the deserializer should throw.</param>
        /// <returns></returns>
        public Mock<IThingDeserializer> MockIThingDeserializer(string? resultString = null, bool? returnsNull = false, Exception? exception = null)
        {
            var deserializerMock = new Mock<IThingDeserializer>();

            if (exception != null)
            {
                deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                    .Throws(exception);
            }
            else if (returnsNull.HasValue && returnsNull.Value == true)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                    .Returns((List<Thing>)null);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            }
            else
            {
                if (string.IsNullOrEmpty(resultString))
                {
                    deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                        .Returns(new ThingDeserializer(Mock.Of<ILogger>()).Deserialize(XmlGenerator.GenerateBoardGameXmlString()));
                }
                else
                {
                    deserializerMock.Setup(x => x.Deserialize(It.IsAny<string>()))
                        .Returns(new ThingDeserializer(Mock.Of<ILogger>()).Deserialize(resultString));
                }
            }

            return deserializerMock;
        }
    }
}
