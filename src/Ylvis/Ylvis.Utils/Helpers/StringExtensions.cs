using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netizens.ExtensionsLib
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        
        public static string Truncate(this string text, int length, string ending, bool keepFullWordAtEnd)
        {
            if(text.IsNullOrEmpty())
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


    }
}
