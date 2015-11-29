using System;
using System.Collections.Generic;
using System.Linq;

namespace Ylvis.Utils.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<TSource> Distinct<TSource, TResult>(this IEnumerable<TSource> items, Func<TSource, TResult> selector)
        {
            var set = new HashSet<TResult>();
            foreach (var item in items)
            {
                var hash = selector(item);
                if (!set.Contains(hash))
                {
                    set.Add(hash);
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Each<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
                yield return item;
            }
        }

        public static bool HasAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}