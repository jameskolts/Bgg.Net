using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Families
{
    /// <summary>
    /// Public interface for family queries.
    /// </summary>
    public interface IFamilyHandler
    {
        /// <summary>
        /// Gets a family by the given id.
        /// </summary>
        /// <param name="id">The id to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamilyById(int id);

        /// <summary>
        /// Gets multiple families by the given ids.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamilyByIds(List<int> ids);

        /// <summary>
        /// Gets multiple families by the given ids, filtered by type.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <param name="types">The types to retrieve</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<int> ids, List<FamilyType> types);

        /// <summary>
        /// Gets a family given extensible parameters. 
        /// </summary>
        /// <param name="extension">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>Supported parameters include: 'id', 'type'.</remarks>
        Task<BggResult<FamilyList>> GetFamilyExtensible(Extension extension);
    }
}
