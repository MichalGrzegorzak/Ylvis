using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Aegon.Features.Reflection
{
    public class AssemblyReflector
    {
        private readonly Type[] _assemblyTypes;

        private static AssemblyReflector _instance;
        public static AssemblyReflector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AssemblyReflector(Assembly.GetExecutingAssembly());
                return _instance;
            }
        }

        public AssemblyReflector(Assembly assembly)
        {
            _assemblyTypes = assembly.GetTypes();
        }

        public IEnumerable<Type> GetClasses<TClass>()
        {
            var classType = typeof(TClass);
            return _assemblyTypes.Where(x => classType.IsAssignableFrom(x) && x.IsClass);
        }

        public TAttribute GetTypeAttribute<TAttribute>(Type type) where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute);
            return type.GetCustomAttributes(attributeType, false).FirstOrDefault() as TAttribute;
        }

        public TAttribute GetPropertyAttribute<TAttribute>(PropertyInfo propertyInfo) where TAttribute : Attribute
        {
            var attributeType = typeof(TAttribute);
            return propertyInfo.GetCustomAttributes(attributeType, false).FirstOrDefault() as TAttribute;
        }
    }
}
