using Bgg.Net.Common.Http;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.Resources
{
    /// <summary>
    /// Base Class for testing handlers.
    /// </summary>
    public abstract class HandlerTestBase
    {
        public Mock<IHttpClient> MockSuccessfulHttpClient()
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(XmlGenerator.GenerateBoardGameXmlString()),
            };

            var bggclientMock = new Mock<IHttpClient>();
            bggclientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));

            return bggclientMock;
        }
    }
}
