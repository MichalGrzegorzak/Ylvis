using System;
using System.Collections.Generic;
using System.Linq;

namespace Showoff.Core.Features.Extensions
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// If a key exists in a dictionary, return its value, 
        /// otherwise return the default value for that type.
        /// </summary>
        public static U GetOrDefault<T, U>(this Dictionary<T, U> dict, T key)
        {
            return dict.GetOrDefault(key, default(U));
        }

        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the provided default value.
        /// </summary>
        public static U GetOrDefault<T, U>(this Dictionary<T, U> dict, T key, U defaultValue)
        {
            return dict.ContainsKey(key)
                ? dict[key]
                : defaultValue;
        }

        public static TValue GetOrCreateValue<TKey, TValue> (this IDictionary<TKey, TValue> dictionary,
         TKey key,
         TValue value)
        {
            return dictionary.GetOrCreateValue(key, () => value);
        }

        public static TValue GetOrCreateValue<TKey, TValue> (this IDictionary<TKey, TValue> dictionary,
             TKey key,
             Func<TValue> valueProvider)
        {
            TValue ret;
            if (!dictionary.TryGetValue(key, out ret))
            {
                ret = valueProvider();
                dictionary[key] = ret;
            }
            return ret;
        }

        

            
    }
}