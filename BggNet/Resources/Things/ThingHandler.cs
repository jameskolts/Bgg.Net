using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.Resources.Things
{
    public class ThingHandler : IThingHandler
    {
        private readonly BggClient _client;
        private readonly ILogger _logger;
        private readonly IThingDeserializer _deserializer;

        public ThingHandler(BggClient bggClient, ILogger logger)
        {
            _client = bggClient;
            _logger = logger;
            _deserializer = new ThingDeserializer("//items/item", logger);
        }

        public async Task<BggResult<Thing>> GetThingById(int id)
        {
            _logger.LogInformation("GetThingById : {id}", id);

            var httpResponseMessage = await _client.GetAsync($"thing?id={id}");

            return await BuildBggResult(httpResponseMessage);
        }

        public async Task<BggResult<Thing>> GetThingsExtensible(Extension extensions)
        {
            _logger.LogInformation("GetThingsExtensible : {extensions}", extensions);

            foreach (var kvp in extensions.Value)
            {
                if (!Constants.SupportedQueryParameters.Contains(kvp.Key))
                {
                    throw new NotSupportedException($"'{kvp.Key}' parameter is not supported.");
                }
            }

            string queryString = "thing?" + string.Join("&", extensions.Value.Select(x => x.Key + "=" + x.Value));
            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        public Task<BggResult<Thing>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        private async Task<BggResult<Thing>> BuildBggResult(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var bggResult = new BggResult<Thing>();

            try
            {
                var thingResponse = _deserializer.Deserialize(responseString);
                bggResult.Items.Add(thingResponse);
            }
            catch (Exception exception)
            {
                var errorString = $"Error during deserialization. {exception.Message}";
                _logger.LogError(exception, errorString);
                bggResult.Errors.Add(errorString);
            }

            bggResult.IsSuccessful = httpResponse.IsSuccessStatusCode && !bggResult.Errors.Any();
            bggResult.HttpResponseCode = httpResponse.StatusCode;

            return bggResult;
        }
    }
}
