using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Plays
{
    /// <summary>
    /// Handles plays requests to the Bgg API.
    /// </summary>
    public class PlaysHandler : RequestHandler, IPlaysHandler
    {
        public PlaysHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient)
            : base(deserializer, logger, httpClient)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserName(string userName)
        {
            _logger.Information("GetPlaysByUserName : {userName}", userName);

            var httpResponseMessage = await _httpClient.GetAsync($"plays?username={userName}");

            return await BuildBggResult<PlayList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndDate(string userName, DateOnly start, DateOnly end)
        {
            _logger.Information("GetPlaysByUserNameAndDate : {userName}, {start}, {end}", userName, start, end);

            var httpResponseMessage = await _httpClient.GetAsync($"plays?username={userName}&mindate={start:YYYY-mm-dd}&maxdate={end:YYYY-mm-dd}");

            return await BuildBggResult<PlayList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndId(string userName, long id)
        {
            _logger.Information("GetPlaysByUserNameAndId : {userName}, {id}, {end}", userName, id);

            var httpResponseMessage = await _httpClient.GetAsync($"plays?username={userName}&id={id}");

            return await BuildBggResult<PlayList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndType(string userName, ItemType type, ItemSubType? subType = null)
        {
            _logger.Information("GetPlaysByUserNameAndType : {userName}, {type}, {subType}", userName, type, subType);

            var httpResponseMessage = await _httpClient.GetAsync($"plays?username={userName}&type={type.ToString().ToLower()}" +
                $"{(subType.HasValue ? $"&subtype={subType.ToString().ToLower()}" : string.Empty)}");

            return await BuildBggResult<PlayList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysExtensible(Extension extension)
        {
            return await GetResourceExtensible<PlayList>("plays", Constants.SupportedPlaysParameters, extension);
        }
    }
}
