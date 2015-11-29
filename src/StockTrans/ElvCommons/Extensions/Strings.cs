using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Commons.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string text)
        {
            return !string.IsNullOrEmpty(text);
        }

        public static bool IsNotNullOrEmptyT(this string text)
        {
            if (!string.IsNullOrEmpty(text))
                text = text.Trim();

            return !string.IsNullOrEmpty(text);
        }

        public static string Truncate(this string text, int length, string ending, bool keepFullWordAtEnd)
        {
            if (!text.IsNotNullOrEmpty())
                return string.Empty;

            if (text.Length < length)
                return text;

            text = text.Substring(0, length);

            if (keepFullWordAtEnd)
            {
                text = text.Substring(0, text.LastIndexOf(' '));
            }

            return text + ending;
        }

        public static string Substring(this string text, string fromAWord)
        {
            int idx = text.IndexOf(fromAWord);
            if (idx > 0)
            {
                idx = idx + fromAWord.Length;
                text = text.Substring(idx);
            }
            return text;
        }

        public static string HtmlEncode(this string text)
        {
            return System.Web.HttpUtility.HtmlEncode(text);
        }

        // Enable quick and more natural string.Format calls
        public static string Frmt(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static string CutBetween(this string input, string begin, params string[] end)
        {
            string result = "";

            int idx = input.IndexOf(begin) + begin.Length;
            input = input.Substring(idx);
            int edx = -1;
            foreach (string s in end)
            {
                if(input.IndexOf(s) > 0)
                {
                    edx = input.IndexOf(s);
                    break;
                }
            }

            if(idx > -1 && edx > -1)
                result = input.Substring(idx, edx);

            return result;
            //transakcje: FW20Z09 S 3*1900
        }

        /// <summary>
        /// Makes the string from list
        /// </summary>
        /// <param name="list">list of strings</param>
        /// <returns>word1|word2|word3</returns>
        public static string ToLine<T>(this List<T> list)
        {
            return ToLine(list, "|");
        }

        public static string ToLine<T>(this List<T> list, string separator)
        {
            string result = "";
            foreach (T s in list)
            {
                result += s.ToString() + separator;
            }
            result = result.Remove(result.Length - 1, 1);
            return result;
        }
    }
}
