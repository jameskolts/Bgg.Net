using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class UserRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var userRequest = request as UserRequest;
            _validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(userRequest.Name))
            {
                _validationResult.Errors.Add($"Missing required element for {typeof(CollectionRequest)}: name");
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
                    case "name":
                        ValidateParam<string>(kvp.Key, kvp.Value, true, true);
                        break;
                    case "buddies":
                    case "guilds":
                    case "hot":
                    case "top":
                        ValidateParam<bool>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "domain":
                        ValidateDomainType(kvp.Key, kvp.Value);
                        break;
                    case "page":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 1, int.MaxValue);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetUserExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateDomainType(string paramName, List<string> values)
        {
            if (values.Count > 1)
            {
                _validationResult.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out DomainType _))
            {
                _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
