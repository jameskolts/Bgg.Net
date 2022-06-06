using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class UserRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var userRequest = request as UserRequest;
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(userRequest.Name))
            {
                validationResult.Errors.Add($"Missing required element for UserRequest: name");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
