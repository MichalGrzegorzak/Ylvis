using System;
using System.Collections.Generic;
using Core;
using Core.Accounts;
using Core.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AccountUpdaterFixture : BaseAccountTest
    {
        private void Configure2Accounts(bool hasDiffPosition)
        {
            //Framework.Inst.Configure4Tests();
            //1) simulating 2 accounts with different positions
            accountMain.Links.Position = TestPosition1;
            accountMain.GetCurrentPosition();

            accountToSync = CreateBossaMock();
            Framework.Inst.AddAccountToSync(accountToSync);

            if (hasDiffPosition)
                accountToSync.Links.Position = TestPosition2;
            else
                accountToSync.Links.Position = TestPosition1;
         
            accountToSync.GetCurrentPosition();
            Assert.IsTrue(hasDiffPosition != accountMain.Position.IsEqual(accountToSync.Position)); //have diff positions
            
            //2) trying to synchronize accounts
            Framework.Inst.AddAccountToSync(accountToSync);
            _monitor.PositionChangeHandler += new NewPosition(monitor_PositionChangeHandler);
            _monitor.CheckEverySec = 1;

            Assert.IsTrue(hasDiffPosition != _monitor.AreAccountsInSync());
        }

        [Test]
        public void ConfigureWithSamePositions()
        {
            TestInitialConfig(false);
        }

        [Test]
        public void ConfigureWithDifferentPositions()
        {
            TestInitialConfig(true);
        }

        [Test]
        public void OtherTest()
        {
            //TestInitialConfig(false);
        }

        public void TestInitialConfig(bool differentPositionsOnStart)
        {
            Configure2Accounts(differentPositionsOnStart);

            if (differentPositionsOnStart)
            {
                Assert.IsTrue(_monitor.DetectChange());
                Assert.IsFalse(_monitor.DetectChange());
            }
            else
            {
                accountMain.Links.Check4Changes = TestSecondPosition; //4S
                Assert.IsTrue(_monitor.DetectChange());
            }

            Assert.IsNotNull(NewPosition); //GUI was called

            Assert.IsFalse(accountMain.Position.IsEqual(accountToSync.Position));
            accountToSync.ChangePositionTo(accountMain.Position);
            Assert.IsTrue(accountMain.Position.IsEqual(accountToSync.Position));
        }

        void monitor_PositionChangeHandler(Position newPos)
        {
            NewPosition = newPos;
        }

        private Position NewPosition = null;

        //[Test]
        public void Test2()
        {
            //Position pos = account.GetCurrentPosition();
            //Assert.IsTrue(pos.Size != 0);
            //Assert.IsTrue(pos.Size == 0);
        }
    }
}
