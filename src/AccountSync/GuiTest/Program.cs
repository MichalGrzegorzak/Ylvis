using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using log4net.Config;

namespace GuiTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //XmlConfigurator.Configure(new FileInfo("Log4net.config"));
            Application.Run(new Main());
        }
    }
}
