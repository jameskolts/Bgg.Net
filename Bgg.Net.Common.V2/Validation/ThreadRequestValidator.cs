using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class ThreadRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var threadRequest = request as ThreadRequest;
            var validationResult = new ValidationResult();

            if (threadRequest.Id == default)
            {
                validationResult.Errors.Add("Missing required element for ThreadRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
