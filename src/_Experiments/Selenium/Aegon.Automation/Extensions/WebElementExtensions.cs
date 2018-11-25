using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Aegon.Extensions
{
    public static class WebElementExtensions
    {
        public static IWebElement GetElementSafe(this IWebElement element)
        {
            try
            {
                if (element == null)
                    return null;

                var tagName = element.TagName;
            }
            catch
            {
                return null;
            }

            return element;
        }

        public static IEnumerable<IWebElement> GetElementsSafe(this IEnumerable<IWebElement> elements)
        {
            try
            {
                if (elements == null)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

            return elements;
        }

        public static bool ClickSafe(this IWebElement webElement)
        {
            try
            {
                webElement.Click();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool ClickAndWaitForElement(this IWebElement webElement, IWebDriver driver, TimeSpan timeout, By elementSelector)
        {
            if (!ClickSafe(webElement))
                return false;

            try
            {
                var wait = new WebDriverWait(driver, timeout);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(x => x.FindElement(elementSelector));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool WaitForElement(IWebDriver driver, TimeSpan timeout, By elementSelector)
        {
            try
            {
                var wait = new WebDriverWait(driver, timeout);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(x => x.FindElement(elementSelector));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool ClickAndWaitForElement(this IWebElement webElement, IWebDriver driver, By elementSelector)
        {
            return ClickAndWaitForElement(webElement, driver, TimeSpan.FromSeconds(10), elementSelector);
        }

        public static bool ClickAndWaitForPageToLoad(this IWebElement webElement, IWebDriver driver)
        {
            return ClickAndWaitForElement(webElement, driver, TimeSpan.FromSeconds(10), By.TagName("body"));
        }

        public static IWebElement FindElementSafe(this IWebElement containerElement, By elementSelector)
        {
            var container = GetElementSafe(containerElement);
            if (container == null)
                return null;

            IWebElement element = null;
            try
            {
                element = container.FindElement(elementSelector);
            }
            catch
            {
                return null;
            }

            return GetElementSafe(element);
        }

        public static IEnumerable<IWebElement> FindElementsSafe(this IWebElement containerElement, By elementSelector)
        {
            var container = GetElementSafe(containerElement);
            if (container == null)
                return null;

            IEnumerable<IWebElement> elements = null;
            try
            {
                elements = container.FindElements(elementSelector);
            }
            catch
            {
                return null;
            }

            return GetElementsSafe(elements);
        }
    }
}
