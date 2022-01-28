namespace Bgg.Net.Common.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string url);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
    }
}
