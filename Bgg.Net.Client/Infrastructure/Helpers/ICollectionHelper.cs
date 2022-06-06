using Bgg.Net.Client.Models;
using Bgg.Net.Common.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.Infrastructure.Helpers
{
    public interface ICollectionHelper
    {
        /// <summary>
        /// Coalesces a collection of CollectionItems and things into a CollectionPageItem
        /// </summary>
        /// <param name="items">The collection of item responses</param>
        /// <param name="things">The collection of thing responses.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="CollectionPageItem"/>.</returns>
        ObservableCollection<CollectionPageItem> CoalesceCollectionData(IEnumerable<CollectionItem> items, IEnumerable<Thing> things);
    }
}
