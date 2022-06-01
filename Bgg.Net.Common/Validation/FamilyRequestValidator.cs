using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Validation
{
    public class FamilyRequestValidator : RequestValidatorBase, IRequestValidator
    {
        /// <summary>
        /// Not implemented for FamilyRequests.
        /// </summary>
        public ValidationResult Validate(BggRequest request)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(Extension extension)
        {
            _validationResult = new ValidationResult();

            if (!extension.Value.ContainsKey("id"))
            {
                _validationResult.Errors.Add($"Missing required element for FamilyRequest: id");
            }

            foreach (var kvp in extension.Value)
            {
                switch (kvp.Key.ToLower())
                {
                    case "type":
                        ValidateFamilyTypeParam(kvp.Key, kvp.Value);
                        break;
                    case "id":
                        ValidateParam(kvp.Key, kvp.Value, false, false, IsValidLong);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for: GetFamilyExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateFamilyTypeParam(string paramName, List<string> values)
        {
            foreach (var value in values)
            {
                if (!Enum.TryParse(value, true, out FamilyType _))
                {
                    _validationResult.Errors.Add($"The value '{value}' was not valid for: {paramName}");
                }
            }
        }
    }
}