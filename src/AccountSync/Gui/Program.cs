using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using log4net;
using log4net.Config;

namespace WatTest
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger("");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //XmlConfigurator.Configure(new FileInfo("Log4net.config")); //in assembly now
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new MainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Framework.CallTrace("EXCEPTION! " + e.Exception.Message);
            log.Error(sender, e.Exception);
        }

        
    }
}
