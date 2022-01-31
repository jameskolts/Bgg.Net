using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Serilog;

namespace Bgg.Net.Common.Resources.Things
{
    /// <summary>
    /// Handles Thing requests to the BGG API.
    /// </summary>
    public class ThingHandler : IThingHandler
    {
        private readonly IHttpClient _client;
        private readonly ILogger _logger;
        private readonly IThingDeserializer _deserializer;

        /// <summary>
        /// Creates an instance of <see cref="ThingHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ThingHandler(IHttpClient httpClient, ILogger logger, IThingDeserializer deserializer)
        {
            _client = httpClient;
            _logger = logger;
            _deserializer = deserializer;
        }

        /// <summary>
        /// Gets a Thing by id.
        /// </summary>
        /// <param name="id">The id of the thing to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Thing"/>.</returns>
        public async Task<BggResult<Thing>> GetThingById(int id)
        {
            _logger.Information("GetThingById : {id}", id);

            var httpResponseMessage = await _client.GetAsync($"thing?id={id}");

            return await BuildBggResult(httpResponseMessage);
        }

        public async Task<BggResult<Thing>> GetThingsById(List<int> ids)
        {
            _logger.Information("GetThingById : {id}", ids);

            var queryString = $"thing?id=" + string.Join(',', ids);

            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        /// <summary>
        /// Gets a Thing by extensible parameters to allow support for additional query parameters.
        /// </summary>
        /// <param name="extension">The extension containing the query paramters.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Thing"/>.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public async Task<BggResult<Thing>> GetThingsExtensible(Extension extension)
        {
            _logger.Information("GetThingsExtensible : {extensions}", extension.ToString());

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedQueryParameters.Contains(kvp.Key))
                {
                    throw new NotSupportedException($"'{kvp.Key}' parameter is not supported.");
                }
            }

            string queryString = "thing?" + string.Join("&", extension.Value.Select(x => x.Key + "=" + x.Value));
            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        private async Task<BggResult<Thing>> BuildBggResult(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var bggResult = new BggResult<Thing>();

            try
            {
                bggResult.Items = _deserializer.Deserialize(responseString);
            }
            catch (Exception exception)
            {
                var errorString = $"Error during deserialization. {exception.Message}";
                _logger.Error(exception, errorString);
                bggResult.Errors.Add(errorString);
            }

            bggResult.IsSuccessful = httpResponse.IsSuccessStatusCode && !bggResult.Errors.Any();
            bggResult.HttpResponseCode = httpResponse.StatusCode;

            return bggResult;
        }
    }
}
