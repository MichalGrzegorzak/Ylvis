using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.Caching;

namespace Helpers
{
    /// <summary>
    /// Caching objects for X min
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheHelper<T>
    {
        private int _minutes = 6;
        private bool _needLocking = false;
        private static object _lock = new object();
        private static Hashtable _synchronizationTable = new Hashtable();

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheHelper&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        public CacheHelper(int minutes)
        {
            _minutes = minutes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheHelper&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <param name="needLocking">if set to <c>true</c> [need locking].</param>
        public CacheHelper(int minutes, bool needLocking)
        {
            _minutes = minutes;
            _lock = needLocking;
        }

        /// <summary>
        /// Cache item for X minutes.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="obj"></param>
        public void Save(string keyName, T obj)
        {
            if (_needLocking)
            {
                _synchronizationTable.Add(keyName, new object());

                lock (_synchronizationTable[keyName])
                {
                    SaveToCache(keyName, obj);
                }
            }
            else
            {
                SaveToCache(keyName, obj);
            }
        }

        /// <summary>
        /// Saves to cache.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="obj">The obj.</param>
        private void SaveToCache(string keyName, T obj)
        {
            if (obj != null)
            {
                Cache.Insert(keyName, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                                            new TimeSpan(0, 0, _minutes, 0, 0));
            }
            else //will chache emty string
            {
                Cache.Insert(keyName, "", null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                                            new TimeSpan(0, 0, _minutes, 0, 0));
            }
        }

        /// <summary>
        /// Reads the specified key name.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="isNull">if set to <c>true</c> [is null].</param>
        /// <returns></returns>
        public T Read(string keyName, out bool isNull)
        {
            object result = null;

            
            if (_needLocking)
            {
                lock (_synchronizationTable[keyName])
                {
                    result = Cache.Instance[keyName];
                }
            }
            else
            {
                result = Cache.Instance[keyName];
            }

            if (result == null
                || (string.IsNullOrEmpty(result.ToString())))
            {
                isNull = true;
                return default(T);
            }

            isNull = false;
            return (T)result;

        }

        /// <summary>
        /// Reads the specified key name.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public T Read(string keyName)
        {
            bool ignoreMe = false;
            return Read(keyName, out ignoreMe);

        }
    }
        
}
