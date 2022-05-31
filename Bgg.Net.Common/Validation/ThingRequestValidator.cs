using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Validation
{
    /// <summary>
    /// Validates ThingRequests.
    /// </summary>
    public class ThingRequestValidator : RequestValidatorBase, IRequestValidator
    {

        public ValidationResult Validate(Extension extension)
        {
            _validationResult = new ValidationResult();

            foreach (var kvp in extension.Value)
            {
                switch (kvp.Key.ToLower())
                {
                    case "versions":
                    case "videos":
                    case "stats":
                    case "marketplace":
                    case "comments":
                    case "ratingcomments":
                        ValidateParam(kvp.Key, kvp.Value, false, true, IsValidBool);
                        break;
                    case "page":
                        ValidateInt(kvp.Key, kvp.Value, false, true, 1, int.MaxValue);
                        break;
                    case "type":
                        ValidateThingTypeParam(kvp.Key, kvp.Value);
                        break;
                    case "id":
                        ValidateParam(kvp.Key, kvp.Value, true, false, IsValidLong);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetThingExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        public ValidationResult Validate(BggRequest request)
        {
            var thingRequest = request as ThingRequest;
            _validationResult = new ValidationResult();

            if (!thingRequest.Id.Any())
            {
                _validationResult.Errors.Add("Missing required element for ThingRequest: Id");
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateThingTypeParam(string paramName, List<string> values)
        {
            foreach (var value in values)
            {
                if (!Enum.TryParse(value, true, out ThingType _))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
        }
    }
}
