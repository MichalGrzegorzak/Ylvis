using System;
using Aegon.Base;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Aegon.Test.Common.Steps
{
    [Binding]
    public class CmsEditingSteps : UrlContextFeatureSteps
    {
        [When(@"I open this page in Edit mode")]
        public void WhenIOpenThisPageInEditMode()
        {
            Assert.IsTrue(CurrentPageIdContext > 0);
            var url = String.Format("/UI/CMS/Edit/EditPanel.aspx?id={0}&selectedEditPanelTab=1", CurrentPageIdContext);
            WhenIGoToThePage(url);
        }

        [When(@"I save and publish the page")]
        public void WhenISaveAndPublishThePage()
        {
            WhenIClickLinkById("ctl00_FullRegion_PC_38_1_ctl00_SaveAndPublish");
        }

    }
}
