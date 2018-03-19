using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ylvis.Utils.Extensions
{
    public static class ObjectExtension
    {
        //public static string ToStringSafe<T>(this T obj)
        //{
        //    return (obj == null) ? string.Empty : obj.ToString();
        //}

        /// <summary>
        /// Clone an object without any references of nhibernate
        /// </summary> 
        public static T Copy<T>(this object obj)
        {
            var isNotSerializable = !typeof(T).IsSerializable;
            if (isNotSerializable)
                throw new ArgumentException("The type must be serializable.", "source");

            var sourceIsNull = ReferenceEquals(obj, null);
            if (sourceIsNull)
                return default(T);

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        //ToStringSafe
        public static string ToStringSafe(this object obj)
        {
            return (obj == null) ? string.Empty : obj.ToString();
        }
    }
}
