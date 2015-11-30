using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;

namespace ExtensionsLib.Web
{
    public static class GetOrDefaultExtension
    {
        public static T GetOrDefault<T>(this HttpSessionState session, string keyName)
        {
            if (session[keyName] != null)
                return (T)session[keyName];
            else
            {
                return default(T);
            }
        }

        public static T GetOrDefault<T>(this HttpSessionState session, string keyName, Func<T> ifNullThenThis) 
        {
            if (session[keyName] != null)
                return (T)session[keyName];
            else
                return ifNullThenThis.Invoke();
        }


        public static T GetOrDefault<T>(this StateBag viewState, string keyName)
        {
            if (viewState[keyName] != null)
                return (T)viewState[keyName];
            else
            {
                return default(T);
            }
        }

        public static T GetOrDefault<T>(this StateBag viewState, string keyName, Func<T> ifNullThenThis)
        {
            if (viewState[keyName] != null)
                return (T)viewState[keyName];
            else
                return ifNullThenThis.Invoke();
        }


        
    }
}
