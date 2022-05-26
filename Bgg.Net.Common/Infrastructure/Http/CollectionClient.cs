using Bgg.Net.Common.Infrastructure.Exceptions;
using System.Net;

namespace Bgg.Net.Common.Infrastructure.Http
{
    /// <summary>
    /// An implementation of IHttpClient that will attempt retries for collectionRequest.
    /// </summary>
    public class CollectionClient : BggClient, ICollectionClient
    {
        private const int maxAttempts = 5;

        public async override Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpResponseMessage httpResponseMessage = null;

            for (int attempt = 0; attempt <= maxAttempts; attempt++)
            {
                httpResponseMessage = await base.GetAsync(url);

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
    }
}
