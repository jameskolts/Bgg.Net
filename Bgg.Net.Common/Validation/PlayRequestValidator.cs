using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class PlayRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var playRequest = request as PlaysRequest;
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(playRequest.UserName) && !playRequest.Id.HasValue)
            {
                validationResult.Errors.Add($"Missing required element. Either username or id is required");
            }

            if (!string.IsNullOrWhiteSpace(playRequest.UserName) && playRequest.Id.HasValue)
            {
                validationResult.Errors.Add($"Only one of 'username' or 'id' is allowed for PlaysRequest");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
