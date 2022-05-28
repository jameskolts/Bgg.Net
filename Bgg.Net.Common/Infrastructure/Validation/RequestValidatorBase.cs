namespace Bgg.Net.Common.Infrastructure.Validation
{
    /// <summary>
    /// Base class containing common functionality for RequestValidation.
    /// </summary>
    public abstract class RequestValidatorBase
    {
        /// <summary>
        /// Validates that all values are assignable to a bool value.
        /// </summary>
        /// <param name="result">The result to populate any errors with.</param>
        /// <param name="values">The values to validate.</param>
        /// <remarks>The BGG API only accepts 0 and 1 values.  
        /// 'true' and 'false' string values are NOT allowed.</remarks>
        public void ValidateBoolParam(string paramName, ValidationResult result, List<string> values)
        {
            if (values.Count > 1)
            {
                result.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();

            if (value != "0" || value != "1")
            {
                result.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }

        public virtual void ValidateIntParam(string paramName, ValidationResult result, List<string> values, int? minValue = null, int? maxValue = null)
        {
            if (values.Count > 1)
            {
                result.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!int.TryParse(value, out int parsedValue))
            {
                result.Errors.Add($"The value {value} was not valid for {paramName}");
            }

            if ((minValue.HasValue && maxValue.HasValue) &&
               (parsedValue < minValue.Value || parsedValue > maxValue.Value))
            {
                result.Errors.Add($"The value {parsedValue} must be in range {minValue.Value}..{maxValue.Value}");
            }
        }

        public void ValidateListLongParam(string paramName, ValidationResult result, List<string> values)
        {
            foreach (var value in values)
            {
                if (!long.TryParse(value, out long _))
                {
                    result.Errors.Add($"The value {value} was not valid for {paramName}");
                }
            }
        }

        public void ValidateStringParam(string paramName, ValidationResult result, List<string> values)
        {
            if (values.Count > 1)
            {
                result.Errors.Add($"Only one value is allowed for {paramName}");
            }
        }

        public void ValidateDateTime(string paramName, ValidationResult result, List<string> values)
        {
            if (values.Count > 1)
            {
                result.Errors.Add($"Only one value is allowed for {paramName}");
            }

            var value = values.FirstOrDefault();
            if (!DateTime.TryParse(value, out DateTime _))
            {
                result.Errors.Add($"The value {value} was not valid for {paramName}");
            }
        }
    }
}
