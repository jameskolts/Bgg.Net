using Bgg.Net.Common.Infrastructure.Validation;

namespace Bgg.Net.Common.Validation
{
    public class RequestValidatorFactory : IRequestValidatorFactory
    {
        public IRequestValidator CreateRequestValidator(string requestType)
        {
            return requestType switch
            {
                "thing" => new ThingRequestValidator(),
                "family" => new FamilyRequestValidator(),
                "collection" => new CollectionRequestValidator(),
                "guild" => new GuildRequestValidator(),
                "hot" => new HotItemRequestValidator(),
                "plays" => new PlayRequestValidator(),
                "search" => new SearchRequestValidator(),
                "thread" => new ThreadRequestValidator(),
                "user" => new UserRequestValidator(),
                _ => throw new NotImplementedException($"Unable to create validator for {requestType}"),
            };
        }
    }
}
