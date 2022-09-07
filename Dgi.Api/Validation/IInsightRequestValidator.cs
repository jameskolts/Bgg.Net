using Bgg.Net.Common.Validation;
using Dgi.Api.Models;

namespace Dgi.Api.Validation
{
    public interface IInsightRequestValidator
    {
        ValidationResult Validate(InsightRequest request);
    }
}
