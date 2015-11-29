using Aegon.Base;
using Aegon.Extensions;
using Aegon.Helpers;
using Aegon.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class SurveryOverlayChecksSteps : BaseFeatureSteps
    {
        public SurveryOverlayChecksSteps()
        {
            CurrentPage = new BasePage();
        }
        
        
        [Then(@"I see survey overlay after (.*) seconds")]
        public void ThenISeeSurveyOverlayAfterSeconds(int time)
        {
            AutomationHelper.WaitSeconds(time + 2);
            var surveyElemeny = CurrentPage.GetActiveElement();
            var elementId = surveyElemeny.GetAttribute("id");
            var contentElement = surveyElemeny.FindElementSafe(By.Id("inline_content_survey"));

            Assert.True(elementId == "colorbox");
            Assert.IsNotNull(contentElement);
            

            //Assert.IsTrue(FindElement(masterPage.SurveyOverlayLocator).Displayed);
        }

        [Then(@"I see survery title")]
        public void ThenISeeSurverytitle()
        {

            var surveyElemeny = CurrentPage.GetActiveElement();
            var titlteElement = surveyElemeny.FindElementSafe(By.Id("cboxTitle"));
            Assert.IsNotNull(titlteElement);
            Assert.True(!string.IsNullOrWhiteSpace(titlteElement.Text));

            //Assert.IsTrue(FindElement(masterPage.SurveyOverlayTitleLocator).Text.ToLower().Contains(title.ToLower()));
        }
        
        [Then(@"I see Yes, please button")]
        public void ThenISeeYesPleaseButton()
        {

            var surveyElemeny = CurrentPage.GetActiveElement();
            var titlteElement = surveyElemeny.FindElementSafe(By.ClassName("button-surv"));
            Assert.IsNotNull(titlteElement);
            Assert.True(!string.IsNullOrWhiteSpace(titlteElement.Text));
        }
        
        [Then(@"I see No, thanks button")]
        public void ThenISeeNoThanksButton()
        {

            var surveyElemeny = CurrentPage.GetActiveElement();
            var titlteElement = surveyElemeny.FindElementSafe(By.ClassName("survey-close"));
            Assert.IsNotNull(titlteElement);
            Assert.True(!string.IsNullOrWhiteSpace(titlteElement.Text));
        }

        [When(@"I click No, thanks on survey overlay")]
        public void WhenIClickNoThanksOnSurveyOverlay()
        {
            var surveyElemeny = CurrentPage.GetActiveElement();
            var titlteElement = surveyElemeny.FindElementSafe(By.ClassName("survey-close"));
            Assert.IsNotNull(titlteElement);
            titlteElement.Click();            
        }

        [Then(@"the survery overlay disappears")]
        public void ThenITheSurveryOverlayDisappears()
        {
            AutomationHelper.WaitSeconds(3);
            var surveyElemeny = CurrentPage.BodyElement.FindElementSafe(By.Id("colorbox"));
            var elementId = surveyElemeny.GetAttribute("id");
            if(surveyElemeny == null)
                return;
            
            var contentElement = surveyElemeny.FindElementSafe(By.Id("inline_content_survey"));
            if (contentElement != null)
            {
                Assert.False(contentElement.Displayed);
            }            
        }

    }
}
