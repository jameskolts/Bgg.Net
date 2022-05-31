using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Validation
{
    public class SearchRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var searchRequest = request as SearchRequest;
            _validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(searchRequest.Query))
            {
                _validationResult.Errors.Add($"Missing required element for {typeof(CollectionRequest)}: query");
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        public ValidationResult Validate(Extension extension)
        {
            _validationResult = new ValidationResult();

            foreach (var kvp in extension.Value)
            {
                switch (kvp.Key.ToLower())
                {
                    case "query":
                        ValidateParam(kvp.Key, kvp.Value, true, true, null);
                        break;
                    case "type":
                        ValidateSearchType(kvp.Key, kvp.Value);
                        break;
                    case "exact":
                        ValidateParam(kvp.Key, kvp.Value, false, true, IsValidBool);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for  SearchExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateSearchType(string paramName, List<string> values)
        {
            foreach (var value in values)
            {
                if (!Enum.TryParse(value, true, out SearchType _))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
        }
    }
}
