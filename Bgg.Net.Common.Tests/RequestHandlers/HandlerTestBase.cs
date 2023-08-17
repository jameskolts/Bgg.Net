using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Validation;
using Moq;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers
{
    /// <summary>
    /// Base Class for testing handlers.
    /// </summary>
    public abstract class HandlerTestBase
    {
        protected Mock<IHttpClient> _httpClientMock { get; set; }
        protected Mock<IBggDeserializer> _deserializerMock { get; set; }
        protected Mock<ILogger> _loggerMock { get; set; }
        protected Mock<IRequestValidatorFactory> _validatorFactory { get; set; }
        protected Mock<QueryBuilder> _queryBuilder { get; set; }

        public HandlerTestBase()
        {
            _httpClientMock = new Mock<IHttpClient>();
            _deserializerMock = new Mock<IBggDeserializer>();
            _loggerMock = new Mock<ILogger>();
            _validatorFactory = new Mock<IRequestValidatorFactory>();
            _queryBuilder = new Mock<QueryBuilder>() {  CallBase = true };
        }

        public void MockHttpClientGet(string content, HttpStatusCode statusCode)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content),
            };

            _httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(responseMessage);
        }

        public void MockBggDeserializer<T>(T? obj = null)
            where T : BggBase
        {
            _deserializerMock.Setup(x => x.Deserialize<T>(It.IsAny<string>()))
                .Returns(obj);       
        }

        public void MockValidatorFactory(IRequestValidator validator)
        {
            _validatorFactory.Setup(x => x.CreateRequestValidator(It.IsAny<string>()))
                .Returns(validator);
        }
    }
}
