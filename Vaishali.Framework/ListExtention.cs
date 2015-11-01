using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vaishali.Framework
{
    public static class ListExtention
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            var collection= new ObservableCollection<T>();
            foreach (var element in list)
            {
                collection.Add(element);
            }
            return collection;
        }
    }
}
