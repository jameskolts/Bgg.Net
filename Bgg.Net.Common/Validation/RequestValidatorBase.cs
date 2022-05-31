﻿namespace Bgg.Net.Common.Validation
{
    /// <summary>
    /// Base class containing common functionality for RequestValidation.
    /// </summary>
    public abstract class RequestValidatorBase
    {
        protected ValidationResult _validationResult;

        public RequestValidatorBase()
        {
            _validationResult = new ValidationResult();
        }

        public void ValidateParam(string paramName, List<string> values, bool isRequired, bool limitOne, Func<string, bool> isValid)
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

                var value = values.First();

                if (isValid != null &&
                    !isValid(value))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else if (isValid != null)
            {
                foreach (var value in values)
                {
                    if (!isValid(value))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
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

                var value = values.First();

                if (!IsValidInt(value, minValue, maxValue))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidInt(value, minValue, maxValue))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
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
