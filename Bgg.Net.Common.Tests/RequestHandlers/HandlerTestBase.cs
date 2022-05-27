﻿using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Moq;
using Serilog;
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

        public HandlerTestBase()
        {
            _httpClientMock = new Mock<IHttpClient>();
            _deserializerMock = new Mock<IBggDeserializer>();
            _loggerMock = new Mock<ILogger>();
        }

        public void MockHttpClientGet(string content, HttpStatusCode statusCode)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content),
            };

            _httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(responseMessage));
        }

        public void MockBggDeserializer<T>(T? obj = null)
            where T : BggBase
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _deserializerMock.Setup(x => x.Deserialize<T>(It.IsAny<string>()))
                .Returns(obj);
#pragma warning restore CS8604 // Possible null reference argument.           
        }
    }
}
