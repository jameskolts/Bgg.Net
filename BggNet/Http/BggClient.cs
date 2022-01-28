namespace Bgg.Net.Common.Http
{
    public class BggClient : IHttpClient
    {
        HttpClient httpClient;

        /// <summary>
        /// Constructs a new instance of the BggClient with a default path.
        /// </summary>
        public BggClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.BGG_PATH);
        }             

        public Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return httpClient.DeleteAsync(url);
        }
                
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return httpClient.GetAsync(url);
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return httpClient.PostAsync(url, content);
        }
                

        public Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return httpClient.PutAsync(url, content);
        }
    }
}
