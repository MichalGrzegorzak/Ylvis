using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Core.Domain;

namespace Stock.Core.Manager
{
    public abstract class ManagerFactory<T> where T : class
    {
        public static IBasicManager<T> Create()
        {
            IBasicManager<T> manager = null;

            if(typeof(T) == typeof(Credit))
            {
                manager = (IBasicManager<T>) new CreditManager();
            }
            else if (typeof(T) == typeof(Company))
            {
                manager = (IBasicManager<T>)new CreditManager();
            }
            else if (typeof(T) == typeof(Transaction))
            {
                manager = (IBasicManager<T>)new CreditManager();
            }
            else if (typeof(T) == typeof(TransactionGroup))
            {
                manager = (IBasicManager<T>)new CreditManager();
            }

            return manager;
        }
    }
}
