using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemModel;

namespace ItemModelUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string itemCopyText = @"";

            var item = new LootItem(itemCopyText);

            Assert.AreEqual(expected: 4, actual: item.RawSections.Length, message: "Unexpected number of sections");
        }
    }
}
