using System;
using System.Collections.Generic;

namespace Ylvis.Utils.Extensions
{
    public static class DictionaryExtension
    {
        public static void AddOrUpdate<TKey, TValue>(
            this IDictionary<TKey, TValue> map, TKey key, TValue value)
        {
            map[key] = value;
        }

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

        public static void AddSafe<T, U>(this Dictionary<T, U> dict, T key, U value)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, value);
            else
                dict[key] = value;
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