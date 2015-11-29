using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ylvis.Utils.Features.Reflection
{
    public abstract class ReflectClassFind
    {
        public static List<Type> AllDerivedTypes<T>()
        {
            return AllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        public static List<Type> AllDerivedTypes<T>(Assembly assembly)
        {
            var derivedType = typeof(T);
            return assembly
                .GetTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t)
                    ).ToList();

        }
    }
}
