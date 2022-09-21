namespace Bgg.Net.Common.Infrastructure.Http
{
    /// <summary>
    /// A wrapper around a <see cref="HttpClient"/>.
    /// </summary>
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string url);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
