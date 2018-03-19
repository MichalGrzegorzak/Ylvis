using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegon.Page;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Configuration;

namespace Aegon
{
    public class QuarterlyResultsPage : MasterPage
    {
        public By YouTubePlayerLocator = By.CssSelector(".rich-text");
        public By LhsNavigationLocator = By.CssSelector(".aeg-nav-tree");
        public By RhsColumnLocator = By.Id("content-related");

        public By AllQuarterlyResultsTabLocator  = By.XPath("//a[contains(.,'All quarterly results')]");
        public By LastQuarterTabLocator = By.XPath("//a[contains(.,'Last quarter')]");
        //  public By lastQuarterTabLocator = By.XPath("//a[contains(.,'Last quarter | Q2 2013')]");

        public By AllQuarterlyResultsTableLocator = By.CssSelector(".quarterly-results");

        public By PressReleasesEnglishHtmlLocator = By.XPath("html/body/form/div[5]/div[4]/div[4]/div[1]/div[1]/div/div[1]/ul/li[1]/a");
        public By PressReleasesEnglishPdfLocator = By.XPath("html/body/form/div[5]/div[4]/div[4]/div[1]/div[1]/div/div[1]/ul/li[2]/a");

        
    }
}
