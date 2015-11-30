using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Laos;

namespace Core.Aspects
{
    [Serializable]
    public class AsyncAttribute : OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            ThreadPool.QueueUserWorkItem(delegate { eventArgs.Proceed(); });
        }
    }
}
