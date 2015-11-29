using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Commons.Extensions
{
    /// <summary>
    /// String Parse extensions
    /// </summary>
    public static class Parser
    {
        public static T Parse<T>(this string value)
        {
            // Get default value for type so if string
            // is empty then we can return default value.
            T result = default(T);

            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(" ", "");

                //if (typeof(T) == typeof(DateTime))
                //{
                //    if (value.IndexOf("-") == 2)
                //    {
                //        string[] splitted = value.Split(new char[] { '-', ' ' });
                //        string dd = splitted[0];
                //        string mm = splitted[1];
                //        string yyyy = splitted[2];
                //        string time = "";
                //        if (splitted.Length == 4) //has time
                //        {
                //            time = splitted[3];
                //        }

                //        value = yyyy + "-" + mm + "-" + dd + " " + time;
                //    }
                //}

                // we are not going to handle exception here
                // if you need SafeParse then you should create
                // another method specially for that.
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                result = (T)tc.ConvertFrom(value);
            }

            return result;
        }

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
                result = default(T);
            }

            return result;
        }
    }

//    public class GenericConverter
//{
//    public static T Parse<T>(string sourceValue) where T : IConvertible
//    {
//      return (T)Convert.ChangeType(sourceValue, typeof(T));
//    }

//    public static T Parse<T>(string sourceValue, IFormatProvider provider) where T : IConvertible
//    {
//      return (T)Convert.ChangeType(sourceValue, typeof(T), provider);
//    }
//}

////Usage
//DateTime datetime = GenericConverter.Parse<DateTime>("12.10.2007");


//IFormatProvider providerEN = new System.Globalization.CultureInfo("en-US", true);
//IFormatProvider providerTR = new System.Globalization.CultureInfo("tr-TR", true);

//DateTime x = GenericConverter.Parse<DateTime>("12.10.2007", providerTR); // ddMMyyyy
//DateTime y = GenericConverter.Parse<DateTime>("12.10.2007", providerEN); // MMddyyyy

//int iValue = GenericConverter.Parse<int>("12");

}

//public static T EnumParse<T>(this string value)
//{
//    return EnumHelper.EnumParse<T>(value, false);
//}
//public static T EnumParse<T>(this string value, bool ignoreCase)
//{
//    if (value == null)
//    {
//       throw new ArgumentNullException("value");
//   }
//   value = value.Trim();
//   if (value.Length == 0)
//   {
//       throw new ArgumentException("Must specify valid information for parsing in the string.", "value");
//   }
//   Type t = typeof(T);
//   if (!t.IsEnum)
//   {
//       throw new ArgumentException("Type provided must be an Enum.", "T");
//   }
//   T enumType = (T)Enum.Parse(t, value, ignoreCase);
//   return enumType;
//}
