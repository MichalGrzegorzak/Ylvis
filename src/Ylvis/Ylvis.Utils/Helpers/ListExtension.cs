using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace Netizens.ExtensionsLib
{
    public static class ListExtension
    {
        public static bool IsEqual(this List<int> InternalList, List<int> ExternalList)
        {
            if (InternalList.Count != ExternalList.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < InternalList.Count; i++)
                {
                    if (InternalList[i] != ExternalList[i])
                        return false;
                }
            }

            return true;
        }

        public static string ToStringList(this List<int> items)
        {
            System.Text.StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append(items[i].ToString());
            }

            return sb.ToString();
        }

        public static string ToStringList(this List<string> items)
        {
            System.Text.StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append(items[i].ToString());
            }

            return sb.ToString();
        }

        public static EntitySet<T> ToEntitySet<T>(this IEnumerable<T> source) where T : class
        {
            var es = new EntitySet<T>();
            es.AddRange(source);
            return es;
        }

        public static List<T> ToList<T>(this EntitySet<T> source) where T : class
        {
            var es = new List<T>();
            es.AddRange(source);
            return es;
        }

        public static List<SimpleItem> ToSimpleItemsList<T>(this IEnumerable<T> source, Func<T,SimpleItem> func) where T : class
        {
            List<SimpleItem> simpleList = new List<SimpleItem>();

            foreach (T listItem in source)
            {
                SimpleItem item = func(listItem);
                simpleList.Add(item);    
            }

            return simpleList;
        }

        
    }
}
