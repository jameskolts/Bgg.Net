using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class PlayRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var playRequest = request as PlaysRequest;
            _validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(playRequest.UserName) && !playRequest.Id.HasValue)
            {
                _validationResult.Errors.Add($"Missing required element. Either username or id is required.");
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        public ValidationResult Validate(Extension extension)
        {
            _validationResult = new ValidationResult();

            if (!(extension.Value.ContainsKey("username") || extension.Value.ContainsKey("id")))
            {
                _validationResult.Errors.Add($"Missing required element. Either username or id is required.");
            }

            foreach (var kvp in extension.Value)
            {
                switch (kvp.Key.ToLower())
                {
                    case "username":
                        ValidateParam<string>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "id":
                        ValidateParam<long>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "type":
                        break;
                    case "mindate":
                    case "maxdate":
                        ValidateParam<DateOnly>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "subtype":
                        ValidateItemType(kvp.Key, kvp.Value);
                        break;
                    case "page":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 1, int.MaxValue);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetPlaysExtensible.");
                        break;
                }
            }          

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateItemType(string paramName, List<string> values)
        {
            if (values.Count > 1)
            {
                _validationResult.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out ItemType _))
            {
                _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
