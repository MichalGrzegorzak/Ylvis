using System;

namespace Showoff.Core.Features.Extensions
{
    public static class EnumExtension
    {
        private static void ThrowIfNotEnumType<TEnum>()
             where TEnum : struct, IConvertible, IComparable, IFormattable // there's no enum constraint - this is the best approximation
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum is not an enum type.");
        }

        public static TEnum ParseEnumOrDefault<TEnum>(this string value, bool ignoreCase = false) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            ThrowIfNotEnumType<TEnum>();

            TEnum result;
            return Enum.TryParse<TEnum>(value, ignoreCase, out result) ? result : default(TEnum);
        }

        public static TEnum ParseEnumOrDefault<TEnum>(this int value, bool ignoreCase = false) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            ThrowIfNotEnumType<TEnum>();

            return value.ToString().ParseEnumOrDefault<TEnum>(ignoreCase);
        }

        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            ThrowIfNotEnumType<TEnum>();

            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
}
