using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections.Generic;
using System.Linq;

namespace Showoff.Web.Core.Extensions
{
    public static class GroupsConversionExtension
    {
        public static IEnumerable<T> ToFlat<T>(this IEnumerable<IEnumerable<T>> ths)
        {
            if (ths == null)
                return new List<T>();

            var query = new T[0].Select(itm => itm);
            foreach (var group in ths)
            {
                query = query.Union(group.Select(itm => itm));
            }
            return query.ToList();
        }


        public static IEnumerable<IEnumerable<T>> Relocate<T>(this IEnumerable<IEnumerable<T>> ths, int groupCapacity)
        {
            var flatCollection = ths.ToFlat();
            var len = flatCollection.Count();

            List<IEnumerable<T>> list = new List<IEnumerable<T>>();
            int index = 0;
            while (index * groupCapacity <= len)
            {
                list.Add(flatCollection.Skip(groupCapacity * index).Take(groupCapacity));
                index++;
            }
            return list;
        }

        public static IEnumerable<IEnumerable<T>> Locate<T>(this IEnumerable<T> ths, int groupCapacity)
        {
            var flatCollection = ths;
            var len = flatCollection.Count();

            List<IEnumerable<T>> list = new List<IEnumerable<T>>();
            int index = 0;
            while (index * groupCapacity <= len)
            {
                list.Add(flatCollection.Skip(groupCapacity * index).Take(groupCapacity));
                index++;
            }
            return list;
        }

    }
}