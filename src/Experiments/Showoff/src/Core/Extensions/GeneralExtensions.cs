using System;
using System.Collections.Generic;
using System.Linq;

namespace Showoff.Core.Features.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsDefault<T>(this T value) where T : struct
        {
            bool isDefault = value.Equals(default(T));
            return isDefault;
        }

        /// <summary>
        /// Performs delegate action on source object if it is not default.
        /// </summary>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <typeparam name="TSource">Type of source.</typeparam>
        /// <param name="source">Source object to perform action on.</param>
        /// <param name="callback">Action that will be performed on source object if it is != emptySourceValue.</param>
        /// <param name="getDefault">Default value will be used if source object is == emptySourceValue.</param>
        /// <param name="emptySourceValue">Value that represents empty source.</param>
        /// <returns>Callback result or default.</returns>
        public static TResult IfNotDefault<TResult, TSource>(
            this TSource source,
            Func<TSource, TResult> callback,
            Func<TResult> getDefault = null,
            TSource emptySourceValue = default(TSource))
        {
            return EqualityComparer<TSource>.Default.Equals(source, emptySourceValue) 
                ? (getDefault ?? (() => default(TResult)))()
                : callback(source);
        }


        public static TResult IfNotDefault<TResult, TSource>(
            this TSource source,
            TResult result,
            TResult defaultResult = default(TResult),
            TSource emptySourceValue = default(TSource))
        {
            return EqualityComparer<TSource>.Default.Equals(source, emptySourceValue)
                ? defaultResult
                : result;
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
        public static IEnumerable<KeyValuePair<int, T>> WithIndices<T>(this IEnumerable<T> source)
        {
            return source.Select((x, i) => new KeyValuePair<int, T>(i, x));
        }

        public static string IfNullOrEmpty(this string s, Func<string> defaultCallback, Func<string,string> elseCallback = null)
        {
            return string.IsNullOrEmpty(s) ? defaultCallback() : (elseCallback ?? (x => x))(s);
        }

        public static TOut Tap<TIn, TOut>(this TIn obj, Func<TIn, TOut> callback)
        {
            return callback(obj);
        }

        public static T Tap<T>(this T obj, Action<T> callback)
        {
            callback(obj);
            return obj;
        }

        public static T GetAttributeOfEnumValue<T>(this object enumVal)
            where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.EmptyIfNull().Any() ? (T) attributes[0] : null;
        }

        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> source)
        {
            return new LinkedList<T>(source.EmptyIfNull());
        }
    }
}