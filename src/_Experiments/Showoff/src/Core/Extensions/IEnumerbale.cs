using System;
using System.Collections.Generic;

namespace Showoff.Web.Core.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
                yield return item;
            }
        }
    }
}