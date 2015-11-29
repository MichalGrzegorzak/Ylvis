using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Commons.Appenders;
using Core.Aspects;
using log4net;

namespace WatTest.Controls
{
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
            //GuiTraceAppender.LogMessage += (s) => rtbLog.Text += s;
            Framework.Trace += Framework_Trace;
        }

        
        void Framework_Trace(string message)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => Framework_Trace(message))); 
                return;
            }
            else
                rtbLog.Text += DateTime.Now.ToLongTimeString() + " "+ message + "\n";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }
    }
}
