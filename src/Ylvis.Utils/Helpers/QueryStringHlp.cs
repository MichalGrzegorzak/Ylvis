using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;

namespace ExtensionsLib
{
    /// <summary>
    /// QueryString helper class
    /// </summary>
    public class QueryStringHlp
    {
        #region Fields & Properties
        /// <summary>
        /// QueryString collection
        /// </summary>
        private NameValueCollection _collect = null;
        
        #endregion

        #region .Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringHlp"/> class.
        /// </summary>
        public QueryStringHlp()
        {
            _collect = HttpContext.Current.Request.QueryString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringHlp"/> class for Test`s only!
        /// </summary>
        /// <param name="queryString">The query string.</param>
        public QueryStringHlp(NameValueCollection queryString)
        {
            _collect = queryString;
        }

        #endregion

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="key">The key name.</param>
        /// <returns>type</returns>
        public T Get<T>(string key)
        {
            T result = default(T);

            object val = _collect[key];
            if(val != null)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                result = (T)tc.ConvertFrom(val);
            }

            return result;
        }

        public string Get(string key)
        {
            return Get<string>(key);
        }

        public bool Exist(string key)
        {
            object val = _collect[key];
            if (val != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Replaces the in string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="toBeReplaced">To be replaced.</param>
        /// <returns></returns>
        public static string ChangeKeyValues(string input, Hashtable toBeReplaced )
        {
            string result = input;

            foreach(string key in toBeReplaced.Keys)
            {
                int begin = input.IndexOf(key) + 1;
                if(begin > 0)
                {
                    begin = input.IndexOf('=', begin) + 1;
                    int end = input.IndexOf('&', begin);
                    if(end == -1)
                    {
                        end = input.Length;
                    }

                    int len = end - begin;
                    string oldValue = input.Substring(begin, len);

                    result = result.Replace(oldValue, toBeReplaced[key].ToString());
                }
                else
                {
                    result += "&" + key + "=" + toBeReplaced[key];
                }
            }

            return result;
        }


    }
}

