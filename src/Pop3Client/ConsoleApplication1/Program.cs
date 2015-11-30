using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace ConsoleApplication1
{
    class Program
    {
        private static ILog log = LogManager.GetLogger("");
        static void Main(string[] args)
        {
            Console.WriteLine("program started");
            XmlConfigurator.Configure(new FileInfo("Log4net.config"));

            D1 d = new D1();
            d.Do();

            Console.WriteLine("finishing");
            log.Fatal("oj fatalnie panie!");
            log.Debug("debug z glownej");
            Console.Read();
        }
    }

    class D1
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(D1));
        public void Do()
        {
            log.Info("logged info..");
            log.Debug("logged debug");
        }
    }
}
