using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    /// <summary>
    /// Validates ThingRequests.
    /// </summary>
    public class ThingRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var thingRequest = request as ThingRequest;
            var validationResult = new ValidationResult();

            if (!thingRequest.Id.Any())
            {
                validationResult.Errors.Add("Missing required element for ThingRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
