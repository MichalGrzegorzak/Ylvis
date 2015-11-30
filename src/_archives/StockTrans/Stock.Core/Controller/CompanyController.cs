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
    public class CompanyController 
    {
        public CompanyController()
        {
        }

        public Company AddNewCompany(string symbol, string description)
        {
            Company c = new Company(symbol);
            c.Name = description;

            try
            {
                c = Repository<Company>.Save(c);
                UnitOfWork.Current.TransactionalFlush();
            }
            catch (Exception)
            {
                UnitOfWork.CurrentSession.Clear();
                return null;
            }
            return c;
        }

        public Company GetCompany(string symbol)
        {
            return Repository<Company>.Get(symbol);
        }

        public ICollection<Company> GetAllCompanies()
        {
            ICollection<Company> results = null;
            results = Repository<Company>.FindAll(0, 100, new Order("ID", true));
            return results;
        }
    }
}
