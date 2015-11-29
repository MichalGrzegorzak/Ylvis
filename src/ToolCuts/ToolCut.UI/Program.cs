using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Rhino.Commons;
using ToolCut.Core;
using ToolCut.Core.Domain;

namespace ToolCut.UI
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

            bool creteDB = false;

            EnableNhibernateLogging();
            PrepareDatabase(creteDB);
            FirstUseOfRepository();

            if (creteDB)
            {
                CreteNewCommonData();
            }

            Application.Run(new Form1());
        }

        private static void EnableNhibernateLogging()
        {
            IAppender fileApp = null;
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            foreach (IAppender app in hierarchy.Root.Appenders)
            {
                if (app is RollingFileAppender
                    && app.Name == "nHibernateAppender")
                {
                    fileApp = app;
                }
            }

            //turn on log4net logging (and supress output to console)
            BasicConfigurator.Configure(fileApp);
        }

        private static void PrepareDatabase(bool createDB)
        {
            try
            {
                Configuration cfg = new Configuration().Configure(@"hibernate.cfg.xml"); //must be in root dir
                ISessionFactory factory = cfg.BuildSessionFactory();

                if (createDB)
                {
                    new SchemaExport(cfg).Create(true, true); // creates structure at database 
                }
                RhinoContainer container = new RhinoContainer(".\\config\\Windsor.config");
                IoC.Initialize(container);

                IoC.Container.Kernel.AddComponentInstance("nhibernate_cfg", cfg);
                IoC.Resolve<IUnitOfWorkFactory>().Init();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private static void FirstUseOfRepository()
        {
            string id = "ALFKI";
            //PaymentService service = new PaymentService();
            //Customer c = service.Get(id);
        }

        private const decimal Pi12 = 3.82M;

        private static void CreteNewCommonData()
        {
            Tool cd = new Tool();
            cd.Name = "Tool_1";
            cd.Diameter = 1;
            cd.Sfm = 680;

            cd.Milling2 = Pi12 * cd.Sfm / cd.Diameter;
            cd.Milling4 = cd.Milling2 * 0.8M;
            cd.Milling6 = cd.Milling2 * 0.7M;
            cd.CrbDrill = Pi12 * 230 / cd.Diameter;
            cd.HssDrill = Pi12 * 55 / cd.Diameter;
            cd.Reamer = Pi12 * 27.5M / cd.Diameter;

            #region RGH
            cd.Rgh = new Tool();
            cd.Rgh.Name = cd.Name + "_RGH";
            cd.Rgh.Milling2 = cd.Milling2 * 0.02M * 2;
            cd.Rgh.Milling4 = cd.Rgh.Milling2 * 0.75M;
            cd.Rgh.Milling6 = cd.Rgh.Milling4 * 0.75M;
            cd.Rgh.CrbDrill = cd.CrbDrill * 0.0018M;
            cd.Rgh.HssDrill = cd.HssDrill * 0.0018M;
            cd.Rgh.Flut = 4;
            cd.Rgh.Reamer = cd.Reamer * 0.0025M * cd.Rgh.Flut; 
            #endregion

            #region SEMI
            cd.SemiFin = new Tool();
            cd.SemiFin.Name = cd.Name + "_SEMI";
            cd.SemiFin.Milling2 = cd.Milling2 * 0.015M * 2;
            cd.SemiFin.Milling4 = cd.SemiFin.Milling2 * 0.75M;
            cd.SemiFin.Milling6 = cd.SemiFin.Milling4 * 0.75M;
            cd.SemiFin.Flut = 6;
            cd.SemiFin.Reamer = cd.Reamer * 0.0025M * cd.SemiFin.Flut; 
            #endregion

            #region FIN
            cd.Fin = new Tool();
            cd.Fin.Name = cd.Name + "_FIN";
            cd.Fin.Milling2 = cd.Milling2 * 0.008M * 2;
            cd.Fin.Milling4 = cd.Fin.Milling2 * 0.75M;
            cd.Fin.Milling6 = cd.Fin.Milling4 * 0.75M;
            cd.Fin.Flut = 8;
            cd.Fin.Reamer = cd.Reamer * 0.0025M * cd.Fin.Flut; 
            #endregion

            #region FINE FIN
            cd.FineFin = new Tool();
            cd.FineFin.Name = cd.Name + "_FINEFIN";
            cd.FineFin.Milling2 = cd.Milling2 * 0.004M * 2;
            cd.FineFin.Milling4 = cd.FineFin.Milling2 * 0.75M;
            cd.FineFin.Milling6 = cd.FineFin.Milling4 * 0.75M; 
            #endregion

            using (UnitOfWork.Start())
            {
                Repository<Tool>.SaveOrUpdate(cd);
                UnitOfWork.Current.Flush();
            }
        }



    }
}
