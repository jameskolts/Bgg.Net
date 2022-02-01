using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Resources.Families
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
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Family"/>.</returns>
        Task<BggResult<Family>> GetFamilyById(int id);

        /// <summary>
        /// Gets multiple families by the given ids.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Family"/>.</returns>
        Task<BggResult<Family>> GetFamilyByIds(List<int> ids);

        /// <summary>
        /// Gets multiple families by the given ids, filtered by type.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <param name="types">The types to retrieve</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Family"/>.</returns>
        Task<BggResult<Family>> GetFamilyByIdsAndType(List<int> ids, List<FamilyType> types);

        /// <summary>
        /// Gets a family given extensible parameters. 
        /// </summary>
        /// <param name="extension">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Family"/>.</returns>
        Task<BggResult<Family>> GetFamilyExtensible(Extension extension);
    }
}
