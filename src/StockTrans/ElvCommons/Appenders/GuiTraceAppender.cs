using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace Commons.Appenders
{
    public delegate void HandleLogMessage(string message, string loggerName);

    public class GuiTraceAppender : AppenderSkeleton
    {
        //public static event HandleLogMessage GuiLoggerMessage;
        //public static event HandleLogMessage MonitorLoggerMessage;

        public static event HandleLogMessage LogMessage;

        protected override void Append(LoggingEvent loggingEvent)
        {
            string s = RenderLoggingEvent(loggingEvent);

            //CallRightEvent(, s);
            if (LogMessage != null)
            {
                LogMessage.Invoke(s, loggingEvent.LoggerName);
            }
        }

        //private static void CallRightEvent(string logger, string message)
        //{
        //    if (logger == "GuiLogger"
        //        && GuiLoggerMessage != null)
        //    {
        //        GuiLoggerMessage.Invoke(message);
        //    }

        //    if (logger == "MonitorLogger"
        //        && MonitorLoggerMessage != null)
        //    {
        //        MonitorLoggerMessage.Invoke(message);
        //    }

            
        //}


    }
}
