using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class FamilyRequestValidator : IRequestValidator
    {
        /// <summary>
        /// Not implemented for FamilyRequests.
        /// </summary>
        public ValidationResult Validate(BggRequest request)
        {
            var familyRequest = request as FamilyRequest;
            var validationResult = new ValidationResult();

            if (!familyRequest.Id.Any())
            {
                validationResult.Errors.Add("Missing required element for FamilyRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}