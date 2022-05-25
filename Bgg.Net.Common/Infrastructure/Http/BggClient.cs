namespace Bgg.Net.Common.Infrastructure.Http
{
    /// <summary>
    /// A wrapper around a HttpClient.
    /// </summary>
    public class BggClient : IHttpClient, IDisposable
    {
        readonly HttpClient httpClient;
        private bool disposed;

        /// <summary>
        /// Constructs a new instance of the BggClient with a default path.
        /// </summary>
        public BggClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.BGG_PATH)
            };
        }

        /// <inheritdoc cref="HttpClient.DeleteAsync(string)"/>
        public Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return httpClient.DeleteAsync(url);
        }

        /// <inheritdoc cref="HttpClient.GetAsync(string)"/>
        public virtual Task<HttpResponseMessage> GetAsync(string url)
        {
            return httpClient.GetAsync(url);
        }

        /// <inheritdoc cref="HttpClient.PostAsync(string, HttpContent)"/>
        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return httpClient.PostAsync(url, content);
        }

        /// <inheritdoc cref="HttpClient.PutAsync(string, HttpContent)"/>
        public Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return httpClient.PutAsync(url, content);
        }

        /// <inheritdoc cref="HttpClient.SendAsync(HttpRequestMessage)"/>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return httpClient.SendAsync(request);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
