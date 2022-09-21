using Bgg.Net.Common.Infrastructure.Exceptions;
using System.Net;

namespace Bgg.Net.Common.Infrastructure.Http
{
    /// <summary>
    /// An implementation of IHttpClient that will attempt retries for collectionRequest.
    /// </summary>
    public class CollectionClient : ICollectionClient
    {
        private const int maxAttempts = 5;
        private readonly IHttpClient _bggClient;

        public CollectionClient(BggClient bggClient)
        {
            _bggClient = bggClient;
        }

        public Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return _bggClient.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpResponseMessage httpResponseMessage = null;

            for (int attempt = 0; attempt <= maxAttempts; attempt++)
            {
                httpResponseMessage = await _bggClient.GetAsync(url);

                if (httpResponseMessage.StatusCode != HttpStatusCode.Accepted)
                {
                    break;
                }

                await Task.Delay(250).ConfigureAwait(false);
            }

            if (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
                throw new AttemptsExceededException($"Exceeded Max attempts {maxAttempts} while querying: {url}.");

            return httpResponseMessage;
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return _bggClient.PostAsync(url, content);
        }

        public Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return _bggClient.PutAsync(url, content);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _bggClient.SendAsync(request);
        }
    }
}
