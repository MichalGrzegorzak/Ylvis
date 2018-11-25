using System;
using System.Collections.Generic;
using System.Text;

namespace Showoff.Core.Features.Extensions
{
    public static class ListExtension
    {
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
            System.Text.StringBuilder sb = new StringBuilder();

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



    }

}
