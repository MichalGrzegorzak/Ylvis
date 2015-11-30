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
    public class TransactionFixture : BasePersistanceFixture
    {
        [Test]
        public void CanSaveTransaction()
        {
            CompanyFixture.SaveNewMSZCompany(); //saving MSZ
            GroupFixture.CreateNewTransactionGroup(); //saving group

            Transaction tran = CreateNewTransaction(1);
            
            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.CurrentSession.Evict(tran);

            Transaction fromDb = Repository<Transaction>.Get(tran.ID); //get

            Assert.AreNotSame(tran, fromDb);
            Assert.AreEqual(100, fromDb.Amount);
            Assert.AreEqual(123.50M, fromDb.Fee);
            Assert.AreEqual(2.50M, fromDb.Price);
            Assert.AreEqual(true, fromDb.Buy);
            decimal val = fromDb.Amount*fromDb.Price + fromDb.Fee;
            Assert.AreEqual(val, fromDb.Value);
            Assert.AreEqual(tran.ID, fromDb.ID);
            Console.WriteLine("-----------------------------------------------------------------");
        }

       //[Test]
        //[ExpectedException(typeof(Exception))]
        //public void CannotSaveTransaction()
        //{
        //    Transaction tran = CreateNewTransaction(1);
        //    Assert.AreEqual(1, tran.ID);

        //    TransactionController controller = new TransactionController();
        //    controller.AddNewTransaction(DateTime.Now, "MSZ", 100, 2, true, 24, 0);
        //    //
        //    UnitOfWork.Current.TransactionalFlush();
        //    UnitOfWork.CurrentSession.Evict(tran);
        //}

        [Test]
        public void GetAllTransactionsAndVerifyGroup()
        {
            CanSaveTransaction();
            CreateNewTransaction(1);

            TransactionController controller = new TransactionController();
            ICollection<Transaction> transactions = controller.GetAllTransaction();
            Assert.IsNotEmpty((ICollection)transactions);

            //checking if Group was fetched
            IList<Transaction> tran = transactions as IList<Transaction>;
            Assert.IsNotNull(tran[0].Group);
        }

        public static Transaction CreateNewTransaction(int groupId)
        {
            Transaction t = new Transaction();
            t.Amount = 100;
            t.Fee = 123.50M;
            t.Price = 2.50M;
            t.Date = DateTime.Now;
            t.Buy = true;
            t.GroupId = groupId;
            t.Value = t.Price*t.Amount + t.Fee;
            t.Company = new Company("MSZ");

            Assert.AreEqual(0, t.ID);
            t = Repository<Transaction>.Save(t); //save

            return t;
        }

    }
}