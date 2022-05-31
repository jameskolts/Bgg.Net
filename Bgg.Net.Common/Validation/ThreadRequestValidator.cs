using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using System.Globalization;

namespace Bgg.Net.Common.Validation
{
    public class ThreadRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var threadRequest = request as ThreadRequest;
            _validationResult = new ValidationResult();

            if (!DateTime.TryParseExact(threadRequest.MinArticleDateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _) &&
                            !DateTime.TryParseExact(threadRequest.MinArticleDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
            {
                _validationResult.Errors.Add("minarticledatetime Should be in the format yyyy-MM-dd or yyyy-mm-dd HH:mm:ss");
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
                        ValidateParam<long>(kvp.Key, kvp.Value, true, true);
                        break;
                    case "minarticleid":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true);
                        break;
                    case "minarticledatetime":
                        ValidateParam<string>(kvp.Key, kvp.Value, false, true);
                        if (!DateTime.TryParseExact(kvp.Value.FirstOrDefault(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _) &&
                            !DateTime.TryParseExact(kvp.Value.FirstOrDefault(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
                        {
                            _validationResult.Errors.Add("minarticledatetime Should be in the format yyyy-MM-dd or yyyy-mm-dd HH:mm:ss");
                        }
                        break;
                    case "count":
                        ValidateParam<int>(kvp.Key, kvp.Value, false, true, 1, int.MaxValue);
                        break;
                    default:
                        _validationResult.Errors.Add($"'{kvp.Key}' parameter is not supported for GetThreadExtensible.");
                        break;
                }
            }

            _validationResult.IsValid = !_validationResult.Errors.Any();

            return _validationResult;
        }
    }
}
