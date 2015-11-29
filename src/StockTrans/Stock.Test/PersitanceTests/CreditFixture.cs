using MbUnit.Framework;
using Rhino.Commons;
using Stock.Core.Domain;
using System;

namespace Stock.Test
{
    [TestFixture]
    public class CreditFixture : BasePersistanceFixture
    {
        [Test]
        public void CanSaveCredit()
        {
            UnitOfWork.Current.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            Credit credit = SaveNewCredit();
            
            UnitOfWork.Current.Flush();
            UnitOfWork.CurrentSession.Evict(credit);

            UnitOfWork.Current.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            Credit fromDb = Repository<Credit>.Get(credit.ID); //get
            UnitOfWork.Current.TransactionalFlush();

            Assert.AreNotSame(credit, fromDb);
            Assert.AreEqual("test credit", fromDb.Name);
            Assert.AreEqual(credit.ID, fromDb.ID);

            Console.WriteLine("-----------------------------------------------------------------");
        }

        [Test]
        public void CanGetCredit()
        {
            //save sample credit in the db
            UnitOfWork.Current.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            Credit credit = SaveNewCredit();

            UnitOfWork.Current.Flush();
            UnitOfWork.CurrentSession.Evict(credit);

            //get saved credit
            NHibernate.Criterion.Order order = new NHibernate.Criterion.Order("Name", true);

            Credit creditDb = Repository<Credit>.FindFirst(order);
            Assert.AreEqual(creditDb, credit);
        }

        public static Credit SaveNewCredit()
        {
            Credit credit = new Credit();
            credit.Name = "test credit";
            credit.BankName = "test bank";
            credit.StartDate = System.DateTime.Today;
            credit.FinishDate = System.DateTime.Today.AddDays(30);
            credit.Amount = 10000;
            credit.ProvisionPercent = 2;
            credit.InsurancePercent = 5;
            credit.YearlyInterestPercent = 18;
            credit.MinInstallment = 10;

            Repository<Credit>.SaveOrUpdate(credit); //save

            return credit;
        }

     

    }
}