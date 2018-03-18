using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ylvis.Utils.Features.TypesParsing;

namespace Ylvis.Utils.Extensions
{
    public static class ListExtension
    {
        public static Boolean IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static List<T> CreateList<T>(params T[] values)
        {
            return new List<T>(values);
        }


        public static bool IsEqual(this List<int> internalList, List<int> externalList)
        {
            if (internalList.Count != externalList.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < internalList.Count; i++)
                {
                    if (internalList[i] != externalList[i])
                        return false;
                }
            }

            return true;
        }

        public static List<T> StringToList<T>(this string input, Func<string, T> func, char sep = ',') where T : class
        {
            List<T> result = new List<T>();
            string[] list = input.Split(sep);

            foreach (string s in list)
            {
                result.Add(func(s));
            }
            return result;
        }

        public static List<T> CreateList<T>(this string input, char sep = ',') where T : struct
        {
            List<T> result = new List<T>();
            string[] list = input.Split(sep);

            foreach (string s in list)
            {
                result.Add(s.ParseSafe<T>());
            }
            return result;
        }

        public static string ToStringList<T>(this IList<T> items, string delimit = ",") where T : struct
        {
            var sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(delimit);
                }
                sb.Append(items[i].ToString());
            }

            return sb.ToString();
        }

        public static string ToStringList(this IList<string> items, string delimit = ",")
        {
           StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(delimit);
                }
                sb.Append(items[i].ToString());
            }

            return sb.ToString();
        }

        public static void AddIfNotEmpty(this IList<string> stringList, string item)
        {
            if (string.IsNullOrEmpty(item) || stringList == null)
                return;
            stringList.Add(item);
        }
        public static void AddIfNotNull<T>(this IList<T> list, T item) where T : class
        {
            if(item == null || list == null)
                return;

            list.Add(item);
        }
        public static int SafeCount<T>(this IList<T> list) where T : class
        {
            if (list == null)
                return 0;
            return list.Count;
        }
    }

}
