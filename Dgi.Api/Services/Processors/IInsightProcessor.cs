using Bgg.Net.Common.Models;
using Dgi.Api.Models;

namespace Dgi.Api.Services.Processors
{
    public interface IInsightProcessor
    {
        Insight GetInsight(BggBase BggItem);
    }
}
