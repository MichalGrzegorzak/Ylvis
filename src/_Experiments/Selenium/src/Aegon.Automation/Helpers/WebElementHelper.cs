using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Aegon.Extensions;

namespace Aegon.Helpers
{
    public static class WebElementHelper
    {
        public static KeyValuePair<string, string>[] GetSelectOptions(IWebElement selectElement)
        {
            var options = selectElement.FindElements(By.TagName("option"));
            return options
                .Select(x => new KeyValuePair<string, string>(x.GetAttribute("value"), x.GetAttribute("text")))
                .ToArray();
        }

        public static KeyValuePair<string, IWebElement>[] GetFancySelectOptions(IWebElement fancyElement)
        {
            return fancyElement
                .FindElements(By.CssSelector("li > a"))
                .Select(x => new KeyValuePair<string, IWebElement>(x.GetAttribute("text"), x))
                .ToArray();
        }

        public static IWebElement FindSelectOptionByValue(SelectElement selectElement, string value)
        {
            var option = selectElement.Options
                .FirstOrDefault(x => x.GetAttribute("value") == value);

            return option;
        }

        public static string GetElementText(IWebElement containerElement, By elementSelector)
        {
            var element = containerElement.FindElementSafe(elementSelector);
            return element != null ? element.Text : null;
        }
    }
}