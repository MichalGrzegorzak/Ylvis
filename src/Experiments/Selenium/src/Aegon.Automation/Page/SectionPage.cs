using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Aegon.Page
{
   public class SectionPage : MasterPage
   {
       public By FirstTeaserLocator = By.Id("ctl00_MainContentPlaceHolder_TeaserControl1_TeaserPanel");
       public By SecondTeaserLocator = By.Id("ctl00_MainContentPlaceHolder_TeaserControl2_TeaserPanel");
       public By ThirdTeaserLocator = By.Id("ctl00_MainContentPlaceHolder_TeaserControl3_TeaserPanel");
       public By FourthTeaserLocator = By.Id("ctl00_MainContentPlaceHolder_TeaserControl4_TeaserPanel");
   }
}
