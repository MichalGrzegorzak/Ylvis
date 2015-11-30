using System;
using System.Collections.Generic;

namespace Stock.Core.Domain
{
    /// <summary>
    /// Employee object for NHibernate mapped table Employees.
    /// </summary>
    [Serializable]
    public class Transaction : DomainObject<Int32>
    {
        public static readonly string LastNameStr = "LastName";
        public static readonly string FirstNameStr = "FirstName";

        #region Constructor
        public Transaction()
        {
        }

        public Transaction(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Fields

        private DateTime _date;
        private bool _buy;
        private Int32 _amount;
        private Decimal _price;
        private Decimal _value; //wartosc
        private Decimal _fee; //prowizja
        private Company _company;
        
        private Int32 _groupId;
        private TransactionGroup _Group;

        #endregion

        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual bool Buy
        {
            get { return _buy; }
            set { _buy = value; }
        }

        public virtual decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
       

        public virtual Int32 Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public virtual Int32 GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        

        public virtual Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public virtual Decimal Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }

        public virtual Company Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public int TransGroupId
        {
            get { return _Group.ID; }
        }
        
        public virtual TransactionGroup Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion

     }
}
