using System.Collections.ObjectModel;

namespace Bgg.Net.Client.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        public static string CreateListLabelText(this IList<string> strings)
        {
            return string.Join(", ", strings.Take(3)) +
                (strings.Count > 3 ? $" +{strings.Count - 3} more" : string.Empty);
        }
    }
}
