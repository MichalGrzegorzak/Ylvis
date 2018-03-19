using Aegon.Page;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class ContactUsFormSteps : Base.Base
    {
        [Given(@"I am on Contact us form page of (.*)")]
        public void GivenIAmOnContactUsFormPageOf(string site)
        {
            SignInToEnvironment();
            Driver.Navigate().GoToUrl(ContactUsFormPageUrl);
        }
        
        [Given(@"I populate the full name as (.*)")]
        public void GivenIPopulateTheFullNameAs(string fullName)
        {
            var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.FullNameLocator).SendKeys(fullName);
        }
        
        [Given(@"I populate the email as (.*)")]
        public void GivenIPopulateTheEmailAs(string email)
        {
            var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.EmailLocator).SendKeys(email);
        }
        
        [Given(@"I populate the telefone number as (.*)")]
        public void GivenIPopulateTheTelefoneNumberAs(string telefone)
        {
             var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.TelefoneLocator).SendKeys(telefone);
        }
        
        [Given(@"I set the profession as (.*)")]
        public void GivenISetTheProfessionAs(string profession)
        {
             var contactUsFormPage = new ContactUsFormPage();
            contactUsFormPage.SetProfessionOnContactUsForm(profession);
        }

        [Given(@"I set the region to (.*)")]
        public void GivenISetTheRegionTo(string region)
        {
            var contactUsFormPage = new ContactUsFormPage();
            contactUsFormPage.SetRegionOnContactUsForm(region);
        }

        
        [Given(@"I set the query as (.*)")]
        public void GivenISetTheQueryAs(string queryType)
        {
             var contactUsFormPage = new ContactUsFormPage();
            contactUsFormPage.SetQueryTypeOnContactUsForm(queryType);
        }
        
        [Given(@"I populate the question as (.*)")]
        public void GivenIPopulateTheQuestionAs(string question)
        {
             var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.QuestionLocator).SendKeys(question);
        }

        [Given(@"I tick the disclaimer checkbox")]
        public void GivenITickTheDisclaimerCheckbox()
        {
            var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.DisclaimerCheckBox).Click();
        }

        
        [When(@"I click the submit button for the form")]
        public void WhenIClickTheSubmitButtonForTheForm()
        {
             var contactUsFormPage = new ContactUsFormPage();
            FindElement(contactUsFormPage.SubmitContactUsFromButton).Click();
        }
        
        [Then(@"I see the thankyou message as (.*)")]
        public void ThenISeeTheThankyouMessageAs(string message)
        {
            var contactUsFormPage = new ContactUsFormPage();
            Assert.IsTrue(FindElement(contactUsFormPage.ThankYouMessageLocator).Text.ToLower().Contains(message.ToLower()));

        }
    }
}
