using System.Collections;

namespace Helpers
{
    /// <summary>
    /// Generic class, usefull for fast storing key and value
    /// </summary>
    /// <typeparam name="T">type you will store</typeparam>
    public class FastStoreValues<T>
    {
        private readonly Hashtable _storedObjects = new Hashtable();

        /// <summary>
        /// Add to hashtable
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public void Add(string keyName, T value)
        {
            if (!_storedObjects.ContainsKey(keyName))
            {
                _storedObjects.Add(keyName, value);
            }
        }

        /// <summary>
        /// Will search value in hashtable, if not fount will returns defalut(T) 
        /// </summary>
        /// <param name="keyName">key</param>
        /// <returns>value or defalut(T)</returns>
        public T Get(string keyName)
        {
            if (_storedObjects.ContainsKey(keyName))
            {
                return (T)_storedObjects[keyName];
            }
            return default(T);
        }
    }
}
