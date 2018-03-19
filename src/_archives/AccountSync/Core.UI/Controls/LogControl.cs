using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.Appenders;

namespace Core.UI.Controls
{
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
            //Framework.Trace += Framework_Trace;
        }

        public void ShowLogMessage(string message, string loggerName)
        {
            ShowLogMessage(message);
        }

        public void ShowLogMessage(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => ShowLogMessage(message)));
                return;
            }
            rtbLog.Text += message;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }
    }
}
