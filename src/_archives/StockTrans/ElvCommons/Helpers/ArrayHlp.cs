using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    /// <summary>
    /// Helper class to arrays
    /// (for object types reference must be the same!)
    /// </summary>
    public abstract class ArrayHlp
    {
        /// <summary>
        /// Check if array contains object or struct
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="obj">object to find</param>
        /// <param name="array">array of given type</param>
        /// <returns>true if find</returns>
        public static bool ArrayContains<T>(T obj, T[] array)
        {
            bool result = false;

            foreach (T element in array)
            {
                if (element.GetHashCode() == obj.GetHashCode())
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
