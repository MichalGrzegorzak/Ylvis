using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Aegon.Page
{
   public class FundOverviewPage : MasterPage
    {
       public void SetProduct(string product)
       {
           Driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_DropDownListPrograms")).SendKeys(product);
       }

       public void SetCurrency(string currency)
       {
           Driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_DropDownCurrencyFilter")).SendKeys(currency);
       }

       public void ClickFilterButton()
       {
           Driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ButtonFilter")).Click();
           Thread.Sleep(2000);
       }

       public void ClickFund(string fund)
       {
           FindElement(By.XPath(("//a[contains(text(),'" + fund + "')]"))).Click();
       }
    }
}
