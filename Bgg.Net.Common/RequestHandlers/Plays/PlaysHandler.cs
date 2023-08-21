using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace Bgg.Net.Common.RequestHandlers.Plays
{
    /// <summary>
    /// Handles plays requests to the Bgg API.
    /// </summary>
    public class PlaysHandler : RequestHandler, IPlaysHandler
    {

        public PlaysHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlays(PlaysRequest request)
        {
            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        public async Task<BggResult<PlayList>> GetPlaysByIdAndType(long id, ItemType type)
        {
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
            var request = new PlaysRequest
            {
                UserName = userName,
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<PlayList>> GetPlaysByUserNameAndDate(string userName, DateOnly start, DateOnly end)
        {
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
            var request = new PlaysRequest
            {
                UserName = userName,
                Type = type.ToString(),
                SubType = subType?.ToString()
            };

            return await GetResourceFromRequestObject<PlayList>("plays", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<BggPlayLogResponse>> LogPlay(BggLoginCookie loginCookie, LogPlayRequest request)
        {
            var validator = _requestValidatorFactory.CreateRequestValidator("plays") as IPlayRequestValidator;

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BggResult<BggPlayLogResponse>
                {
                    IsSuccessful = false,
                    Errors = validationResult.Errors
                };
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json)
                .AddLoginCookie(loginCookie);

            var httpResponse = await _httpClient.PostAsync(Constants.BggLogPlayRoute, stringContent);
            return await BuildBggResult<BggPlayLogResponse>(httpResponse);
        }
    }
}
