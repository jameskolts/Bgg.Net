using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Infrastructure
{
    public interface IQueryBuilder
    {
        string BuildQuery(string resourceName, BggRequest request);

    }
}
