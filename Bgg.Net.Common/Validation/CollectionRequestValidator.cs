using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class CollectionRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var collectionRequest = request as CollectionRequest;
            _validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(collectionRequest.UserName))
            {
                _validationResult.Errors.Add($"Missing required element for {typeof(CollectionRequest)}: userName");
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
                    case "username":
                        ValidateParam<string>(kvp.Key, kvp.Value, true, true);
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
                        ValidateParam<bool>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "minplays":
                    case "maxplays":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 0, int.MaxValue);
                        break;
                    case "rating":
                    case "minrating":
                    case "collid":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 1, 10);
                        break;
                    case "minbggrating":
                    case "bggrating":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, -1, 10);
                        break;
                    case "wishlistpriority":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 1, 5);
                        break;
                    case "subtype":
                    case "excludesubtype":
                        ValidateCollectionSubTypeParam(kvp.Key, kvp.Value);
                        break;
                    case "id":
                        ValidateParam<long>(kvp.Key, kvp.Value);
                        break;
                    case "modifiedsince":
                        ValidateParam<DateTime>(kvp.Key, kvp.Value, false, true);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetCollectionExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateCollectionSubTypeParam(string paramName, List<string> values)
        {
            if (values.Count > 1)
            {
                _validationResult.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out CollectionSubType _))
            {
                _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
