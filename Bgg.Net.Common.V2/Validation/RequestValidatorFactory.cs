namespace Bgg.Net.Common.Validation
{
    public class RequestValidatorFactory : IRequestValidatorFactory
    {
        public IRequestValidator CreateRequestValidator(string requestType)
        {
            if (string.IsNullOrWhiteSpace(requestType))
            {
                throw new ArgumentNullException(nameof(requestType));
            }

            return requestType.ToLower() switch
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
                "forum" => new ForumRequestValidator(),
                "forumlist" => new ForumListRequestValidator(),
                _ => throw new NotImplementedException($"Unable to create validator for {requestType}"),
            };
        }
    }
}
