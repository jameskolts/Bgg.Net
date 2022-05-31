namespace Bgg.Net.Common.Validation
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

        protected virtual void ValidateParam<T>(string paramName, List<string> values, bool isRequired = false, bool limitOne = false, int? minValue = null, int? maxValue = null)
        {
            var type = typeof(T);

            switch (type.Name.ToLower())
            {
                case "bool":
                    ValidateBool(paramName, values, isRequired, limitOne);
                    break;
                case "string":
                    ValidateString(paramName, values, isRequired, limitOne);
                    break;
                case "long":
                    ValidateLong(paramName, values, isRequired, limitOne);
                    break;
                case "int":
                    ValidateInt(paramName, values, isRequired, limitOne, minValue, maxValue);
                    break;
                case "datetime":
                    ValidateDateTime(paramName, values, isRequired, limitOne);
                    break;
                case "dateonly":
                    ValidateDateOnly(paramName, values, isRequired, limitOne);
                    break;

            }
        }

        private void ValidateBool(string paramName, List<string> values, bool isRequired, bool limitOne)
        {
            if (isRequired && !IsElementPresent(paramName, values))
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

                if (!IsValidBool(paramName, value))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidBool(paramName, value))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                    }
                }
            }
        }

        private void ValidateLong(string paramName, List<string> values, bool isRequired, bool limitOne)
        {
            if (isRequired && !IsElementPresent(paramName, values))
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

                if (!IsValidLong(paramName, value))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidLong(paramName, value))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                    }
                }
            }
        }

        private void ValidateInt(string paramName, List<string> values, bool isRequired, bool limitOne, int? minValue, int? maxValue)
        {
            if (isRequired && !IsElementPresent(paramName, values))
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

                if (!IsValidInt(paramName, value, minValue, maxValue))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidInt(paramName, value, minValue, maxValue))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                    }
                }
            }
        }

        private void ValidateDateTime(string paramName, List<string> values, bool isRequired, bool limitOne)
        {
            if (isRequired && !IsElementPresent(paramName, values))
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

                if (!IsValidDateTime(paramName, value))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidDateTime(paramName, value))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                    }
                }
            }
        }

        private void ValidateDateOnly(string paramName, List<string> values, bool isRequired, bool limitOne)
        {
            if (isRequired && !IsElementPresent(paramName, values))
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

                if (!IsValidDateOnly(paramName, value))
                {
                    _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
            else
            {
                foreach (var value in values)
                {
                    if (!IsValidDateOnly(paramName, value))
                    {
                        _validationResult.Errors.Add($"The value {value} was not valid for {paramName}");
                    }
                }
            }
        }

        private void ValidateString(string paramName, List<string> values, bool isRequired, bool limitOne)
        {
            if (isRequired && !IsElementPresent(paramName, values))
            {
                _validationResult.Errors.Add($"Missing required element: {paramName}");
            }

            if (limitOne)
            {
                if (values.Count > 1)
                {
                    _validationResult.Errors.Add($"Only one value is allowed for: {paramName}");
                }
            }
        }

        private bool IsValidDateTime(string paramName, string value)
        {
            if (!DateTime.TryParse(value, out DateTime _))
            {
                return false;
            }

            return true;
        }

        private bool IsValidDateOnly(string paramName, string value)
        {
            if (!DateOnly.TryParse(value, out DateOnly _))
            {
                return false;
            }

            return true;
        }



        private bool IsValidBool(string paramName, string value)
        {
            if (value != "0" || value != "1")
            {
                return false;
            }

            return true;
        }

        private bool IsValidLong(string paramName, string value)
        {
            if (!long.TryParse(value, out long _))
            {
                return false;
            }

            return true;
        }

        private bool IsValidInt(string paramName, string value, int? minValue = null, int? maxValue = null)
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

        private bool IsElementPresent(string paramName, List<string> values)
        {
            if (values == null || !values.Any())
            {
                return false;
            }

            return true;
        }
    }
}
