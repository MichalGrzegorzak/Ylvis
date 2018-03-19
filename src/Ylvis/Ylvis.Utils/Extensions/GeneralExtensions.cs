using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Ylvis.Utils.Extensions
{
    public static class GeneralExtensions
    {
        public static string ToStringErrors(this IList<ValidationFailure> value)
        {
            string message = string.Empty;
            foreach (ValidationFailure failure in value)
            {
                message += "-" + failure + "\n";
            }
            return message;
        }
		
		public static bool IsDefault<T>(this T value) where T : struct
        {
            bool isDefault = value.Equals(default(T));
            return isDefault;
        }

        /// <summary>
        /// Use this method to safely invoke properties, methods or other members of a nullable
        /// object. It will perform a null reference check on the object and if it is not null will
        /// invoke the specified expression. The expression has to return a reference type.
        /// </summary>
        /// <returns>Returns a reference type.</returns>
        public static TResult IfNotNull<T, TResult>(this T obj, Func<T, TResult> func, Func<TResult> ifNull = null)
            where TResult : class
        {
            return (obj != null) ? func(obj) : (ifNull != null ? ifNull() : default(TResult));
        }

        /// <summary>
        /// Use this method to safely invoke properties, methods or other members of a nullable
        /// object. It will perform a null reference check on the object and if it is not null will
        /// invoke the specified expression. The expression has to return a value type.
        /// </summary>
        /// <returns>Returns a nullable value type.</returns>
        public static TResult? IfNotNullVal<T, TResult>(this T obj, Func<T, TResult> func, Func<TResult> ifNull = null)
            where TResult : struct
        {
            return (obj != null) ? func(obj) : (ifNull != null ? ifNull() : default(TResult));
        }
        /*void Main()
        {
            // methods can be chained
            DateTime? dt = DateTime.Today;
            dt.IfNotNull(d => d.Value.ToLongDateString())
              .IfNotNull(s => s.ToUpper())
              .IfNotNull(s => s.PadLeft(40))
              .Dump();

            // use this other method if a value type is retuned
            "STRING".IfNotNullVal(s => s.Length)
              .Dump();
        }*/

        public static void Dump(this object obj)
        {
            Console.WriteLine(obj);
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

        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> source)
        {
            return new LinkedList<T>(source.EmptyIfNull());
        }
    }
}