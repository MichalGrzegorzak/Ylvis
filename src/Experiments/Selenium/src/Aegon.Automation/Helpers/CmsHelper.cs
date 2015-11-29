using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Aegon.TestAutomationReference;

namespace Aegon.Helpers
{
    public class CmsHelper
    {

        internal static SandboxPageData EditSandboxHomePage(string baseUrl, SandboxEnum sandbox, string pageKey, string pageType, Dictionary<string, string> properties)
        {
            var binding = new BasicHttpBinding();
            //binding.MaxReceivedMessageSize = 6553600;
            binding.ReceiveTimeout = new TimeSpan(0, 0, 2, 0);
            using (var client = new TestAutomationClient(binding, new EndpointAddress(GetEndpointUrl(baseUrl))))
            {
                client.Open();
                return client.EditHomePageData(sandbox, pageKey, properties);                
            }
        }
        
        internal static SandboxPageData PrepareSandboxTestPage(string baseUrl, SandboxEnum sandbox, string pageKey, string pageType, Dictionary<string, string> properties)
        {
            var binding = new BasicHttpBinding();
            //binding.MaxReceivedMessageSize = 6553600;
            binding.ReceiveTimeout = new TimeSpan(0, 0, 2, 0);
            using (var client = new TestAutomationClient(binding, new EndpointAddress(GetEndpointUrl(baseUrl))))
            {
                client.Open();
                return client.PrepareSandboxTestPage(sandbox, pageKey, pageType, properties);
            }
        }

        internal static SandboxPageData[] GetDescendantPages(string baseUrl, string pageUrl, string[] pageTypes, string languageBranch = "en")
        {
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 6553600;
            using (var client = new TestAutomationClient(binding, new EndpointAddress(GetEndpointUrl(baseUrl))))
            {
                client.Open();
                var uri = new Uri(new Uri(baseUrl), pageUrl);
                return client.GetDescendantPages(uri.ToString(), pageTypes, languageBranch);
            }
        }

        internal static void PrepareBriOverviewTestPage(string baseUrl, SandboxEnum sandbox, string pagePath, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName},
                                     {"OverviewDataSourceType", "dummy"}
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[BRI Templates] Overview", properties);
        }

        internal static void PrepareFormContainerTestPage(string baseUrl, SandboxEnum sandbox, string pagePath, string formGuid, bool useMollom, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName},
                                     {"XForm", formGuid},
                                     {"SendMeACopyEmailBodyHeader", "Header"},
                                     {"SendMeACopyEmailBodyFooter", "Footer"},
                                     {"UseMollom", SerializeValue(useMollom)}
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[Templates] Form Container Page", properties);
        }

        internal static void PrepareBriFormContainerTestPage(string baseUrl, SandboxEnum sandbox, string pagePath, string formGuid, bool useMollom, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName},
                                     {"XForm", formGuid},
                                     {"SendMeACopyEmailBodyHeader", "Header"},
                                     {"SendMeACopyEmailBodyFooter", "Footer"},
                                     {"UseMollom", SerializeValue(useMollom)}
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[BRI Templates] Form Container Page", properties);
        }

        internal static void PrepareBriContentPage(string baseUrl, SandboxEnum sandbox, string pagePath, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName}
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[BRI Templates] Content Page", properties);
        }

        internal static void PrepareBriContentPageWithContentFromFile(string baseUrl, SandboxEnum sandbox, string pagePath, string fileName, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var fileContent = LoadFromFile(fileName);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName},
                                     {"Content", fileContent}
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[BRI Templates] Content Page", properties);
        }

        internal static void PrepareBriNewsitemPage(string baseUrl, SandboxEnum sandbox, string pagePath, out SandboxPageData pageData)
        {
            var pageName = GetPageName(pagePath);
            var properties = new Dictionary<string, string>
                                 {
                                     {"PageName", pageName},
                                     {"Title", pageName},
                                     {"Introduction", "Introduction to " + pageName},
                                     {"Date", DateTime.Now.ToString("d", System.Globalization.CultureInfo.InvariantCulture) }
                                 };
            pageData = PrepareSandboxTestPage(baseUrl, sandbox, pagePath, "[BRI Templates] Newsitem", properties);
        }

        internal static int GetPageTypeId(string baseUrl, string pagePath)
        {
            using (var client = new TestAutomationClient(new BasicHttpBinding(), new EndpointAddress(GetEndpointUrl(baseUrl))))
            {
                client.Open();
                var uri = new Uri(new Uri(baseUrl), pagePath);
                return client.GetPageTypeId(uri.ToString());
            }
        }

        private static string GetEndpointUrl(string baseUrl)
        {
            return baseUrl + "/Wcf/TestAutomation.svc";
        }

        private static string LoadFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        private static string GetPageName(string pagePath)
        {
            return pagePath.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries).First().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
        }

        private static string SerializeValue(bool value)
        {
            return value ? "True" : "False";
        }
    }
}
