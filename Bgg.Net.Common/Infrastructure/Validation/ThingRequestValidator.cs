using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    /// <summary>
    /// Validates ThingRequests.
    /// </summary>
    public class ThingRequestValidator : RequestValidatorBase, IRequestValidator
    {

        public ValidationResult Validate(Extension extension)
        {
            var result = new ValidationResult();

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedThingQueryParameters.Contains(kvp.Key))
                {
                    result.Errors.Add($"'{kvp.Key}' parameter is not supported for GetThingExtensible.");                    
                }

                switch (kvp.Key.ToLower())
                {
                    case "versions":
                    case "videos":
                    case "stats":
                    case "marketplace":
                    case "comments":
                    case "ratingcomments":
                        ValidateBoolParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "page":
                        ValidateIntParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "type":
                        ValidateThingTypeParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "id":
                        ValidateListLongParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                }
            }

            result.IsValid = !result.Errors.Any();

            return result;
        }

        public ValidationResult Validate(BggRequest request)
        {
            var thingRequest = request as ThingRequest;
            var result = new ValidationResult();

            if (!thingRequest.Id.Any())
            {
                result.Errors.Add("Missing required element for ThingRequest: Id");
            }

            result.IsValid = !result.Errors.Any();

            return result;
        }

        private void ValidateThingTypeParam(string paramName, ValidationResult result, List<string> values)
        {
            foreach (var value in values)
            {
                if (!Enum.TryParse(value, true, out ThingType _))
                {
                    result.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
        }
    }
}
