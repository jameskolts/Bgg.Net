using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class ForumListRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var forumListRequest = request as ForumListRequest;
            var validationResult = new ValidationResult();

            if (forumListRequest.Id == default)
            {
                validationResult.Errors.Add($"Missing required element for ForumListRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
