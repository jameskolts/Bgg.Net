﻿using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Web.Client.Models;

namespace Bgg.Net.Web.Client.Helpers
{
    public class CollectionHelper
    {
        public static List<CollectionPageItem> CoalesceCollectionData(IEnumerable<CollectionItem> items, IEnumerable<Thing> things)
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

            return collectionPageItems;
        }
    }
}
