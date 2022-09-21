using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class ForumRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var forumRequest = request as ForumRequest;
            var validationResult = new ValidationResult();

            if (forumRequest.Id == default)
            {
                validationResult.Errors.Add($"Missing required element for ForumRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
