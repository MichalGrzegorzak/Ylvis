using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ylvis.Utils.Extensions;

namespace Ylvis.Utils.Features.Hashes
{
    public static class HashHelper
    {
        static readonly List<string> skipProperties = new List<string>()
        {
            //"Id", "UniqueHash"
        };

        static HashHelper()
        {
        }

        public static int Hash(object obj)
        {
            var seen = new HashSet<object>();
            var propValues = GetAllSimpleProperties(obj, seen);

            return SerializeToByteAndCalculateHash(propValues);
        }

        //public static int Hash<T>(T entity) where T : class
        //{
        //    var seen = new HashSet<object>();
        //    var propValues = GetAllSimpleProperties(entity, seen);

        //    return SerializeToByteAndCalculateHash(propValues);

        //    //var byteArray = properties.Select(p => BitConverter.GetBytes(p.GetHashCode()).AsEnumerable()).Aggregate((ag, next) => ag.Concat(next)).ToArray();
        //    //return ComputeHash(byteArray);
        //}

        private static int SerializeToByteAndCalculateHash(IEnumerable<dynamic> propValues)
        {
            IEnumerable<byte> arrBytes = new List<byte>().ToArray();
            foreach (var value in propValues)
            {
                byte[] arr = BitConverter.GetBytes(value.GetHashCode());
                arrBytes = arrBytes.Concat(arr);
            }
            return ComputeHash(arrBytes.ToArray());
        }

        private static IEnumerable<dynamic> GetAllSimpleProperties(object obj, HashSet<object> seen)
        {
            foreach (PropertyInfo pinfo in obj.GetType().GetProperties()
                .Where(p =>!skipProperties.Contains(p.Name) ))
            {
                var getMethod = pinfo.GetGetMethod();
                dynamic value = getMethod.Invoke(obj, null);
                if(value == null)
                    continue;

                if (value is int || value is long || value is string
                    || value is decimal || value is double || value is bool
                    || value is Enum || value is DateTime
                    )
                    yield return value;
                else if (seen.Add(value)) // Handle cyclic references
                {
                    foreach (var simple in GetAllSimpleProperties(value, seen))
                        yield return simple;
                }
            }
        }

        private static IEnumerable<dynamic> GetAllSimpleProperties<T>(T entity, HashSet<object> seen)  where T : class
        {
            foreach (var property in PropertiesOf<T>.All(entity))
            {
                if (property is int || property is long || property is string 
                    || property is decimal || property is double || property is bool
                    || property is Enum || property is DateTime? || property is DateTime
                    ) 
                     yield return property;
                else if (seen.Add(property)) // Handle cyclic references
                {
                    foreach (var simple in GetAllSimpleProperties(property, seen)) 
                        yield return simple;
                }
            }
        }

        private static class PropertiesOf<T> where T : class
        {
            private static readonly List<Func<T, object>> Properties = new List<Func<T, object>>();

            static PropertiesOf()
            {
                var properties = typeof (T).GetProperties()
                    .Where(p => p.CanRead && !skipProperties.Contains(p.Name))
                    .Where(p => Attribute.IsDefined(p, typeof(DontHash)));

                foreach (var prop in properties)
                {
                    var lambda = prop.GetValueGetter<T>();
                    Properties.Add(lambda);
                }
            }

            public static IEnumerable<dynamic> All(T entity)
            {
                return Properties.Select(p => p(entity)).Where(v => v != null);
            }
        }

        private static int ComputeHash(params byte[] data)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;

                for (int i = 0; i < data.Length; i++)
                    hash = (hash ^ data[i]) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }
    }

}
