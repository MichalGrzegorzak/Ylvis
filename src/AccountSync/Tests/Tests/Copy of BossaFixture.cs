using System;
using System.Diagnostics;
using Core;
using NUnit.Framework;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    public class BossaFixture2 : BaseAccountTest
    {
        private Process p;

        [TestFixtureSetUpAttribute]
        public void SetUp()
        {
            p = new Process();

            // set the initial properties 
            string path = Environment.CurrentDirectory.Replace(@"WebAppUITesting\bin", string.Empty);
            p.StartInfo.FileName = "WebDev.WebServer.EXE";
            p.StartInfo.Arguments = String.Format("/port:8080 /path:\"{0}WebApp\"", path);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            // start the process
            p.Start();
        }


        [Test]
        public void Test1_Login()
        {
            //accountMain.IsLoggedIn = false;
            accountMain.Login();
            //Assert.IsTrue(accountMain.IsLoggedIn);
        }

        [Test]
        public void Test2_SprawdzPozycje()
        {
            Position pos = accountMain.GetCurrentPosition();
            Assert.IsTrue(pos.Size != 0);
        }

        [Test]
        public void Test3_WykryjZmianePozycji()
        {
            bool result = accountMain.LookForNewPosition();
            result = accountMain.LookForNewPosition();
            Assert.IsFalse(result);

            accountMain.Links.Check4Changes = TestSecondPosition;
            result = accountMain.LookForNewPosition();
            Assert.IsTrue(result);
        }

        [Test]
        public void Test4_ZmienPozycje()
        {
            Position pos1 = accountMain.Position;
            accountMain.ChangePositionTo(new Position(0, -8, DateTime.Now));
            Position pos2 = accountMain.Position;
            Assert.IsFalse(pos1.IsEqual(pos2));
        }
    }
}
