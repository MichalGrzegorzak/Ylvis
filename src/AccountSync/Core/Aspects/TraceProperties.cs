using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using PostSharp.Laos;

namespace Core.Aspects
{
    [Serializable]
    public class TraceProperties : OnFieldAccessAspect
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");

        public override void OnSetValue(FieldAccessEventArgs eventArgs)
        {
            log.Info(eventArgs.FieldInfo.Name.Replace("_","") 
                + ", changed to: " + eventArgs.ExposedFieldValue.ToString());
            base.OnSetValue(eventArgs);
        }

    }
}
