using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class SearchRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var searchRequest = request as SearchRequest;
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(searchRequest.Query))
            {
                validationResult.Errors.Add("Missing required element for SearchRequest: query");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
