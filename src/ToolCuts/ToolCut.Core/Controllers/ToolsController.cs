using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Rhino.Commons;
using NHibernate.Criterion;
using ToolCut.Core.Domain;

namespace ToolCut.Core.Controllers
{
    public class ToolsController
    {
        public IList<Tool> GetAllTools()
        {
            DetachedCriteria criteria = DetachedCriteria.For<Tool>()
                .Add(Expression.IsNotNull("Rgh"))
                .Add(Expression.IsNotNull("SemiFin"))
                .Add(Expression.IsNotNull("Fin"))
                .Add(Expression.IsNotNull("FineFin"));

            IList<Tool> results = null;
            using (UnitOfWork.Start())
            {
                results = Repository<Tool>.FindAll(criteria, 0, 100, new Order("ID", true)) as IList<Tool>;
            }
            return results;
        }

        public Tool SaveNew(Tool cd)
        {
            return Repository<Tool>.Save(cd);
        }

        public Tool Get(Guid id)
        {
            return Repository<Tool>.Get(id);
        }
    }
}
