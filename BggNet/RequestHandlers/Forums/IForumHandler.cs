using Bgg.Net.Common.Models;
using Bgg.Net.Common.Infrastructure;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    public interface IForumHandler
    {
        Task<BggResult<Forum>> GetForumById(long id);
    }
}
