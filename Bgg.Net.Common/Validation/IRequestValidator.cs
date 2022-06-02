using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    /// <summary>
    /// Public interface for ThingRequest validation.
    /// </summary>
    public interface IRequestValidator
    {
        /// <summary>
        /// Validates a request object.
        /// </summary>
        /// <param name="request">The request to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the outcome.</returns>
        ValidationResult Validate(BggRequest request);
    }
}
