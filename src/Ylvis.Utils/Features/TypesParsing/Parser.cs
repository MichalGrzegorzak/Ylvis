using System;
using System.ComponentModel;

namespace Ylvis.Utils.Features.TypesParsing
{
    /// <summary>
    /// String Parse extensions
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parsing by typeconverter, can throw exception
        /// </summary>
        public static T Parse<T>(this string value)
        {
            // Get default value for type so if string is empty then we can return default value.
            T result = default(T);
            
            result = Parsing<T>(value, false);
            return result;
        }

        private static T Parsing<T>(string value, bool checkFirst)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Trim().Trim(',', '.', ';', ':');
                value = value.Replace(" ", "");

                if (typeof(T) == typeof(DateTime))
                    throw new Exception("Not supported type, use special method!");
                if (typeof (T) == typeof (decimal) || typeof(T) == typeof(decimal?))
                    checkFirst = false;

                // we are not going to handle exception here
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                if(checkFirst)
                {
                    if (!tc.IsValid(value))
                        return default(T);
                }
                return (T)tc.ConvertFrom(value);
                //return (T)tc.ConvertFromInvariantString(value);
            }
            return default(T);
        }

        /// <summary>
        /// Safe parse but it swallow exception (!!!) and returns default value of type
        /// Handle with care
        /// </summary>
        public static T ParseSafe<T>(this string value)
        {
            T result = default(T);

            // Get default value for type so if string
            // is empty then we can return default value.
            try
            {
                result = Parsing<T>(value, true);
            }
            catch (Exception)
            {
                //swallowing exception !!!
            }

            return result;
        }

        public static DateTime? ParseToDate(this string value, bool after1900 = true)
        {
            var val = DateHelper.CreateDate(value);

            if (after1900)
            {
                if (val < new DateTime(1900, 1, 1))
                    return null;
            }

            return val;
        }

        public static T ParseToEnum<T>(this string value, T orDefault)
        {
            if (string.IsNullOrEmpty(value))
                return orDefault;
            else
                return ParseToEnum<T>(value);
        }

        public static T ParseToEnum<T>(this string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            
            value = value.Trim();
            if (value.Length == 0)
                throw new ArgumentException("Must specify valid information for parsing in the string.", "value");
            
            Type t = typeof(T);
            if (!t.IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");
            
            T enumType = (T)Enum.Parse(t, value, true);
            return enumType;
        }
    }
}
