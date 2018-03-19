using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Aegon.Page
{
   public class OfficeOverviewPage : MasterPage
   {
       public By MapLocator = By.CssSelector(".google-map");
       public By AddressesLocator = By.CssSelector(".box.location");

       public void FindNearestOffice(string location)
       {
           FindElement(By.Id("ctl00_MainContentPlaceHolder_LocationInput")).SendKeys(location);
           FindElement(By.Id("ctl00_MainContentPlaceHolder_SearchButton")).Click();
       }

       public void SelectRegion(string region)
       {
           FindElement(By.Id("ctl00_MainContentPlaceHolder_RegionDropDownList")).SendKeys(region);
           FindElement(By.Id("ctl00_MainContentPlaceHolder_btnRegion")).Click();
       }
   }
}
