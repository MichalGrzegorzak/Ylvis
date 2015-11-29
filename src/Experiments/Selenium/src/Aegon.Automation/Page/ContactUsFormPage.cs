using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Aegon.Page
{
    public class ContactUsFormPage : MasterPage
    {
        public By FullNameLocator = By.Id("ctl00_MainContentPlaceHolder_fullname");
        public By EmailLocator = By.Id("ctl00_MainContentPlaceHolder_email");
        public By TelefoneLocator = By.Id("ctl00_MainContentPlaceHolder_tel");

        public void SetProfessionOnContactUsForm(string profession)
        {
            FindElement(By.Id("ctl00_MainContentPlaceHolder_profession")).SendKeys(profession);
        }

        public void SetQueryTypeOnContactUsForm(string queryType)
        {
            FindElement(By.Id("ctl00_MainContentPlaceHolder_query")).SendKeys(queryType);
        }

        public void SetRegionOnContactUsForm(string region)
        {
            FindElement(By.Id("ctl00_MainContentPlaceHolder_RegionsDropDownList")).SendKeys(region);
        }

        public By QuestionLocator = By.Id("ctl00_MainContentPlaceHolder_question");
        public By SubmitContactUsFromButton = By.Id("submit");

        public By SendMeCopyCheckBox = By.Id("ctl00_MainContentPlaceHolder_lblCopy");

        public By DisclaimerCheckBox = By.Id("ctl00_MainContentPlaceHolder_chkDisclaimer");

        public By ThankYouMessageLocator = By.CssSelector(".title>h1");
    }
}
