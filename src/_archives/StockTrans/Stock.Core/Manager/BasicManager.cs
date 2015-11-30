using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Commons;
using Stock.Core.Domain;
using Order=NHibernate.Criterion.Order;

namespace Stock.Core.Manager
{
    public class BasicManager<T> : IBasicManager<T> where T : DomainObject<Int32> 
    {
        public virtual T Add(T item)
        {
            try
            {
                using (UnitOfWork.Start())
                {
                    item = Repository<T>.Save(item);
                    UnitOfWork.Current.TransactionalFlush();

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return item;   
        }

        public virtual void Delete(T item)
        {
            using (UnitOfWork.Start())
            {
                Repository<T>.Delete(item);
            }
        }

        public virtual T GetItem(int id)
        {
            using (UnitOfWork.Start())
            {
                return Repository<T>.Get(id);
            }
        }

        public virtual ICollection<T> GetAll()
        {
            ICollection<T> results = null;
            using (UnitOfWork.Start())
            {
                results = Repository<T>.FindAll(0, 100, new Order("ID", true));
            }

            return results;
        }
    }
}
