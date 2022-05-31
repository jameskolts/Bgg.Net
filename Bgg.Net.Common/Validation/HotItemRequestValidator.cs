using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Validation
{
    public class HotItemRequestValidator : RequestValidatorBase, IRequestValidator
    {
        /// <summary>
        /// Not Implemented for HotItemRequests.
        /// </summary>
        public ValidationResult Validate(BggRequest request)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(Extension extension)
        {
            _validationResult = new ValidationResult();

            foreach (var kvp in extension.Value)
            {
                switch (kvp.Key.ToLower())
                {
                    case "type":
                        ValidateHotItemType(kvp.Key, kvp.Value);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetHotItemsExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateHotItemType(string paramName, List<string> values)
        {
            if (values.Count > 1)
            {
                _validationResult.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out HotItemType _))
            {
                _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
