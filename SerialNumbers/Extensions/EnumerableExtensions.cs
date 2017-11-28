using System;
using System.Collections.Generic;
using System.Linq;

namespace SerialNumbers.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Invokes given action on all items of given collection.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var list = enumerable as List<T> ?? enumerable.ToList();
            list.ForEach(action);
        }
    }
}