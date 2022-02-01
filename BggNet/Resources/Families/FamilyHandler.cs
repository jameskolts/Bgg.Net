using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Serilog;

namespace Bgg.Net.Common.Resources.Families
{
    /// <summary>
    /// Handles Family requests to the BGG API
    /// </summary>
    public class FamilyHandler : IFamilyHandler
    {
        private readonly IHttpClient _client;
        private readonly ILogger _logger;
        private readonly IFamilyDeserializer _deserializer;

        public FamilyHandler(IHttpClient client, ILogger logger, IFamilyDeserializer deserializer)
        {
            _client = client;
            _logger = logger;
            _deserializer = deserializer;
        }

        /// <inheritdoc/>
        public async Task<BggResult<Family>> GetFamilyById(int id)
        {
            _logger.Information("GetFamilyById : {id}", id);

            var httpResponseMessage = await _client.GetAsync($"family?id={id}");

            return await BuildBggResult(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Family>> GetFamilyByIds(List<int> ids)
        {
            _logger.Information("GetFamilyByIds : {id}", ids);

            var queryString = $"family?id=" + string.Join(',', ids);

            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Family>> GetFamilyByIdsAndType(List<int> ids, List<FamilyType> types)
        {
            _logger.Information("GetFamilyByIdsAndType : {id}, {types}", ids, types);

            var queryString = $"family?id={string.Join(',', ids)}&type={string.Join(',', types).ToLower()}";

            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Family>> GetFamilyExtensible(Extension extension)
        {
            _logger.Information("GetFamilyExtensible : {extensions}", extension);

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedFamilyQueryParameters.Contains(kvp.Key))
                {
                    string errorMessage = $"'{kvp.Key}' parameter is not supported.";
                    _logger.Error(errorMessage);

                    return new BggResult<Family>
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { errorMessage }
                    };
                }
            }

            string queryString = "family?" + string.Join("&", extension.Value.Select(x => x.Key + "=" + string.Join(',', x.Value)));
            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        private async Task<BggResult<Family>> BuildBggResult(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var bggResult = new BggResult<Family>();

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
