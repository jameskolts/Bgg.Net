using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
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
        Task<BggResult<FamilyList>> GetFamilyById(long id);

        /// <summary>
        /// Gets multiple families by the given ids.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamilyByIds(List<long> ids);

        /// <summary>
        /// Gets multiple families by the given ids, filtered by type.
        /// </summary>
        /// <param name="ids">The ids to retrieve.</param>
        /// <param name="types">The types to retrieve</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<long> ids, List<FamilyType> types);

        /// <summary>
        /// Gets a familylist by the parameters provided in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="FamilyList"/>.</returns>
        Task<BggResult<FamilyList>> GetFamily(FamilyRequest request);
    }
}
