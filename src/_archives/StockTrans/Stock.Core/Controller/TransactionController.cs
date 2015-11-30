using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Rhino.Commons;
using Stock.Core.Domain;
using Order=NHibernate.Criterion.Order;
using NHibernate.Criterion;
using System.Data.SqlClient;

namespace Stock.Core.Controller
{
    public class TransactionController 
    {
        public TransactionController()
        {
        }

        public Transaction GetTransaction(int id)
        {
            return Repository<Transaction>.Get(id);
        }

        public ICollection<Transaction> GetAllTransaction()
        {
            DetachedCriteria criteria = DetachedCriteria.For<Transaction>();
                //.Add(Expression.Eq("Customer", customer))
                //.CreateCriteria("Operation")
                //.Add(Expression.Eq("Name", operation));
                
            ICollection <Transaction> results = null;
            results = Repository<Transaction>.FindAll(0, 100, new Order("ID", true));
            return results;
        }

        public Transaction AddNewTransaction(DateTime date, string companyId, int amount, decimal price, bool buy, decimal fee, int groupId)
        {
            CompanyController companyController = new CompanyController();
            GroupController groupController = new GroupController();
            Transaction t = new Transaction();

            #region checking if company symbol exists in table, if not then we must add it
		    Company company = companyController.GetCompany(companyId);
            if (company == null)
            {
                companyController.AddNewCompany(companyId, "brak");
            } 
	        #endregion

            #region processing TransactionGroup

            TransactionGroup group = null;
            if(groupId == 0) //adding new group
            {
                group = groupController.AddNewTransGroup(companyId);
            }
            else
            {
                group = groupController.GetGroup(groupId);
                if (group == null)
                {
                    groupController.AddNewTransGroup(companyId);
                }
            }
            #endregion

            t.Amount = amount;
            t.Price = price;
            t.Fee = fee;
            t.Date = date;
            t.Group = group;
            t.GroupId = group.ID;
            t.Value = price * amount + fee; ;
            t.Buy = buy;

            try
            {
                t = Repository<Transaction>.Save(t);
                UnitOfWork.Current.TransactionalFlush();
            }
            catch (Exception ex)
            {
                UnitOfWork.CurrentSession.Clear();
                throw;
            }

            //t = Repository<Transaction>.Get(t.ID);
            return t;
        }
    }
}
