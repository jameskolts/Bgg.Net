using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Plays
{
    /// <summary>
    /// Handles plays requests to the Bgg API.
    /// </summary>
    public class PlaysHandler : RequestHandler, IPlaysHandler
    {
        public PlaysHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlays(PlaysRequest request)
        {
            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        public async Task<BggResult<PlayList>> GetPlaysByIdAndType(long id, ItemType type)
        {
            _logger.LogInformation("GetPlaysByIdAndType : {id}, {type}", id, type);

            var request = new PlaysRequest
            {
                Id = id,
                Type = type.ToString()
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserName(string userName)
        {
            _logger.LogInformation("GetPlaysByUserName : {userName}", userName);

            var request = new PlaysRequest
            {
                UserName = userName,
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndDate(string userName, DateOnly start, DateOnly end)
        {
            _logger.LogInformation("GetPlaysByUserNameAndDate : {userName}, {start}, {end}", userName, start, end);

            var request = new PlaysRequest
            {
                UserName = userName,
                MinDate = start,
                MaxDate = end
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndType(string userName, ItemType type, PlaysSubType? subType = null)
        {
            _logger.LogInformation("GetPlaysByUserNameAndType : {userName}, {type}, {subType}", userName, type, subType);

            var request = new PlaysRequest
            {
                UserName = userName,
                Type = type.ToString(),
                SubType = subType?.ToString()
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }
    }
}
