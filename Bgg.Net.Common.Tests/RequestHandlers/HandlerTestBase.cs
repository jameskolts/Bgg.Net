using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Net.Http;

namespace Bgg.Net.Common.Tests.RequestHandlers
{
    /// <summary>
    /// Base Class for testing handlers.
    /// </summary>
    public abstract class HandlerTestBase
    {
        protected Mock<IHttpClient> _httpClientMock { get; set; }
        protected Mock<IDeserializer> _deserializerMock { get; set; }
        protected Mock<ILogger> _loggerMock { get; set; }
        protected Mock<IRequestValidatorFactory> _validatorFactory { get; set; }
        protected Mock<IDeserializerFactory> _deserializerFactory { get; set; }
        protected Mock<QueryBuilder> _queryBuilder { get; set; }

        public HandlerTestBase()
        {
            _httpClientMock = new Mock<IHttpClient>();
            _deserializerMock = new Mock<IDeserializer>();
            _deserializerFactory = new Mock<IDeserializerFactory>();
            _loggerMock = new Mock<ILogger>();
            _validatorFactory = new Mock<IRequestValidatorFactory>();
            _queryBuilder = new Mock<QueryBuilder>() { CallBase = true };
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

        public void MockHttpClientPost(string content, HttpStatusCode statusCode)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            };

            _httpClientMock.Setup(x => x.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(responseMessage);                
        }

        public void MockDeserializer<T>(T? obj = null)
            where T : class
        {
            _deserializerMock.Setup(x => x.Deserialize<T>(It.IsAny<string>()))
                .Returns(obj);
        }

        public void MockDeserializerFactory<T>(T? obj = null)
            where T : class
        {
            MockDeserializer(obj);
            _deserializerFactory.Setup(x => x.Create(It.IsAny<DeserializationFormat>()))
                .Returns(_deserializerMock.Object);
            _deserializerFactory.Setup(x => x.Create(It.IsAny<Type>()))
                .Returns(_deserializerMock.Object);
        }

        public void MockValidatorFactory(IRequestValidator validator)
        {
            _validatorFactory.Setup(x => x.CreateRequestValidator(It.IsAny<string>()))
                .Returns(validator);
        }
    }
}
