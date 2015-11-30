using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Core.Domain
{
    public class Credit : DomainObject<Int32>
    {
        #region fields
        private System.String _Name;
        private System.String _BankName;
        private System.DateTime _StartDate;
        private System.DateTime _FinishDate;
        private System.Decimal _Amount;
        private System.Decimal _YearlyInterestPercent;
        private System.Decimal _ProvisionPercent;
        private System.Decimal _InsurancePercent;
        private System.Decimal _MinInstallment;
        #endregion

        #region Constructor
        public Credit()
        {
        }

        public Credit(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region properties
        public virtual System.String Name
        {
         get { return _Name; }
         set { _Name = value; }
        }

        public virtual System.String BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }

        public virtual System.DateTime StartDate
        {
            get
            {
                if (_StartDate == DateTime.MinValue)
                {
                    return System.DateTime.Today;
                }
                return _StartDate;
            }
            set { _StartDate = value; }
        }

        public virtual System.DateTime FinishDate
        {
            get 
            {
                if (_FinishDate == DateTime.MinValue)
                {
                    return System.DateTime.Today;
                }
                return _FinishDate;
            }
            set { _FinishDate = value; }
        }

        public virtual System.Decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public virtual System.Decimal YearlyInterestPercent
        {
            get { return _YearlyInterestPercent; }
            set { _YearlyInterestPercent = value; }
        }

        public virtual System.Decimal ProvisionPercent
        {
            get { return _ProvisionPercent; }
            set { _ProvisionPercent = value; }
        }

        public virtual System.Decimal InsurancePercent
        {
            get { return _InsurancePercent; }
            set { _InsurancePercent = value; }
        }

        public virtual System.Decimal MinInstallment
        {
            get { return _MinInstallment; }
            set { _MinInstallment = value; }
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion
        
    }
}
