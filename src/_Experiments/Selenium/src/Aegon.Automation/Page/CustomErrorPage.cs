using Aegon.Page;
using OpenQA.Selenium;

namespace Aegon
{
    public class CustomErrorPage : BasePage
    {
        public string CustomErrorPageTitle {
            get { return Driver.Title.ToLower(); }
        }
    }
}
