using System;
using System.ComponentModel;

namespace Showoff.Core.Features.Extensions
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

            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(" ", "");

                // we are not going to handle exception here
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                result = (T)tc.ConvertFrom(value);
            }

            return result;
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
                result = Parse<T>(value);
            }
            catch (Exception)
            {
                //swallowing exception !!!
            }

            return result;
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

        public static T ParseToEnumSafe<T>(this string value, T defaultResult = default(T))
        {
            var result = defaultResult;

            try
            {
                result = value.ParseToEnum<T>();
            }
            catch (Exception)
            {
                //swallowing exception !!!
            }

            return result;
        }
    }
}
