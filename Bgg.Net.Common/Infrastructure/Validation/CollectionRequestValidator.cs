using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class CollectionRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var collectionRequest = request as CollectionRequest;
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(collectionRequest.UserName))
            {
                result.Errors.Add("Missing required element for CollectionRequest: userName");
            }

            result.IsValid = !result.Errors.Any();

            return result;
        }

        public ValidationResult Validate(Extension extension)
        {
            var result = new ValidationResult();

            if (!extension.Value.ContainsKey("username"))
            {
                result.Errors.Add("Missing required element for CollectionRequest: userName");
            }

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedCollectionParameters.Contains(kvp.Key))
                {
                    result.Errors.Add($"'{kvp.Key}' parameter is not supported for GetCollectionExtensible.");
                }

                switch (kvp.Key.ToLower())
                {
                    case "username":
                        ValidateStringParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "version":
                    case "brief":
                    case "stats":
                    case "own":
                    case "rated":
                    case "played":
                    case "comment":
                    case "trade":
                    case "want":
                    case "wishlist":
                    case "preordered":
                    case "wanttoplay":
                    case "wanttobuy":
                    case "prevowned":
                    case "hasparts":
                    case "wantparts":
                    case "showprivate":
                        ValidateBoolParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "minplays":
                    case "maxplays":
                        ValidateIntParam(kvp.Key, result, extension.Value[kvp.Key], 0, int.MaxValue);
                        break;
                    case "rating":
                    case "minrating":
                    case "collid":
                        ValidateIntParam(kvp.Key, result, extension.Value[kvp.Key], 1, 10);
                        break;
                    case "minbggrating":
                    case "bggrating":
                        ValidateIntParam(kvp.Key, result, extension.Value[kvp.Key], -1, 10);
                        break;
                    case "wishlistpriority":
                        ValidateIntParam(kvp.Key, result, extension.Value[kvp.Key], 1, 5);
                        break;
                    case "subtype":
                    case "excludesubtype":
                        ValidateCollectionSubTypeParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "id":
                        ValidateListLongParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "modifiedsince":
                        ValidateDateTime(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                }
            }

            result.IsValid = !result.Errors.Any();

            return result;
        }

        private void ValidateCollectionSubTypeParam(string paramName, ValidationResult result, List<string> values)
        {
            if (values.Count > 1)
            {
                result.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out CollectionSubType _))
            {
                result.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
