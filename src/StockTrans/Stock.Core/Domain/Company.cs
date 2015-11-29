using System;
using System.Collections.Generic;

namespace Stock.Core.Domain
{
    /// <summary>
    /// Order object for NHibernate mapped table Orders.
    /// </summary>
    [Serializable]
    public class Company : DomainObject<System.String>
    {
        //public static readonly string CustomerIDStr = "CustomerID";
        
        private String _name;
        private String _paperCode;
        
        #region Constructor
        public Company()
        {
        }

        public Company(System.String id)
        {
            base.ID = id;
        }
        #endregion

        public virtual String Name
        {
             get { return _name; }
             set { _name = value; }
        }

        public virtual String PaperCode
        {
            get { return _paperCode; }
            set { _paperCode = value; }
        }

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion

     }
}
