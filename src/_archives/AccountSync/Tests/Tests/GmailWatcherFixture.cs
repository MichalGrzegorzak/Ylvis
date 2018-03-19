using System.Collections.Generic;
using System.IO;
using Core.Gmail;
using Core.Model;
using Core.Watcher;
using log4net.Config;
using NUnit.Framework;

namespace Tests.Tests
{
    [TestFixture]
    public class GmailWatcherFixture
    {
        #region Test setup
        private GmailWatcher watcher = null;
        private GmailSender sender;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlConfigurator.Configure(new FileInfo("Log4net.config"));

            watcher = new GmailWatcher();
            sender = new GmailSender();
        }

        [TestFixtureTearDown]
        public void FixtureCleanup()
        {
            watcher = null;
            sender = null;
        } 
        #endregion

        //[Test]
        //public void TestWithExistingMailInMailbox()
        //{
        //    SysCmd cmd = watcher.GetCommand();
        //    Assert.IsTrue(s != SysCmd.None);
        //}

        [Test]
        public void ParsingTest()
        {
            string mailBody =
                @"Na rachunku nr 00-22-255294 zawarto w dniu 27.08.2009 o godz. 15:15 transakcje: FW20Z09 S 3*1900";
            SysCmd cmd = GmailWatcher.ParseSignal(mailBody);
            Assert.IsTrue(cmd == SysCmd.S);
        }

        [Test] 
        public void NoEmailInMailboxAtTheBeginning()
        {
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.None);
        }

        [Test]
        public void OneSignal_K_InMailbox()
        {
            sender.SendTest4K();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.L);
        }

        [Test]
        public void TwoSameSignals()
        {
            sender.SendTest3Kand1K();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.L);
        }

        [Test]
        public void OneSignal_S_InMailbox()
        {
            sender.SendTest4S();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.S);
        }

        [Test]
        public void TwoButNotTheSameSignals()
        {
            sender.SendTest3Sand1K();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.L);
        }

        [Test]
        public void DifferentEmailsInMailboxAnd1Signal()
        {
            sender.SendSpamMail();
            sender.SendTest4S();
            sender.SendSpamMail();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.S);
        }

        [Test]
        public void DifferentEmailInMailx()
        {
            sender.SendSpamMail();
            SysCmd cmd = watcher.GetCommand();
            Assert.IsTrue(cmd == SysCmd.None);
        }

        [Test]
        public void NoEmailInMailboxAtTheEnd()
        {
            NoEmailInMailboxAtTheBeginning();
        }
    }
}
