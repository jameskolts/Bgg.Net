using Bgg.Net.Client.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public interface ICollectionViewModel : IViewModel
    {
        /// <summary>
        /// True if the ViewModel is busy.
        /// </summary>
        bool IsBusy { get; set; }

        /// <summary>
        /// The collection of items.
        /// </summary>
        ObservableCollection<CollectionPageItem> Collection { get; set; }

        /// <summary>
        /// Gets the collection of items for a specific user.
        /// </summary>
        /// <param name="userName">The user to get a collection for.</param>
        Task GetCollection(string userName);

        /// <summary>
        /// Filters the collection by the given parameters.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <param name="age">The minimum age to filter by.</param>
        /// <param name="playercount">The minimum player count to filter by.</param>
        /// <param name="time">The maximum time to filter by.</param>
        void FilterCollection(string name, string age, string playercount, string time);
    }
}
