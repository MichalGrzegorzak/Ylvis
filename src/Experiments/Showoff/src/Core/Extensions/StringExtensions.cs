using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using EPiServer;

namespace Showoff.Core.Features.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceInsensitive(this string str, string from, string to)
        {
            str = Regex.Replace(str, from, to, RegexOptions.IgnoreCase);
            return str;
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search, StringComparison.InvariantCulture);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


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
            if (string.IsNullOrEmpty(text))
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

        public static string SafeSubstring(this string input, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Length >= (startIndex + length))
            {
                return input.Substring(startIndex, length);
            }
            else
            {
                if (input.Length > startIndex)
                {
                    return input.Substring(startIndex);
                }
                else
                {
                    return string.Empty;
                }
            }
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

        public static string AdvReplace(this string s, string find, string replaceWithThis)
        {
            if(s.IsNotNullOrEmpty())
                return s.Replace(find, replaceWithThis);
            return s;
        }

        /// <summary>
        /// Makes the string from list
        /// </summary>
        /// <param name="list">list of strings</param>
        /// <returns>word1|word2|word3</returns>
        public static string ToLine<T>(this IList<T> list) where T : struct
        {
            return ToLine(list, "|");
        }

        public static string ToLine<T>(this IList<T> list, string separator) where T : struct
        {
            string result = "";
            if (list.Count == 0) return result;
            
            foreach (T s in list)
            {
                result += s.ToString() + separator;
            }
            result = result.Remove(result.Length - 1, 1);
            return result;
        }

        public static bool ContainsAnyOf(this string input, params string[] words)
        {
            if (string.IsNullOrEmpty(input)) return false;

            foreach(string s in words)
            {
                if(input.Contains(s))
                    return true;
            }
            return false;
        }

        public static bool ContainsAllOf(this string input, params string[] words)
        {
            if (string.IsNullOrEmpty(input)) return false;

            foreach(string s in words)
            {
                if(!input.Contains(s))
                    return false;
            }
            return true;
        }

        public static string RemoveAllOf(this string input, params string[] words)
        {
            foreach (string s in words)
            {
                input = input.Replace(s, "");
            }
            return input;
        }

        public static string CutBetween(this string input, string begin, params string[] end)
        {
            string result = "";

            int idx = input.IndexOf(begin) + begin.Length;
            input = input.Substring(idx);
            idx = 0;
            int edx = -1;
            foreach (string s in end)
            {
                if (input.IndexOf(s) > 0)
                {
                    edx = input.IndexOf(s);
                    break;
                }
            }

            if (idx > -1 && edx > -1)
                result = input.Substring(idx, edx);

            return result;
        }

        public static string Reverse(this string input)
        {
            if (input.IsNotNullOrEmptyT())
            {
                char[] arr = input.ToCharArray().Reverse().ToArray();
                input = new string(arr, 0, arr.Length);
            }
            return input;
        }

        public static string RemoveLast(this string input)
        {
            return input.Remove(input.Length - 1, 1);
        }

        public static string RemoveLast(this string input, string character)
        {
            if (input.IsNotNullOrEmptyT())
            {
                input = input.Reverse();
                character = character.Reverse();
                int idx = input.IndexOf(character);
                if (idx > -1)
                {
                    input = input.Substring(idx + character.Length);
                }

                input = input.Reverse();
            }
            return input;
        }

        public static bool Contains(this string input, params string[] list)
        {
            bool result = false;
            foreach (string s in list)
            {
                if (input.ToLower().Contains(s.ToLower()))
                    return true;
            }
            return result;
        }

        public static string ToUpperFirst(this string input)
        {
            if(input.IsNotNullOrEmptyT())
                input = input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
            return input;
        }

        public static string Combine(this string input)
        {
            input = input.Replace(":", "").Replace(" ", "").Replace("-", "").ToLower();
            return input;
        }

        public static string AddPostfixIf(this string input, string postfix, Predicate<string> predicate)
        {
            return predicate(input) ? input + postfix : input;
        }

        public static string AddPrefixIf(this string input, string prefix, Predicate<string> predicate)
        {
            return predicate(input) ? prefix + input : input;
        }

        public static int? ToIntOrNull(this string input)
        {
            int result;
            return int.TryParse(input, out result) ? (int?)result : null;
        }

        public static string PrefixHiglight(this string ths, string higlightPhrase, string higlightPreTag, string higlightPostTag)
        {
            if (!ths.StartsWith(higlightPhrase, StringComparison.CurrentCultureIgnoreCase))
                return ths;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            return sb.Append(higlightPreTag)
                        .Append(higlightPhrase)
                        .Append(higlightPostTag)
                        .Append(ths.Length > higlightPhrase.Length ? ths.Substring(higlightPhrase.Length) : "")
                        .ToString();
        }

        public static DateTime? toDate(this string dateTimeStr, string dateFmt = "dd-MM-yyyy")
        {
            // example: var dt="2011-03-21 13:26".toDate("yyyy-MM-dd HH:mm");
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            DateTime? result = null;
            DateTime dt;
            if (DateTime.TryParseExact(dateTimeStr, dateFmt,
                CultureInfo.InvariantCulture, style, out dt)) result = dt;
            return result;
        }

    }
}
