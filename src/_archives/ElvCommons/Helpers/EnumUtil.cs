using System;
namespace Helpers
{
    ///<summary>
    ///</summary>
    ///<typeparam name="T"></typeparam>
    public static class EnumUtil<T>
    {
        ///<summary>
        ///</summary>
        ///<param name="s"></param>
        ///<returns></returns>
        public static T Parse(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
    }
}
