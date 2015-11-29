using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Aegon.Page
{
   public class BriLandingPage : MasterPage
   {
       public By HeroImageTeaserLocator = By.Id("ctl00_MainContentPlaceHolder_HeroImageTeaser_MainContentPanel");

       public By FirstImageTeaserBlockLocator = By.Id(("ctl00_MainContentPlaceHolder_ctl01_WrapPanel"));
       public By SecondImageTeaserBlockLocator = By.Id(("ctl00_MainContentPlaceHolder_ctl02_WrapPanel"));
       public By ThirdImageTeaserBlockLocator = By.Id(("ctl00_MainContentPlaceHolder_ctl03_WrapPanel"));
       public By FourthImageTeaserBlockLocator = By.Id(("ctl00_MainContentPlaceHolder_ctl04_WrapPanel"));

   }
}
