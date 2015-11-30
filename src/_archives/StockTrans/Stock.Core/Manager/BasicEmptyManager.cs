using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Commons;
using Stock.Core.Domain;
using Order=NHibernate.Criterion.Order;

namespace Stock.Core.Manager
{
    public class BasicEmptyManager<T> : BasicManager<T> where T : DomainObject<Int32> 
    {
        public override T Add(T item)
        {
            return default(T);   
        }

        public override void Delete(T item)
        {
        }

        public override T GetItem(int id)
        {
            return default(T);
        }

        public override ICollection<T> GetAll()
        {
            ICollection<T> results = new List<T>();
            return results;
        }
    }
}
