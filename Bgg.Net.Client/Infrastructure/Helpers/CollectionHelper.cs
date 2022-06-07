using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Client.Models;
using Bgg.Net.Common.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.Infrastructure.Helpers
{
    /// <summary>
    /// Contains helper functionality for dealing with collections.
    /// </summary>
    public class CollectionHelper : ICollectionHelper
    {
        /// <inheritdoc/>
        public ObservableCollection<CollectionPageItem> CoalesceCollectionData(IEnumerable<CollectionItem> items, IEnumerable<Thing> things)
        {
            var collectionPageItems = new List<CollectionPageItem>();

            foreach (var item in items)
            {
                var thing = things.Where(x => x.Id == item.Id).FirstOrDefault();

                if (thing != null)
                {
                    collectionPageItems.Add(new CollectionPageItem(item, thing));
                }
            }

            return collectionPageItems.ToObservableCollection();
        }
    }
}
