using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Validation
{
    public class GuildRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var guildRequest = request as GuildRequest;
            _validationResult = new ValidationResult();

            if (guildRequest.Id == default)
            {
                _validationResult.Errors.Add($"Missing required element for {typeof(GuildRequest)}: id");
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
                    case "id":
                        ValidateParam(kvp.Key, kvp.Value, true, true, IsValidLong);
                        break;
                    case "members":
                        ValidateParam(kvp.Key, kvp.Value, false, true, IsValidBool);
                        break;
                    case "sort":
                        ValidateSortTypeParam(kvp.Key, extension.Value[kvp.Key]);
                        break;
                    case "page":
                        ValidateInt(kvp.Key, kvp.Value, false, true, 1, int.MaxValue);
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }

        private void ValidateSortTypeParam(string paramName, List<string> values)
        {
            if (values.Count > 1)
            {
                _validationResult.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!Enum.TryParse(value, true, out SortType _))
            {
                _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
