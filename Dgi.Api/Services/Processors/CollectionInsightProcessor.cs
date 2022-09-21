using Bgg.Net.Common.Models;
using Dgi.Api.Models;

namespace Dgi.Api.Services.Processors
{
    public class CollectionInsightProcessor : IInsightProcessor
    {
        public Insight GetInsight(BggBase BggItem)
        {
            if (BggItem is Collection collection)
            {

            }

            return new CollectionInsight();
        }
    }
}
