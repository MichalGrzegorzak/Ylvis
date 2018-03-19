using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ylvis.Utils.Features.Paging
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Page<T, TResult>(this IQueryable<T> obj, int page, int pageSize, System.Linq.Expressions.Expression<Func<T, TResult>> keySelector, bool desc, out int rowsCount)
        {
            rowsCount = obj.Count();
            int skip = (page * pageSize);

            if (!desc)
                return obj.OrderBy(keySelector).Skip(skip).Take(pageSize).AsQueryable();
            else
                return obj.OrderByDescending(keySelector).Skip(skip).Take(pageSize).AsQueryable();
        }

        public static IQueryable<T> Page<T, TResult>(this IQueryable<T> obj, IPager pager, System.Linq.Expressions.Expression<Func<T, TResult>> keySelector)
        {
            int rowsCount = obj.Count();
            int skip = (pager.PageId * pager.PageSize);
            pager.BindData(rowsCount);

            if (!pager.SortDescending)
                return obj.OrderBy(keySelector).Skip(skip).Take(pager.PageSize).AsQueryable();
            else
                return obj.OrderByDescending(keySelector).Skip(skip).Take(pager.PageSize).AsQueryable();
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> obj, IPager pager)
        {
            int rowsCount = obj.Count();
            int skip = (pager.PageId*pager.PageSize);
            
            pager.BindData(rowsCount);
            return obj.Skip(skip).Take(pager.PageSize);
        }

        /// <summary>
        /// Extends method which allow to sort by string field name.
        /// Allow to use a relative object definition for sorting (ex:LinkedObject.FieldsName1)
        /// </summary>
        /// <typeparam name=”TEntity”>Current Object type for query</typeparam>
        /// <param name=”source”>list of defined object</param>
        /// <param name=”sortExpression”>string name of the field we want to sort by</param>
        /// <returns>Query sorted by sortExpression</returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(
            this IQueryable<TEntity> source, string sortExpression) where TEntity : class
        {
            var type = typeof(TEntity);
            // Remember that for ascending order GridView just returns the column name and
            // for descending it returns column name followed by DESC keyword 
            // Therefore we need to examine the sortExpression and separate out Column Name and
            // order (ASC/DESC) 
            string[] expressionParts = sortExpression.Split(' '); // Assuming sortExpression is like [ColumnName DESC] or [ColumnName] 
            string orderByProperty = expressionParts[0];
            string sortDirection = "ASC";
            string methodName = "OrderBy";
         

            //if sortDirection is descending 

            if (expressionParts.Length > 1 && expressionParts[1] == "DESC")
            {
                sortDirection = "Descending";
                methodName += sortDirection; // Add sort direction at the end of Method name 
            }

            MethodCallExpression resultExp = null;

            if (!orderByProperty.Contains("."))
            {
                var property = type.GetProperty(orderByProperty);
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);

                resultExp = Expression.Call(typeof(Queryable), methodName,
                                new Type[] { type, property.PropertyType },
                                source.Expression, Expression.Quote(orderByExp));
            }
            else
            {
                Type relationType = type.GetProperty(orderByProperty.Split('.')[0]).PropertyType;
                PropertyInfo relationProperty = type.GetProperty(orderByProperty.Split('.')[0]);
                PropertyInfo relationProperty2 = relationType.GetProperty(orderByProperty.Split('.')[1]);

                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, relationProperty);
                var propertyAccess2 = Expression.MakeMemberAccess(propertyAccess, relationProperty2);
                var orderByExp = Expression.Lambda(propertyAccess2, parameter);

                resultExp = Expression.Call(typeof(Queryable), methodName,
                                new Type[] { type, relationProperty2.PropertyType },
                                source.Expression, Expression.Quote(orderByExp));

            }

            return source.Provider.CreateQuery<TEntity>(resultExp);
        }

    }
}
