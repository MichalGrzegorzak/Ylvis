using System;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BossaFixture : BaseAccountTest
    {
        [Test]
        public void Test1_Login()
        {
            //accountMain.IsLoggedIn = false;
            accountMain.Login();
            accountMain.Logout();
            Assert.IsTrue(accountMain.Credentials != null);
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
