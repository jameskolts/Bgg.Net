using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;


namespace Bgg.Net.Common.RequestHandlers.HotItems
{
    /// <summary>
    /// Public interface for HotItem requests.
    /// </summary>
    public interface IHotItemsHandler
    {
        /// <summary>
        /// Gets a HotItemList by the given type.
        /// </summary>
        /// <param name="type">The type to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="HotItemList"/>.</returns>
        Task<BggResult<HotItemList>> GetHotItemsByType(HotItemType type);

        /// <summary>
        /// Gets a HotItemList by the given query.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="HotItemList"/>.</returns>
        Task<BggResult<HotItemList>> GetHotItems(HotItemRequest request);
    }
}
