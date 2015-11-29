using System;
using System.Linq;

namespace Ylvis.Utils.Features.AutoHashing
{
    public static class NhLinqExtensionMethods
    {
        public static bool IsUnique<T>(this IQueryable<T> query, T entity) where T : IAutoHash
        {
            entity.CalculateHash();
            if(entity.UniqueHash == 0) throw new Exception("How?");

            return !query.Any(x => x.UniqueHash == entity.UniqueHash);
            //var result = query.Where(x => x.UniqueHash == entity.UniqueHash);
            //if (result.Any())
            //    return false;
            //return true;
        }
    }
}