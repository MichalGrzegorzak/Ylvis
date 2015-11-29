using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core;
using Core.Accounts;
using Core.Model;
using NUnit.Framework;
using WatiN.Core;
using WatiN.Core.Interfaces;
using WatiN.Core.UnitTests;

namespace Tests
{
    public class BaseAccountTest
    {
        private ISettings backupSettings;
        protected MonitorBase _monitor = null;
        
        protected AccountBase accountMain = null;
        protected AccountBase accountToSync = null;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            backupSettings = Settings.Clone();
			//Settings.Instance = new StealthSettings();

            Framework.Inst.Configure4Tests();

            accountMain = Framework.Inst.MainAccount = CreateBossaMock();
            _monitor = Framework.Inst.Monitor = new MonitorWww();
        }

        [TestFixtureTearDown]
        public void FixtureCleanup()
        {
            Settings.Instance = backupSettings;
            
            CloseBrowser();

            accountMain = null;
            accountToSync = null;
            _monitor = null;
        }

        protected AccountBase CreateBossaMock()
        {
            AccountNavigation navig = new AccountNavigation();
            navig.Login = new Uri(HtmlTestBaseUri, "Main1.html");
            navig.Position = TestPosition1;
            navig.NewOrder = new Uri(HtmlTestBaseUri, "NewOrder.html");
            navig.Check4Changes = TestFirstPosition;
            navig.StartFrom = navig.Login;

            //config file must be provide !!!
            Framework.Inst.ReadAccountSettingsFromFile();
            //Credentials credit = Framework.Inst.Cre

            AccountBase acc = AccountFactory.Create(ChooseAccount.Main, null, navig);
            //acc.IsLoggedIn = true;
            return acc;
        }

        public static Uri TestFirstPosition = new Uri(HtmlTestBaseUri, "Main1.html");
        public static Uri TestSecondPosition = new Uri(HtmlTestBaseUri, "Main2.html");

        public static Uri TestPosition1 = new Uri(HtmlTestBaseUri, "CurrentPosition.html");
        public static Uri TestPosition2 = new Uri(HtmlTestBaseUri, "CurrentPosition2.html");

        private static Uri _htmlTestBaseUri;
        public static Uri HtmlTestBaseUri
        {
            get
            {
                if (_htmlTestBaseUri == null)
                {
                    _htmlTestBaseUri = new Uri(GetHtmlTestFilesLocation());
                }
                return _htmlTestBaseUri;
            }
        }

        private static string GetHtmlTestFilesLocation()
        {
            var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            // Search for the html directory in the current domains base directory
            // Valid when executing WatiN UnitTests in a deployed situation. 
            var htmlTestFilesLocation = baseDirectory.FullName + @"\html\Bossa\";

            if (!Directory.Exists(htmlTestFilesLocation))
            {
                // If html directory not found, search one dir up in the directory tree
                // Valid when executing WatiN UnitTests from within Visual Studio
                htmlTestFilesLocation = baseDirectory.Parent.FullName + @"\html\Bossa\";
            }

            return htmlTestFilesLocation;
        }

        public void CloseBrowser()
        {
            if (accountMain.Ie == null) 
                return;

            accountMain.Ie.Close();
            accountMain.Ie = null;

            if (IE.InternetExplorers().Count == 0) return;

            foreach (var explorer in IE.InternetExplorersNoWait())
            {
                Console.WriteLine(explorer.Title + " (" + explorer.Url + ")");
                explorer.Close();
            }
            
            //throw new Exception("Expected no open IE instances.");
        }
    }
    
}
