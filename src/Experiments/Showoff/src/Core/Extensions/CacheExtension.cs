using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace AmexMerchant.Domain.Extensions
{
    public static class CacheExtension
    {
        static object sync = new object();

        /// <summary>
        /// Executes a method and stores the result in cache using the given cache key.  
        /// If the data already exists in cache, it returns the data
        /// and doesn't execute the method.  Thread safe, although the method parameter
        /// isn't guaranteed to be thread safe.
        /// </summary>
        /// <param name="cacheKey">Each method has it's own isolated set of cache items,
        ///so cacheKeys won't overlap accross methods.</param>
        /// <param name="expirationSeconds">Lifetime of cache items, in seconds</param>
        public static T Data<T>(this Cache cache, string cacheKey, int expirationSeconds, Func<T> method)
        {
            //var hash = method.GetHashCode().ToString();
            var data = (T)cache[cacheKey];
            if (data == null)
            {
                data = method();

                if (expirationSeconds > 0 && data != null)
                    lock (sync)
                    {
                        cache.Insert(cacheKey, data, null, DateTime.Now.AddSeconds
                            (expirationSeconds), Cache.NoSlidingExpiration);
                    }
            }
            return data;
        }
    }
}
