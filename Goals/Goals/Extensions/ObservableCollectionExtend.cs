using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Goals.Extensions
{
    public static class ObservableCollectionExtend
    {
        public static void AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                source.Add(item);
            }
        }
    }
}
