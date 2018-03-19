using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ylvis.Utils.Features.Reflection
{
    public static class PropertyResolver
    {
        public static string GetMemberName<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                string name = member.ToString();
                string[] arr = name.Split('.');
                
                if (arr.Length == 2)
                    name = arr[1];
                else
                {
                    name = name.Substring(name.IndexOf('.') + 1);
                }
                return name;
            }
            throw new ArgumentException("expression");
        }

        public static Type GetMemberType<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                var propInfo = member.Member as PropertyInfo;
                return propInfo.PropertyType;
            }
            throw new ArgumentException("expression");
        }
    }
}
