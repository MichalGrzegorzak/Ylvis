using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using linqExpression = System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using Rhino.Commons;
using NHibernate.Linq;


namespace Stock.Core.Controller
{
    public class QueryHandler<T>
    {
        private IList<linqExpression.Expression<Func<T, bool>>>  _criteria;

        public QueryHandler()
        {
            _criteria = new List<linqExpression.Expression<Func<T, bool>>>();
        }

        public void AddCriteria(linqExpression.Expression<Func<T, bool>> LambdaFunc)
        {
            _criteria.Add(LambdaFunc);
        }

        public IList<T> GetList()
        {
            var query = from item in UnitOfWork.CurrentSession.Linq<T>()
                        select item;

            //Tack on our query Criteria
            foreach (var criterion in _criteria)
            {
                 query = query.Where<T>(criterion);
            }

            return query.ToList();
        }
    }
}
