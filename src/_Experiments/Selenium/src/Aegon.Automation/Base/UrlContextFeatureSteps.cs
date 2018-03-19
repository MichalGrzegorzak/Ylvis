using System;
using System.Diagnostics;
using System.Globalization;
using Aegon.Helpers;
using Aegon.TestAutomationReference;
using TechTalk.SpecFlow;

namespace Aegon.Base
{
    public class UrlContextFeatureSteps : BaseFeatureSteps
    {
        private const string UrlContextKey = "__UrlContext__";
        public static string CurrentUrlContext
        {
            get
            {
                if (!FeatureContext.Current.ContainsKey(UrlContextKey))
                    return null;

                return FeatureContext.Current.Get<string>(UrlContextKey);
            }

            set
            {
                if (!FeatureContext.Current.ContainsKey(UrlContextKey))
                    FeatureContext.Current.Add(UrlContextKey, value);
                else
                    FeatureContext.Current[UrlContextKey] = value;
            }
        }

        private const string PageIdContextKey = "__PageIdContext__";
        public static int CurrentPageIdContext
        {
            get
            {
                if (!FeatureContext.Current.ContainsKey(PageIdContextKey))
                    return 0;

                return FeatureContext.Current.Get<int>(PageIdContextKey);
            }

            set
            {
                if (!FeatureContext.Current.ContainsKey(PageIdContextKey))
                    FeatureContext.Current.Add(PageIdContextKey, value);
                else
                    FeatureContext.Current[PageIdContextKey] = value;
            }
        }

        private const string UseProcessIdContextKey = "__UseProcessIdContext__";
        public static bool UseProcessIdContext
        {
            get
            {
                if (!FeatureContext.Current.ContainsKey(UseProcessIdContextKey))
                    return false;

                return FeatureContext.Current.Get<bool>(UseProcessIdContextKey);
            }

            set
            {
                if (!FeatureContext.Current.ContainsKey(UseProcessIdContextKey))
                    FeatureContext.Current.Add(UseProcessIdContextKey, value);
                else
                    FeatureContext.Current[UseProcessIdContextKey] = value;
            }
        }

        [When(@"I go to that page")]
        public static void WhenIGoToThatPage()
        {
            WhenIGoToThePage(CurrentUrlContext);
        }

        [Given(@"I am a unique instance")]
        public static void IAmUniqueInstance()
        {
            UseProcessIdContext = true;
        }

        [Given(@"On (.*) site I have prepared (.*) content page")]
        public static void GivenIPreparedSandboxContentPage(string siteKey, string pageKey)
        {
            AppBrowser.SetBaseUrl(siteKey);
            var sandbox = SandboxEnum.BRI;
            SandboxPageData currentPage;
            CmsHelper.PrepareBriContentPage(AppBrowser.BaseUrl, sandbox, GetPageKey(pageKey), out currentPage);
            CurrentUrlContext = currentPage.StaticLinkURL;
            CurrentPageIdContext = currentPage.ID;
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        [Given(@"On (.*) site I have prepared (.*) newsitem page")]
        public static void GivenIPreparedSandboxNewsitemPage(string siteKey, string pageKey)
        {
            AppBrowser.SetBaseUrl(siteKey);
            var sandbox = SandboxEnum.BRI;
            SandboxPageData currentPage;
            CmsHelper.PrepareBriNewsitemPage(AppBrowser.BaseUrl, sandbox, GetPageKey(pageKey), out currentPage);
            CurrentUrlContext = currentPage.StaticLinkURL;
            CurrentPageIdContext = currentPage.ID;
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        [Given(@"On (.*) site I have prepared (.*) test page with content from (.*) file")]
        public static void GivenIPreparedSandboxPageWithContentFromFile(string siteKey, string pageKey, string fileName)
        {
            AppBrowser.SetBaseUrl(siteKey);
            var sandbox = SandboxEnum.BRI;
            SandboxPageData currentPage;
            CmsHelper.PrepareBriContentPageWithContentFromFile(AppBrowser.BaseUrl, sandbox, GetPageKey(pageKey), fileName, out currentPage);
            CurrentUrlContext = currentPage.StaticLinkURL;
            CurrentPageIdContext = currentPage.ID;
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        [Given(@"On (.*) site I have prepared (.*) overview test page with dummy data source")]
        public static void GivenIPreparedSandboxOverviewTestPage(string siteKey, string pageKey)
        {
            AppBrowser.SetBaseUrl(siteKey);
            var sandbox = SandboxEnum.BRI;
            SandboxPageData currentPage;
            CmsHelper.PrepareBriOverviewTestPage(AppBrowser.BaseUrl, sandbox, GetPageKey(pageKey), out currentPage);
            CurrentUrlContext = currentPage.StaticLinkURL;
            CurrentPageIdContext = currentPage.ID;
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        [Given(@"On (.*) site I have prepared (.*) (.*) form container page which contains (.*) XForm")]
        public static void GivenIPreparedXFormPage(string siteKey, string pageKey, string pageKind, string formGuid)
        {
            AppBrowser.SetBaseUrl(siteKey);
            SandboxPageData currentPage;
            if (pageKind.Equals("BRI", StringComparison.InvariantCultureIgnoreCase))
            {
                CmsHelper.PrepareBriFormContainerTestPage(AppBrowser.BaseUrl, SandboxEnum.BRI, GetPageKey(pageKey), formGuid, true, out currentPage);
            }
            else
            {
                CmsHelper.PrepareFormContainerTestPage(AppBrowser.BaseUrl, SandboxEnum.BRI, GetPageKey(pageKey), formGuid, true, out currentPage);
            }
            CurrentUrlContext = currentPage.StaticLinkURL;
            CurrentPageIdContext = currentPage.ID;
            AppBrowser.SandboxEnvironment.SignIn(AppBrowser);
        }

        private static string GetPageKey(string pageKey)
        {
            return (UseProcessIdContext)
                ? pageKey + "_" + Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture)
                : pageKey;
        }
    }
}
