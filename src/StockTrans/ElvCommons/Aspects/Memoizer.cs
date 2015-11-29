using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;

namespace Core.Aspects
{
 // USE CASE
 //static int factorial(int n)  
 //{  
 //    return n < 2 ? 1 : n * factorial(n - 1);  
 //}  
   
 //// test cases  
 ////factorial(7);  
 ////factorial(9);  
 ////factorial(9); 

    public static class Memoizer
    {
        // private field to store memos
        private static Dictionary<string, object> memos = new Dictionary<string, object>();

        // PostSharp needs  this to be serializable
        [Serializable]
        public class Memoized : OnMethodInvocationAspect
        {
            // intercept the method invocation
            public override void OnInvocation(MethodInvocationEventArgs eventArgs)
            {
                // get the arguments that were passed to the method
                object[] args = eventArgs.GetArgumentArray();

                // start building a key based on the method name
                // because it wouldn't help to return the same value
                // every time "lulu" was passed to any method
                StringBuilder keyBuilder = new StringBuilder(eventArgs.Delegate.Method.Name);

                // append the hashcode of each arg to the key
                // this limits us to value types (and strings)
                // i need a better way to do this (and preferably
                // a faster one)
                for (int i = 0; i < args.Length; i++)
                    keyBuilder.Append(args[i].GetHashCode());

                string key = keyBuilder.ToString();

                // if the key doesn't exist, invoke the original method
                // passing the original arguments and store the result
                if (!memos.ContainsKey(key))
                    memos[key] = eventArgs.Delegate.DynamicInvoke(args);

                // return the memo
                eventArgs.ReturnValue = memos[key];
            }
        }
    }
}
