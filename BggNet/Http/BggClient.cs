namespace Bgg.Net.Common.Http
{
    public class BggClient : HttpClient
    {

        /// <summary>
        /// Constructs a new instance of the BggClient with a default path.
        /// </summary>
        public BggClient()
        {
            BaseAddress = new Uri(Constants.BGG_PATH);
        }

        /// <summary>
        /// Constructs a new instance of the BggClient with the given base address.
        /// </summary>
        public BggClient(string baseAddress)
        {
            BaseAddress = new Uri(baseAddress);
        }

        /// <summary>
        /// Constructs a new instance of the BggClient with the given base address.
        /// </summary>
        public BggClient(Uri baseUri)
        {
            BaseAddress = baseUri;
        }
    }
}
