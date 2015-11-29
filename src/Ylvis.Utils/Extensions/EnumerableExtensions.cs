using System;
using System.Collections.Generic;
using System.Linq;

namespace Ylvis.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static List<TResult> SelectList<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToList();
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
