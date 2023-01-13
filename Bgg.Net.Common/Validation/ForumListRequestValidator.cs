using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

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

            if (!Enum.TryParse(forumListRequest.Type, true, out ItemType itemType))
            {
                validationResult.Errors.Add("Type was missing or invalid.");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
