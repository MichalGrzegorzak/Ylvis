using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Ylvis.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfEnumValue<T>(this object enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.EmptyIfNull().Any() ? (T)attributes[0] : null;
        }

        public static T GetEnumFromDescription<T>(string description)
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                var attribute =
                    Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description) return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description) return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }

        public static Dictionary<T, string> EnumDescriptionsToDictionary<T>()
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            var result = new Dictionary<T, string>();
            foreach (var v in values)
            {
                var desc = EnumExtensions.GetAttributeOfEnumValue<System.ComponentModel.DescriptionAttribute>(v);
                if (desc != null)
                    result.Add(v, desc.Description);
            }
            return result;
        }

        public static ICollection<T> GetValues<T>()
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return values;
        }

        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();

        }

        //public static bool ContainsAny(this string haystack, params string[] needles)
        //{
        //    foreach (string needle in needles)
        //    {
        //        if (haystack.Contains(needle))
        //            return true;
        //    }

        //    return false;
        //}
    }
}
