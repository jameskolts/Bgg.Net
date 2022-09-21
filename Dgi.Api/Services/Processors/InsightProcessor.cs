using Bgg.Net.Common.Models;
using Dgi.Api.Models;

namespace Dgi.Api.Services.Processors
{
    public abstract class InsightProcessor : IInsightProcessor
    {
        public Insight GetInsight(BggBase BggItem)
        {
            throw new NotImplementedException();
        }
    }
}
