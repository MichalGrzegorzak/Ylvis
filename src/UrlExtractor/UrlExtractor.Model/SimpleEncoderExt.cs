using System;
using System.Text;

namespace UrlExtractor.Model
{
    public static class SimpleEncoderExt
    {
        public static string Encode (this string input)
        {
            return (Convert.ToBase64String(Encoding.Unicode.GetBytes(input)));
        }
        public static string Decode (this string input)
        {
            return (System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(input)));
        }
    }
}