using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class HotItemRequestValidator : IRequestValidator
    {
        /// <summary>
        /// Not Implemented for HotItemRequests.
        /// </summary>
        public ValidationResult Validate(BggRequest request)
        {
            return new ValidationResult
            {
                IsValid = true
            };
        }
    }
}
