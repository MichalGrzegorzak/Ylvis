using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;

namespace Netizens.ExtensionsLib
{
    public static class GetWithDefaultExtension
    {
        public static T GetWithDefault<T>
            (this HttpSessionState session, string keyName)
        {
            if (session[keyName] != null)
                return (T)session[keyName];
            else
            {
                return default(T);
            }
        }

        public static T GetWithDefault<T>
            (this HttpSessionState session, string keyName, Func<T> ifNullThenThis) 
        {
            if (session[keyName] != null)
                return (T)session[keyName];
            else
                return ifNullThenThis.Invoke();
        }



        public static T GetWithDefault<T>
            (this StateBag viewState, string keyName)
        {
            if (viewState[keyName] != null)
                return (T)viewState[keyName];
            else
            {
                return default(T);
            }
        }

        public static T GetWithDefault<T>
            (this StateBag viewState, string keyName, Func<T> ifNullThenThis)
        {
            if (viewState[keyName] != null)
                return (T)viewState[keyName];
            else
                return ifNullThenThis.Invoke();
        }


        /// <summary>
        /// If a key exists in a dictionary, return its value, 
        /// otherwise return the default value for that type.
        /// </summary>
        public static U GetWithDefault<T, U>(this Dictionary<T, U> dict, T key)
        {
            return dict.GetWithDefault(key, default(U));
        }

        /// <summary>
        /// If a key exists in a dictionary, return its value,
        /// otherwise return the provided default value.
        /// </summary>
        public static U GetWithDefault<T, U>(this Dictionary<T, U> dict, T key, U defaultValue)
        {
            return dict.ContainsKey(key)
                ? dict[key]
                : defaultValue;
        }

    }
}
