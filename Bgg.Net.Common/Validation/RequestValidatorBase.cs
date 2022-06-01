namespace Bgg.Net.Common.Validation
{
    /// <summary>
    /// Base class containing common functionality for RequestValidation.
    /// </summary>
    public abstract class RequestValidatorBase
    {
        protected ValidationResult _validationResult;

        /// <summary>
        /// Validates the given values, populating _validationResult with any validation errors.
        /// </summary>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <param name="values">The values being validated.</param>
        /// <param name="isRequired">True if this parameter is required.</param>
        /// <param name="limitOne">True if this parameter is limited to a single entry.</param>
        /// <param name="isValid">The function that validates an individual string value for correctedness.</param>
        public void ValidateParam(string paramName, List<string> values, bool isRequired, bool limitOne, Func<string, bool> isValid)
        {
            if (isRequired && !IsElementPresent(values))
            {
                _validationResult.Errors.Add($"Missing required element: {paramName}");
                return;
            }

            if (limitOne)
            {
                if (values.Count > 1)
                {
                    _validationResult.Errors.Add($"Only one value is allowed for: {paramName}");
                }

                var value = values.FirstOrDefault();

                if (isValid != null &&
                    !isValid(value))
                {
                    _validationResult.Errors.Add($"The value '{value}' was not valid for: {paramName}");
                }
            }
            else if (isValid != null)
            {
                foreach (var value in values)
                {
                    if (!isValid(value))
                    {
                        _validationResult.Errors.Add($"The value '{value}' was not valid for: {paramName}");
                    }
                }
            }
        }

        protected void ValidateInt(string paramName, List<string> values, bool isRequired, bool limitOne, int? minValue, int? maxValue)
        {
            if (isRequired && !IsElementPresent(values))
            {
                _validationResult.Errors.Add($"Missing required element: {paramName}");
            }

            if (limitOne)
            {
                if (values.Count > 1)
                {
                    _validationResult.Errors.Add($"Only one value is allowed for: {paramName}");
                }

                var value = values.FirstOrDefault();

                if (!IsValidInt(value, minValue, maxValue))
                {
                    _validationResult.Errors.Add($"The value '{value}' was not valid for: {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidInt(value, minValue, maxValue))
                    {
                        _validationResult.Errors.Add($"The value '{value}' was not valid for: {paramName}");
                    }
                }
            }
        }

        protected bool IsValidDateTime(string value)
        {
            if (!DateTime.TryParse(value, out DateTime _))
            {
                return false;
            }

            return true;
        }

        protected bool IsValidDateOnly(string value)
        {
            if (!DateOnly.TryParse(value, out DateOnly _))
            {
                return false;
            }

            return true;
        }

        protected bool IsValidBool(string value)
        {
            if (value != "0" && value != "1")
            {
                return false;
            }

            return true;
        }

        protected bool IsValidLong(string value)
        {
            if (!long.TryParse(value, out long _))
            {
                return false;
            }

            return true;
        }

        protected bool IsValidInt(string value, int? minValue = null, int? maxValue = null)
        {
            if (!int.TryParse(value, out int parsedValue))
            {
                return false;
            }

            if (minValue.HasValue && maxValue.HasValue &&
              (parsedValue < minValue.Value || parsedValue > maxValue.Value))
            {
                return false;
            }

            return true;
        }

        protected bool IsElementPresent(List<string> values)
        {
            if (values == null || !values.Any())
            {
                return false;
            }

            return true;
        }
    }
}
