using System;
using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;
using WatiN.Core;
using WatiN.Core.UnitTests;

namespace Tests
{
    //could be used for forms testing, alle elements

    //[TestFixture]
    //public class FormTests : BaseWithBrowserTests
    //{
    //    public override Uri TestPageUri
    //    {
    //        get { return FormSubmitURI; }
    //    }

    //    //[Test]
    //    public void Forms()
    //    {
    //        ExecuteTest(browser =>
    //        {
    //            browser.GoTo(MainURI);

    //            Assert.AreEqual(6, browser.Forms.Count, "Unexpected number of forms");

    //            var forms = browser.Forms;

    //            // Collection items by index
    //            Assert.AreEqual("Form", forms[0].Id);
               
    //            // Collection iteration and comparing the result with Enumerator
    //            IEnumerable checkboxEnumerable = forms;
    //            var checkboxEnumerator = checkboxEnumerable.GetEnumerator();

    //            var count = 0;
                
    //            Assert.AreEqual(6, count);
    //        });
    //    }
    //}
}