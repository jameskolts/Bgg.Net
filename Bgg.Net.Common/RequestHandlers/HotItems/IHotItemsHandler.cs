using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
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
        /// Gets a HotItemList given extensible parameters.
        /// </summary>
        /// <param name="extension">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="HotItemList"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>Supported parameters include: 'type'.</remarks>
        Task<BggResult<HotItemList>> GetHotItemsExtensible(Extension extension);
    }
}
