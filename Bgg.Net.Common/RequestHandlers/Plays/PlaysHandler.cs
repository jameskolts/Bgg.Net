using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
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
        private readonly IPlayRequestValidator _validator;

        public PlaysHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder/*, IPlayRequestValidator validator*/)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
            //_validator = validator;
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
            //TODO: implement validation
            //var validationResult = _validator.Validate(request);

            //if (!validationResult.IsValid)
            //{
            //    return new BggResult<BggPlayLogResponse>
            //    {

            //        IsSuccessful = false,
            //        Errors = validationResult.Errors
            //    };
            //}

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json)
                .AddLoginCookie(loginCookie);

            return await PostRequest<BggPlayLogResponse>(Constants.BggLogPlayRoute, stringContent);
        }
    }
}
