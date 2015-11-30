using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using NHibernate;
using Rhino.Commons;
using Stock.Core.Domain;
using Order=NHibernate.Criterion.Order;
using NHibernate.Criterion;
using log4net;

namespace Stock.Core.Controller
{
    public class CreditManager 
    {
        public Credit AddNewCredit(Credit credit)
        {
            try
            {
                using (UnitOfWork.Start())
                {
                    credit = Repository<Credit>.Save(credit);
                    UnitOfWork.Current.TransactionalFlush();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return credit;
        }

        public Credit GetCredit(int creditId)
        {
            return Repository<Credit>.Get(creditId);
        }



        public ICollection<Credit> GetAllCredits()
        {
            ICollection<Credit> results = null;
            using (UnitOfWork.Start())
            {
                results = Repository<Credit>.FindAll(0, 100, new Order("ID", true));
            }
            
            return results;
        }
    }
}
