using System.Collections.Generic;

namespace elvSplitter
{
    public static class EnumerableDebugger
    {
        public static IEnumerable<T> Watch<T>(this IEnumerable<T> input)
        {
            return input;
        }
    }
}