using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Aegon.Extensions;

namespace Aegon.Helpers
{
    public enum ValueSourceEnum
    {
        Element,
        Attribute,
        Text,
        TagName,
        Displayed,
        Selected,
        Location,
        Size
    }

    public sealed class ElementSelectorAttribute : Attribute
    {
        // Provides the lookup methods: Id, Name, CssSelector, etc.
        public How How { get; set; }

        // Value to lookup by (i.e. for How.Name, the actual name to look up)
        public string Using { get; set; }

        // IWebElement's property or element itself to be used as a value source
        public ValueSourceEnum Source { get; set; }

        // Regex pattern to extract value, leave not set if additional value processing is not needed
        public string Pattern { get; set; }
    }

    public static class ObjectFactory
    {
        internal class ByFactory
        {
            public static By From(ElementSelectorAttribute attribute)
            {
                string selector = attribute.Using;

                switch (attribute.How)
                {
                    case How.Id:
                        return By.Id(selector);

                    case How.Name:
                        return By.Name(selector);

                    case How.TagName:
                        return By.TagName(selector);

                    case How.ClassName:
                        return By.ClassName(selector);

                    case How.CssSelector:
                        return By.CssSelector(selector);

                    case How.LinkText:
                        return By.LinkText(selector);

                    case How.PartialLinkText:
                        return By.PartialLinkText(selector);

                    case How.XPath:
                        return By.XPath(selector);

                    default:
                        return null;
                }
            }
        }

        public static T Create<T>(IWebElement container) where T : new()
        {
            var entity = new T();

            Initialize(entity, container);

            return entity;
        }

        private static void Initialize<T>(T obj, IWebElement container)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attribute = FindAttribute(property);
                if (attribute == null)
                    continue;

                var val = GetValue(container, attribute);
                property.SetValue(obj, val, null);
            }
        }

        private static ElementSelectorAttribute FindAttribute(System.Reflection.PropertyInfo propInfo)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(propInfo, typeof(ElementSelectorAttribute), true);

            if (attributes.Length > 0)
                return attributes[0] as ElementSelectorAttribute;

            return null;
        }

        private static object GetValue(IWebElement container, ElementSelectorAttribute attribute)
        {
            var element = container.FindElementSafe(ByFactory.From(attribute));
            object value = null;

            if (element == null)
                return null;

            value = GetElementValue(element, attribute);

            if (value is string)
                return ProcessValue((string)value, attribute);

            return value;
        }

        private static object GetElementValue(IWebElement element, ElementSelectorAttribute attribute)
        {
            switch (attribute.Source)
            {
                case ValueSourceEnum.Element:
                    return element;

                case ValueSourceEnum.Attribute:
                    return element.GetAttribute(attribute.Pattern);

                case ValueSourceEnum.Text:
                    return element.Text;

                case ValueSourceEnum.TagName:
                    return element.TagName;

                case ValueSourceEnum.Displayed:
                    return element.Displayed;

                case ValueSourceEnum.Selected:
                    return element.Selected;

                case ValueSourceEnum.Location:
                    return element.Location;

                case ValueSourceEnum.Size:
                    return element.Size;

                default:
                    return null;
            }
        }

        private static string ProcessValue(string value, ElementSelectorAttribute attribute)
        {
            if (string.IsNullOrWhiteSpace(attribute.Pattern))
                return value;

            var match = Regex.Match(value, attribute.Pattern);
            if (!match.Success || match.Groups.Count < 1)
                return value;

            return match.Groups[1].Value;
        }
    }

}