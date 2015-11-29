using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;
using System.Windows.Threading;

namespace Core.Aspects
{
    [Serializable]
    public class GuiThreadAttribute : OnMethodInvocationAspect
    {
        //public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        //{
        //    DispatcherObject dispatcherObject = (DispatcherObject)eventArgs.Delegate.Target;
        //    if (dispatcherObject.CheckAccess())
        //        eventArgs.Proceed();
        //    else
        //        dispatcherObject.Dispatcher.Invoke(DispatcherPriority.Normal,
        //                                            new Action(() => eventArgs.Proceed()));
        //}

        //public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        //{
        //    eventArgs.Instance.
        //    if (dispatcherObject.CheckAccess())
        //        eventArgs.Proceed();
        //    else
        //        dispatcherObject.Dispatcher.Invoke(DispatcherPriority.Normal,
        //                                            new Action(() => eventArgs.Proceed()));
        //}
    }
}
