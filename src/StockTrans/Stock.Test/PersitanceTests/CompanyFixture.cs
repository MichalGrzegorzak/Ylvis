using System;
using MbUnit.Framework;
using Rhino.Commons;
using Rhino.Commons.NHibernate;
using Stock.Core.Controller;
using Stock.Core.Domain;
using NHibernate.Exceptions;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Dynamic;
using linqExpression = System.Linq.Expressions;

namespace Stock.Test
{
    [TestFixture]
    public class CompanyFixture : BasePersistanceFixture
    {
        [Test]
        public void CanSaveCompany()
        {
            UnitOfWork.Current.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            Company company = SaveNewMSZCompany();
            
            UnitOfWork.Current.Flush();
            UnitOfWork.CurrentSession.Evict(company);

            UnitOfWork.Current.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            Company fromDb = Repository<Company>.Get(company.ID); //get
            UnitOfWork.Current.TransactionalFlush();

            Assert.AreNotSame(company, fromDb);
            Assert.AreEqual("test name of company", fromDb.Name);
            Assert.AreEqual(company.ID, fromDb.ID);

            Console.WriteLine("-----------------------------------------------------------------");
        }

        private INHibernateQueryable<Company> linqCompany = null;
        

        [Test]
        public void LingToHibernateTesting()
        {
            CanSaveCompany();

            linqCompany = UnitOfWork.CurrentSession.Linq<Company>();

            //FIRST METHOD
            var q = (from comp in linqCompany
                     where comp.ID == "MSZ"
                     select comp).First();

            //SECOND METHOD
            var queryHandler = new QueryHandler<Company>();
            queryHandler.AddCriteria(comp => comp.ID == "MSZ");
            var p = queryHandler.GetList().First();

            bool t = q == p;
            int totalCount = 1;//q.Count();
            
            //var query = from user in session.Linq<User>()
            //            select new { user.Name, RoleName = user.Role.Name };
            //Assert.AreEqual(3, totalCount);
            
            //var p = (from item in UnitOfWork.CurrentSession.Linq<Product>()
            //         where item.Title == ID
            //         select item).First(); 
        }

        //[Test]
        //public void AddTheSameCompany()
        //{
        //    Company company = CreateNewCompany();
        //    Repository<Company>.Save(company); //save

        //    Company company2 = CreateNewCompany();
        //    Repository<Company>.Save(company2); //save
        //}

        [Test]
        public void CantFindCompany()
        {
            Company not = Repository<Company>.Get("dup"); //get
            Assert.IsNull(not);
        }

        public static Company SaveNewMSZCompany()
        {
            Company c = new Company("MSZ");
            c.Name = "test name of company";

            Repository<Company>.SaveOrUpdate(c); //save

            return c;
        }

     

    }
}