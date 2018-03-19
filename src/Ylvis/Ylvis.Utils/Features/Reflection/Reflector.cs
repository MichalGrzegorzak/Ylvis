using System;
using System.Linq.Expressions;
using System.Reflection;
using Ylvis.Utils.Extensions;

namespace Ylvis.Utils.Features.Reflection
{
    public class Reflector<TSource>
    {
        private TSource source;
        Type type = typeof(TSource);

        public Reflector(TSource source)
        {
            this.source = source;
        }
        
        public string Name { get; protected set; }
        public object Value { get; set; }
        public Type Type { get; protected set; }
        public PropertyInfo PropInfo { get; protected set; }
        public object Default  { get { return GetDefault(Type); } }
        

        public PropertyInfo GetPropertyInfo<TProperty>(
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                UnaryExpression unaryExpr = propertyLambda.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    member = unaryExpr.Operand as MemberExpression;
            }
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (!propInfo.ReflectedType.IsAssignableFrom(type))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }

        public void ReflectExp<TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            GetValue(propertyLambda);
        }

        private void GetValue<TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            PropInfo = GetPropertyInfo(propertyLambda);

            Name = PropInfo.Name;
            Type = PropInfo.PropertyType;
            
            var lambda = PropInfo.GetValueGetter<TSource>();
            Value = lambda(source);
            //return value;
        }

        public object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        //public object GetValue<TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        //{
        //    var member = propertyLambda.Body as MemberExpression;
        //    if (member == null)
        //        throw new ArgumentException(string.Format(
        //            "Expression '{0}' refers to a method, not a property.",
        //            propertyLambda.ToString()));

        //    var objectMember = Expression.Convert(member, typeof(object));
        //    var getterLambda = Expression.Lambda<Func<object>>(objectMember);
        //    var getter = getterLambda.Compile();

        //    return getter();
        //}

    }
}
