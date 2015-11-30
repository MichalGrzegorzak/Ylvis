using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ylvis.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string EnsureFullPath(this string path, string rootPath)
        {
            if (path.StartsWith(@"\"))
            {
                string strFinalPath = string.Empty;
                string normalizedFirstPath = rootPath.TrimEnd(new char[] { '\\' });
                string normalizedSecondPath = path.TrimStart(new char[] { '\\' });
                strFinalPath = Path.Combine(normalizedFirstPath, normalizedSecondPath);
                return strFinalPath;
            }
            //return Path.Combine(rootPath, path);
            return path;
        }
        
        public static bool EqualsIgnCase(this string input, string value)
        {
            return input.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool ContainsIgnCase(this string input, string value)
        {
            return input.Contains(value, StringComparison.InvariantCultureIgnoreCase);
        }
        public static string AddIfNotBeggingWith(this string input, string add = "ul.")
        {
            string check = add.Replace(".", "");
            if (input.StartsWith(check, StringComparison.InvariantCultureIgnoreCase))
                return input;
            return add + " " + input;
        }

        public static string ReplaceWhitespaces(this string input, string to = " ", string ifNullThenReturn = "")
        {
            if (input == null)
                return ifNullThenReturn;

            input = input.Replace("\\n", "");
            string from = @"\s+"; //any whitespaces
            input = Regex.Replace(input, from, to, RegexOptions.None);
            return input;
        }
        
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

        //public static string HtmlEncode(this string text)
        //{
        //    return System.Web.HttpUtility.HtmlEncode(text);
        //}

        // Enable quick and more natural string.Format calls
        public static string Frmt(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static string AddSpacesAfterGroup(this string s, int group = 4)
        {
            string result = string.Empty;
            //int pointer = 0;
            while (s.Length >= group)
            {
                string part = s.Substring(0, group);
                s = s.Substring(group);

                result = result + part + " ";
            }
            result += s;
            result = result.Trim();
            return result;
        }

        public static string AdvReplace(this string s, string find, string replaceWithThis = "")
        {
            if (!IsNotNullOrEmpty(s))
                return null;

            return s.Replace(find, replaceWithThis);
        }
        public static string AdvReplaceIgnoreCase(this string s, string find, string replaceWithThis = "")
        {
            if (!IsNotNullOrEmpty(s))
                return null;

            return s.ToLower().Replace(find.ToLower(), replaceWithThis.ToLower());
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
        //public static string CutBetween(this string input, string begin, params string[] end)
        //{
        //    string result = "";

        //    int idx = input.IndexOf(begin) + begin.Length;
        //    input = input.Substring(idx);
        //    int edx = -1;
        //    foreach (string s in end)
        //    {
        //        if (input.IndexOf(s) > 0)
        //        {
        //            edx = input.IndexOf(s);
        //            break;
        //        }
        //    }

        //    if (edx > -1)
        //        result = input.Substring(0, edx);

        //    return result;
        //}
        public static string Reverse(this string input)
        {
            if (IsNotNullOrEmptyT(input))
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
            if (IsNotNullOrEmptyT(input))
            {
                input = Reverse(input);
                character = Reverse(character);
                int idx = input.IndexOf(character);
                if (idx > -1)
                {
                    input = input.Substring(idx + character.Length);
                }

                input = Reverse(input);
            }
            return input;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
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
            if(IsNotNullOrEmptyT(input))
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

        ///// <summary>
        ///// Constructs a NameValueCollection into a query string.
        ///// </summary>
        ///// <remarks>Consider this method to be the opposite of "System.Web.HttpUtility.ParseQueryString"</remarks>
        ///// <param name="parameters">The NameValueCollection</param>
        ///// <param name="delimiter">The String to delimit the key/value pairs</param>
        ///// <returns>A key/value structured query string, delimited by the specified String</returns>
        //public static string ToQueryString(this NameValueCollection parameters, String delimiter, Boolean omitEmpty)
        //{
        //    if (String.IsNullOrEmpty(delimiter))
        //        delimiter = "&";

        //    Char equals = '=';
        //    List<String> items = new List<String>();

        //    for (int i = 0; i < parameters.Count; i++)
        //    {
        //        foreach (String value in parameters.GetValues(i))
        //        {
        //            Boolean addValue = (omitEmpty) ? !String.IsNullOrEmpty(value) : true;
        //            if (addValue)
        //                items.Add(String.Concat(parameters.GetKey(i), equals, HttpUtility.UrlEncode(value)));
        //        }
        //    }

        //    return String.Join(delimiter, items.ToArray());
        //}


        public static string GetResizedImage(this string val, int width, int height)
        {
            if (string.IsNullOrEmpty(val))
                return val;


            var imgUrl = string.IsNullOrEmpty(val) ? string.Empty : string.Format("{0}?w={1}&h={2}", val, width,height);
            return imgUrl;
        }

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        // Add trailing slash at the end of the url if there's none
        public static string WithTrailingSlash(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return url;

            string urlWithTrailing = url;

            if (!urlWithTrailing.EndsWith("/"))
            {
                urlWithTrailing += "/";
            }

            return urlWithTrailing;
        }

        public static string RemovePolishAccent(this string txt)
        {
            char[] tekst = txt.ToCharArray();
            for (int i = 0; i < tekst.Length; i++)
            {
                switch (tekst[i])
                {
                    case 'ą': tekst[i] = 'a'; break;
                    case 'Ą': tekst[i] = 'A'; break;
                    case 'ę': tekst[i] = 'e'; break;
                    case 'Ę': tekst[i] = 'E'; break;
                    case 'ś': tekst[i] = 's'; break;
                    case 'Ś': tekst[i] = 'S'; break;
                    case 'ż': tekst[i] = 'z'; break;
                    case 'Ż': tekst[i] = 'Z'; break;
                    case 'ć': tekst[i] = 'c'; break;
                    case 'Ć': tekst[i] = 'C'; break;
                    case 'ź': tekst[i] = 'z'; break;
                    case 'Ź': tekst[i] = 'Z'; break;
                    case 'ń': tekst[i] = 'n'; break;
                    case 'Ń': tekst[i] = 'N'; break;
                    case 'ó': tekst[i] = 'o'; break;
                    case 'Ó': tekst[i] = 'O'; break;
                    case 'ł': tekst[i] = 'l'; break;
                    case 'Ł': tekst[i] = 'L'; break;
                    default: break;

                }

            }
            return new string(tekst);
        }

        public static string DoFormat(this decimal value)
        {
            var s = string.Format("{0:0.00}", value);

            if (s.EndsWith("00"))
            {
                return ((int)value).ToString();
            }
            else
            {
                return s;
            }
        }

        public static int GetIndexOfUpperChar(this string input)
        {
            int index = -1;
            foreach (Char c in input)
            {
                if (Char.IsUpper(c)) break;
                index++;
            }
            return index;
        }

        public static IEnumerable<int> GetIndexesOfUpperChar(this string input)
        {
            return (from ch in input.ToArray()
                    where Char.IsUpper(ch)
                    select input.IndexOf(ch));
        }

        public static string UnwindPropName(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            if (input.Length < 4)
                return input;

            string result = string.Empty;
            input = input.FirstCharToUpper();

            var indexes = input.GetIndexesOfUpperChar().ToList();
            if (indexes.Count() > 1)
            {
                if (indexes.Count() == 2)
                {
                    string first = input.Substring(0, indexes[1]).FirstCharToUpper();
                    string second = input.Substring(indexes[1]);
                    if (!Char.IsUpper(second[1])) //if (!second.Contains("VAT"))
                        second = second.ToLower();

                    return result = first + " " + second;
                }

                var chars = new List<char>();
                chars.Add(input[0]);
                bool found = false; //had problem with FakturaVAT

                foreach (char c in input.Substring(1))
                {
                    if (Char.IsUpper(c) && !found)
                    {
                        chars.Add(' ');
                        found = true;
                    }
                    chars.Add(c);
                }
                result = new string(chars.ToArray());
            }
            else
            {
                result = input;
            }
            return result;

        }

        public static string RemoveAllOf(this string input, params string[] slowa)
        {
            return ReplaceAllOf(input, "", slowa);
        }
        public static string ReplaceAllOf(this string input, string to, params string[] slowa)
        {
            foreach (string s in slowa)
            {
                input = input.Replace(s, to);
            }
            return input;
        }
        public static string ReplaceAllOf(this string input, char to, params char[] znaki)
        {
            foreach (char c in znaki)
            {
                input = input.Replace(c, to);
            }
            return input;
        }

        public static bool IsExistAny(this string input, params char[] znaki)
        {
            foreach (char c in znaki)
            {
                if (input.IndexOf(c) > -1)
                    return true;
            }
            return false;
        }

        public static bool ContainsAnyOf(this string input, params string[] words)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (string s in words)
            {
                if (input.Contains(s, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        public static bool ContainsAnyOf(this string input, IEnumerable<string> list)
        {
            return ContainsAnyOf(input, list.ToArray());
        }

        public static bool ContainsOneOf(this string input, params string[] slowa)
        {
            foreach (string s in slowa)
            {
                if (input.Contains(s))
                    return true;
            }
            return false;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string GetFileName(this string filePath)
        {
            var fInfo = new FileInfo(filePath);
            return fInfo.Name;
        }

        /// <summary>
        /// Capitalize only the first letter
        /// </summary>
        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        /// <summary>
        /// Capitalize each word in whole sentence
        /// </summary>
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string ToStringSafe(this DateTime? date, string emptyResult = "", string format = "dd-MM-yyyy" )
        {
            if (date.HasValue)
                return date.Value.ToShortDate(format);
            return emptyResult;
        }
        public static string ToShortDate(this DateTime date, string format = "dd-MM-yyyy")
        {
            return date.ToString(format);
        }


        public static string RegexOnlyDigits(this string input, params char[] additionally)
        {
            //"y0urstr1ngW1thNumb3rs".Where(x => Char.IsDigit(x)).ToArray()); //linq alterbative

            string regex = @"[^0-9{0}]*";
            regex = regex.Frmt(AddFromArray(additionally));

            var reg = new Regex(regex, RegexOptions.Compiled);
            return RegexRemove(input, reg);
        }

        private static string AddFromArray(char[] additionally)
        {
            string result = "";
            foreach (char c in additionally)
                result += c;

            return result;
        }
        public static string RegexOnlyLetters(this string input, params char[] additionally)
        {
            //Char.IsLetter for linq
            string regex = @"[^A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ{0}]*";
            regex = regex.Frmt(AddFromArray(additionally));

            var reg = new Regex(regex, RegexOptions.Compiled);
            return RegexRemove(input, reg);
        }

        public static string ClearText(this string input)
        {
            input = input.Trim();
            input = input.Replace("  ", " ");
            input = input.Replace("  ", " ");
            input = input.RemoveAllOf(";", ":");
            return input;
        }

        public static string RegexRemove(this string input, Regex reg)
        {
            return input = reg.Replace(input, "");
        }

        //public static int[ ] ExtractInts( this string s )
        //{
        //    return s.REExtract<int>( @"\d+" );
        //}
        //int[] a = "Some primes: 2, 5, 11, and 17".ExtractInts();
        //// a == { 2, 5, 11, 17 }
        /// <summary>
        /// look up
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static T[] REExtract<T>(this string s, string regex)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            if (!tc.CanConvertFrom(typeof(string)))
            {
                throw new ArgumentException("Type does not have a TypeConverter from string", "T");
            }
            if (!string.IsNullOrEmpty(s))
            {
                return
                    Regex.Matches(s, regex)
                    .Cast<Match>()
                    .Select(f => f.ToString())
                    .Select(f => (T)tc.ConvertFrom(f))
                    .ToArray();
            }
            else
                return new T[0];
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
                string r = s.ToString();
                if (typeof(T) == typeof(DateTime))
                {
                    r = r.Replace(" 00:00:00", "");
                }
                result += r + separator;
            }

            if (result.Length > 1) //usun ostatni separator
                result = result.Remove(result.Length - 1, 1);

            return result;
        }

        public static bool IsSame(this string input, string other)
        {
            if (!input.IsNotNullOrEmptyT() || !other.IsNotNullOrEmptyT())
                throw new Exception("Nie moze byc null or empty!");

            input = input.Trim().ToLower();
            other = other.Trim().ToLower();

            if (input == other)
                return true;

            return false;
        }

        public static void BreakIfMatch(this string input, params string[] items)
        {
            if (input.ContainsAnyOf(items))
                if (Debugger.IsAttached)
                    Debugger.Break();
        }

        public static string UnCamelCase(string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            /* Note that the .ToString() is required, otherwise the char is implicitly
             * converted to an integer and the wrong overloaded ctor is used */
            var sb = new StringBuilder(str[0].ToString());
            for (int i = 1; i < str.Length; i++)
            {
                if (char.IsUpper(str, i))
                    sb.Append(" ");
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

    }
}
