using System;
using System.Collections;
using System.Collections.Generic;
using MbUnit.Framework;
using Rhino.Commons;
using Rhino.Commons.NHibernate;
using Stock.Core.Domain;
using NHibernate.Exceptions;
using Stock.Core.Controller;

namespace Stock.Test
{
    [TestFixture]
    public class GroupFixture : BasePersistanceFixture
    {
        [Test]
        public void CanSaveGroup()
        {
            //saving MSZ
            CompanyFixture.SaveNewMSZCompany();

            TransactionGroup group = CreateNewTransactionGroup();
            Assert.AreNotEqual(0, group.ID);

            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.CurrentSession.Evict(group);

            TransactionGroup fromDb = Repository<TransactionGroup>.Get(group.ID); //get

            Assert.AreNotSame(group, fromDb);
            Assert.AreEqual("MSZ", fromDb.CompanyId);
            Assert.AreEqual(group.ID, fromDb.ID);

            Console.WriteLine("-----------------------------------------------------------------");
        }

        //[Test]
        //[ExpectedException(typeof(Exception))]
        //public void CannotSaveTransaction()
        //{
        //    TransactionGroup tran = CreateNewTransactionGroup();
        //    Assert.AreEqual(0, tran.ID);

        //    TransactionController controller = new TransactionController();
        //    controller.AddNewTransaction(1,100,"MSZ");
        //    //
        //    UnitOfWork.Current.TransactionalFlush();
        //    UnitOfWork.CurrentSession.Evict(tran);
        //}

        public static TransactionGroup CreateNewTransactionGroup()
        {
            TransactionGroup g = new TransactionGroup();
            g.CompanyId = "MSZ";
            //g.Company = new Company("MSZ");
            g.Closed = false;
            g.Income = 0;

            g = Repository<TransactionGroup>.Save(g);
            
            return g;
        }

        [Test]
        public void GetAllTransactionsGroups()
        {
            CompanyFixture.SaveNewMSZCompany();
            //
            TransactionGroup tran = CreateNewTransactionGroup();

            GroupController controller = new GroupController();
            ICollection<TransactionGroup> groups = controller.GetAllGroups();
            Assert.IsNotEmpty((ICollection)groups);
        }

        [Test]
        public void GetAllTransactionsByGroupId()
        {
            Company c = CompanyFixture.SaveNewMSZCompany();
            TransactionGroup group = GroupFixture.CreateNewTransactionGroup();
            Transaction tran = TransactionFixture.CreateNewTransaction(1);

            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.CurrentSession.Evict(tran);
            UnitOfWork.CurrentSession.Evict(group);
            UnitOfWork.CurrentSession.Evict(c);

            GroupController controller = new GroupController();
            ICollection<TransactionGroup> groups = controller.GetAllGroups();
            Assert.IsNotEmpty((ICollection)groups);

            TransactionController tr = new TransactionController();
            ICollection<Transaction> transactions = tr.GetAllTransaction();
            Assert.IsNotEmpty((ICollection)transactions);

            transactions = controller.GetAllTransactionForGroup(1);
            Assert.IsNotEmpty((ICollection)transactions);
        }

        private void PrepareData()
        {
            Company c = CompanyFixture.SaveNewMSZCompany();
            TransactionGroup group1 = GroupFixture.CreateNewTransactionGroup();
            TransactionGroup group2 = GroupFixture.CreateNewTransactionGroup();
            Transaction tran1 = TransactionFixture.CreateNewTransaction(1);
            Transaction tran11 = TransactionFixture.CreateNewTransaction(1);
            Transaction tran2 = TransactionFixture.CreateNewTransaction(2);

            UnitOfWork.Current.TransactionalFlush();

            UnitOfWork.CurrentSession.Evict(tran1);
            UnitOfWork.CurrentSession.Evict(tran11);
            UnitOfWork.CurrentSession.Evict(tran2);
            UnitOfWork.CurrentSession.Evict(group1);
            UnitOfWork.CurrentSession.Evict(group2);
            UnitOfWork.CurrentSession.Evict(c);
        }

        [Test]
        public void AssignTransactionsToGroup()
        {
            PrepareData();

            TransactionController tr = new TransactionController();
            GroupController gc = new GroupController();

            //only 1 transaction assigned to group 1
            //ICollection<Transaction> transactions = null;
            ICollection<Transaction> transactions = gc.GetAllTransactionForGroup(2);
            Assert.IsTrue(transactions.Count == 1);

            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.CurrentSession.Evict(transactions);
            UnitOfWork.CurrentSession.Clear();

            //assign 2 other transactions
            gc.AssignTransactionsToGroup(new List<int>() { 1, 2 }, 2);

            //should be 3
            transactions = gc.GetAllTransactionForGroup(2);
            Assert.IsTrue(transactions.Count == 3);

        }



    }
}