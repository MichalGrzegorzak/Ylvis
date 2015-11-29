using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Commons.Appenders;
using log4net;

namespace GuiTest.Forms
{
    public partial class FrmAppender : Form
    {
        //private static ILog log = LogManager.GetLogger(typeof(FrmAppender));

        public FrmAppender()
        {
            InitializeComponent();
            GuiTraceAppender.LogMessage += new HandleLogMessage(GuiAppender_ShowLogMessage);
        }

        void GuiAppender_ShowLogMessage(string message, string name)
        {
            //logControl1.Text += message;
            label1.Text += message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //log.Info("dupa, dupa");
            Framework.Inst.OrderingEnabled = false;
        }


    }
}