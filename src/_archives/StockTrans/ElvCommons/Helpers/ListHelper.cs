using System;
using System.Collections.Generic;

namespace Helpers
{
    /// <summary>
    /// Helps to make list from string -> word1|word2|word3
    /// </summary>
    public abstract class ListHelper
    {
        /// <summary>
        /// Makes the list from word1|word2|word3
        /// </summary>
        /// <param name="oneLine">word1|word2|word3</param>
        /// <returns>list of strings</returns>
        public static List<string> MakeList(string oneLine)
        {
            string[] array = oneLine.Split('|');
            return new List<string>(array);
        }

        /// <summary>
        /// Makes the string from list
        /// </summary>
        /// <param name="list">list of strings</param>
        /// <returns>word1|word2|word3</returns>
        public static string ListToLine<T>(List<T> list)
        {
            return ListToLine(list, "|");
        }

        public static string ListToLine<T>(List<T> list, string separator)
        {
            string result = "";
            foreach (T s in list)
            {
                result += s.ToString() + separator;
            }
            result = result.Remove(result.Length - 1, 1);
            return result;
        }

        /// <summary>
        /// Ares the lists equal (have same items)
        /// </summary>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <returns>equal or not</returns>
        public static bool AreListsEqual(List<string> list1, List<string> list2)
        {
            bool result = true;
            if (list1.Count != list2.Count)
                return false;

            foreach (string s in list1)
            {
                if (!list2.Contains(s))
                    return false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether specified id is in list
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="idList">The id separated list.</param>
        /// <param name="separator">The separator from the input list</param>
        /// <returns>
        /// true if is in the list otherwise false
        /// </returns>
        public static bool IsOnList(int id, string idList, params char[] separator)
        {
            string[] list = idList.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in list)
            {
                if (s == id.ToString())
                    return true;
            }
            return false;
        }
    }
}
