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

namespace Stock.Core.Controller
{
    public class GroupController 
    {
        public GroupController()
        {
        }

        public TransactionGroup AddNewTransGroup(string companyId)
        {
            return AddNewTransGroup(companyId, false, 0);
        }

        public TransactionGroup AddNewTransGroup(string companyId, bool closed, decimal income)
        {
            TransactionGroup g = new TransactionGroup();
            g.CompanyId = companyId;
            g.Closed = false;
            g.Income = income;

            try
            {
                Repository<TransactionGroup>.Save(g);
                UnitOfWork.Current.TransactionalFlush();
            }
            catch (Exception ex)
            {
                UnitOfWork.CurrentSession.Clear();
                return null;
            }

            return g;
        }

        public TransactionGroup GetGroup(int groupId)
        {
            return Repository<TransactionGroup>.Get(groupId);
        }

        public ICollection<TransactionGroup> GetAllGroups()
        {
            DetachedCriteria criteria = DetachedCriteria.For<TransactionGroup>();

            ICollection<TransactionGroup> results = null;
            results = Repository<TransactionGroup>.FindAll(0, 100, new Order("ID", true));
            return results;
        }

        public ICollection<Transaction> GetAllTransactionForGroup(int groupId)
        {
            //DetachedCriteria criteria = DetachedCriteria.For<TransactionGroup>()
            //    .Add(Expression.Eq("ID", groupId));
            AbstractCriterion criteria = Expression.Eq("ID", groupId);

            TransactionGroup results = Repository<TransactionGroup>.FindOne(criteria);
            ICollection<Transaction> transactions = results.Transactions;
            return transactions;
        }

        public void AssignTransactionsToGroup(IList<Int32> transactionsIDs, int groupId)
        {
            DetachedCriteria criteria = DetachedCriteria.For<Transaction>()
                .Add(Expression.In("ID", transactionsIDs.ToArray()));
            //SimpleExpression where1 = Expression.In("ID", new object[] {1,2});
            //SimpleExpression where2 = Expression.In("ID", 1);
            //foreach (int id in transactionsIDs)
            //{
            //    criteria.Add(Expression.Eq("ID", id));
            //}

            ICollection<Transaction> transactions = Repository<Transaction>.FindAll(criteria);
            
            //Check.Require
            //Assert.IsTrue(transactions.Count == transactionsIDs.Count);

            foreach(Transaction t in transactions)
            {
                t.GroupId = groupId;
                Repository<Transaction>.SaveOrUpdate(t);
            }

            UnitOfWork.Current.TransactionalFlush();
        }

    }
}
