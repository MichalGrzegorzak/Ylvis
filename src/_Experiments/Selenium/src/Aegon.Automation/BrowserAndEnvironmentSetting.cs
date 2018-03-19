using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;


namespace Aegon
{
    [Binding]
    public class BrowserAndEnvironmentSetting : Base.Base
    {

        [BeforeFeature("legacy")]
        public static void OpenNewBrowser()
        {            
            SetDriver();
            //SetEnvironmentUrl();
        }

        [BeforeScenario("legacy")]
        public static void GetCurrentBrowser()
        {
            GetDriver();
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        [AfterScenario("legacy")]
        public static void TakeScreenshotOnFailure()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                // generate a file name and location
                var screenshotFileName = FeatureContext.Current.FeatureInfo.Title;
                screenshotFileName = screenshotFileName + DateTime.Now;
                screenshotFileName = screenshotFileName.Replace(' ', '/').Replace('/', '-').Replace(':', '-');
                string screenshotFolder = GetScreenshotFolder();
                string saveLocation = Path.Combine(screenshotFolder, screenshotFileName + ".png");

                //take screenshot
                TakeScreenshot(saveLocation);

                // display the sceenshot file location for reporting
                Console.WriteLine("Screenshot : {0} ", new Uri(saveLocation));
            }
        }

        private static string GetScreenshotFolder()
        {
            var path = Path.Combine(ConfigurationManager.AppSettings["OutputFolder"], "Screenshots");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        [AfterFeature("legacy")]
        public static void CloseCurrentBrowser()
        {
           Driver.Quit();
        }
    }



}
