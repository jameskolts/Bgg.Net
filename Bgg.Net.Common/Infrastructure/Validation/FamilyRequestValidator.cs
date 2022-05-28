using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class FamilyRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(Extension extension)
        {
            var result = new ValidationResult();

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedFamilyQueryParameters.Contains(kvp.Key))
                {
                    result.Errors.Add($"'{kvp.Key}' parameter is not supported for GetFamilyExtensible.");
                }

                switch (kvp.Key.ToLower())
                {
                    case "type":
                        ValidateFamilyTypeParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                    case "id":
                        ValidateListLongParam(kvp.Key, result, extension.Value[kvp.Key]);
                        break;
                }
            }

            result.IsValid = !result.Errors.Any();

            return result;
        }

        private void ValidateFamilyTypeParam(string paramName, ValidationResult result, List<string> values)
        {
            foreach (var value in values)
            {
                if (!Enum.TryParse(value, true, out FamilyType _))
                {
                    result.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
        }
    }
}