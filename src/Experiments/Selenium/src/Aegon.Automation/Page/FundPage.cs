using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Aegon.Page
{
    public class FundPage : MasterPage
    {
        public By PiChartLocator = By.CssSelector(".highcharts-point>path");

        public void ChangeHistoricFundPeriod(string period)
        {
            FindElement(By.CssSelector("span.selected")).Click();
            Thread.Sleep(1000);
            FindElement(By.XPath("//label[contains(text(),'" + period + "')] ")).Click();
            FindElement(By.CssSelector(".btn>span")).Click();
            // FindElement(By.XPath("//span[contains(text(),'Zamknij')]"));
        }
    }
}
