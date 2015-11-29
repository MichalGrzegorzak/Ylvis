using System;
using System.Collections.Generic;

namespace Stock.Core.Domain
{
    /// <summary>
    /// Employee object for NHibernate mapped table Employees.
    /// </summary>
    [Serializable]
    public class TransactionGroup : DomainObject<System.Int32>
    {
        #region Columns Names
        public static readonly string LastNameStr = "LastName";
        public static readonly string FirstNameStr = "FirstName";
        public static readonly string TitleStr = "Title";
        public static readonly string TitleOfCourtesyStr = "TitleOfCourtesy";
        public static readonly string BirthDateStr = "BirthDate";
        public static readonly string HireDateStr = "HireDate";
        public static readonly string AddressStr = "Address";
        public static readonly string CityStr = "City";
        public static readonly string RegionStr = "Region";
        public static readonly string PostalCodeStr = "PostalCode";
        public static readonly string CountryStr = "Country";
        public static readonly string HomePhoneStr = "HomePhone";
        public static readonly string ExtensionStr = "Extension";
        public static readonly string PhotoStr = "Photo";
        public static readonly string NotesStr = "Notes";
        public static readonly string ReportsToStr = "ReportsTo";
        public static readonly string PhotoPathStr = "PhotoPath";
        #endregion

        #region Fields
       
        private IList<Transaction> _transactions = new List<Transaction>();

        private String _companyId;
        private Company _company;
        private Decimal? _income; //finalny zysk
        private bool _closed; //czy grupa jest juz zamknieta

        #endregion

        #region Constructor
        public TransactionGroup()
        {
        }

        public TransactionGroup(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        
        public virtual IList<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; }
        }

        public virtual bool Closed
        {
            get { return _closed; }
            set { _closed = value; }
        }

        public virtual Decimal? Income
        {
            get { return _income; }
            set { _income = value; }
        }

        public virtual System.String CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        public virtual Company Company
        {
            get { return _company; }
            set { _company = value; }
        }

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion

     }
}
