namespace Bgg.Net.Common.Infrastructure.Validation
{
    /// <summary>
    /// Public interface for the RequestValidatorFactory.
    /// </summary>
    public interface IRequestValidatorFactory
    {
        /// <summary>
        /// Creates an instance of IRequestValidator given a requestType
        /// </summary>
        /// <param name="requestType">The type of request to validate.</param>
        /// <returns>The <see cref="IRequestValidator"/>for the given requestType.</returns>
        IRequestValidator CreateRequestValidator(string requestType);
    }
}
