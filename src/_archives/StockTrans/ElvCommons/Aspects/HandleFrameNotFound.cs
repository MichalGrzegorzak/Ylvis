using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using log4net;
using PostSharp.Laos;
using WatiN.Core.Exceptions;

namespace Core.Aspects
{
    [Serializable]
    public class HandleFrameNotFoundAttribute : OnExceptionAspect
    {
        private static ILog log = LogManager.GetLogger(typeof(HandleFrameNotFoundAttribute));

        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            if(eventArgs.Exception.GetType() == typeof(FrameNotFoundException))
            {
                log.Debug(eventArgs.Exception.StackTrace);
                //eventArgs.Method.Invoke()
                //Framework.CallTrace("Relogging");
            }

            string message = eventArgs.Exception.Message;
            eventArgs.FlowBehavior = FlowBehavior.Continue;
        }
    }
}
