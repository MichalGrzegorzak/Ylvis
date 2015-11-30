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

namespace Stock.Core.Manager
{
    public class CreditManager : BasicManager<Credit>
    {
    }
}
