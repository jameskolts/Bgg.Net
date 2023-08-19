using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public interface IPlayRequestValidator : IRequestValidator
    {
        ValidationResult Validate(LogPlayRequest request);
    }
}
