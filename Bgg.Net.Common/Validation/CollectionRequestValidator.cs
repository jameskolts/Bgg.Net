using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class CollectionRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var collectionRequest = request as CollectionRequest;
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(collectionRequest.UserName))
            {
                validationResult.Errors.Add($"Missing required element for CollectionRequest: userName");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
