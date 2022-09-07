using Dgi.Api.Models;

namespace Dgi.Api.Services
{
    public interface IInsightManager
    {
        List<Insight> GetInsights(InsightRequest request);
    }
}
