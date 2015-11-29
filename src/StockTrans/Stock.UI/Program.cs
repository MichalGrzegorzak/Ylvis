using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.Windsor;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Rhino.Commons;
using NHibernate.Cfg;
using Rhino.Commons.Facilities;
using Stock.Core;
using Stock.Core.Domain;
using Stock.Forms;
using Stock.Presenters;

namespace Stock
{
    static class Program
    {
        private static IeTestingForm _ieForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RhinoContainer container = new RhinoContainer(".\\config\\Windsor.config");
            IoC.Initialize(container);
            container.Kernel.AddFacility("nh", new NHibernateUnitOfWorkFacility());

            EnableNhibernateLogging();
            CreateDB(container);
            FirstUseOfRepository();

            //_ieForm = new IeTestingForm(); 
            
            ////if no password & login then show config form
            //MbankSettings settings = Properties.Settings.Default.MyMbankSettings;
            //if (settings == null)
            //{
            //    _ieForm.Visible = false;
            //    Form configForm = new ConfigureMbank();
            //    configForm.Closed += new EventHandler(f_Closing);
            //    configForm.Show();
            //}
            //else
            //{
            //    _ieForm.Go(Properties.Settings.Default.MyMbankSettings);
            //}

            //form = new GroupsForm();
            //form.Show();

            CreditFormMVP form = new CreditFormMVP();
            CreditPresenter creditPresenter = new CreditPresenter(new Credit(), form);
            //form.Show();

            //Application.Run(_ieForm);
            Application.Run(form);
        }

        static void f_Closing(object sender, EventArgs e)
        {
            _ieForm.Show();
            _ieForm.Go(Properties.Settings.Default.MyMbankSettings);
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

        private static void CreateDB(IWindsorContainer container)
        {
            using (UnitOfWork.Start())
            {
                Configuration cfg = new Configuration().Configure(@"hibernate.cfg.xml");
                new SchemaExport(cfg).Create(true, true);
            }
        }

        private static void FirstUseOfRepository()
        {
            string id = "ALFKI";
            //PaymentService service = new PaymentService();
            //Customer c = service.Get(id);
        }
    }
}
