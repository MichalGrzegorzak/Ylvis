using System;
using System.Collections.Generic;

namespace Stock.Core.Domain
{
    /// <summary>
    /// Employee object for NHibernate mapped table Employees.
    /// </summary>
    [Serializable]
    public class Employee : DomainObject<System.Int32>
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
        private System.String _LastName;
        private System.String _FirstName;
        private System.String _Title;
        private System.String _TitleOfCourtesy;
        private System.DateTime? _BirthDate;
        private System.DateTime? _HireDate;
        private System.String _Address;
        private System.String _City;
        private System.String _Region;
        private System.String _PostalCode;
        private System.String _Country;
        private System.String _HomePhone;
        private System.String _Extension;
        private System.Byte[] _Photo;
        private System.String _Notes;
        private System.Int32? _ReportsTo;
        private System.String _PhotoPath;
        private Employee _ReportsToEmployee;
        private IList<Employee> _Employees = new List<Employee>();
        private IList<Order> _Orders = new List<Order>();
        #endregion

        #region Constructor
        public Employee()
        {
        }

        public Employee(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String LastName {
             get { return _LastName; }
             set { _LastName = value;}
         }

         public virtual System.String FirstName {
             get { return _FirstName; }
             set { _FirstName = value;}
         }

         public virtual System.String Title {
             get { return _Title; }
             set { _Title = value;}
         }

         public virtual System.String TitleOfCourtesy {
             get { return _TitleOfCourtesy; }
             set { _TitleOfCourtesy = value;}
         }

         public virtual System.DateTime? BirthDate {
             get { return _BirthDate; }
             set { _BirthDate = value;}
         }

         public virtual System.DateTime? HireDate {
             get { return _HireDate; }
             set { _HireDate = value;}
         }

         public virtual System.String Address {
             get { return _Address; }
             set { _Address = value;}
         }

         public virtual System.String City {
             get { return _City; }
             set { _City = value;}
         }

         public virtual System.String Region {
             get { return _Region; }
             set { _Region = value;}
         }

         public virtual System.String PostalCode {
             get { return _PostalCode; }
             set { _PostalCode = value;}
         }

         public virtual System.String Country {
             get { return _Country; }
             set { _Country = value;}
         }

         public virtual System.String HomePhone {
             get { return _HomePhone; }
             set { _HomePhone = value;}
         }

         public virtual System.String Extension {
             get { return _Extension; }
             set { _Extension = value;}
         }

         public virtual System.Byte[] Photo {
             get { return _Photo; }
             set { _Photo = value;}
         }

         public virtual System.String Notes {
             get { return _Notes; }
             set { _Notes = value;}
         }

         public virtual System.Int32? ReportsTo {
             get { return _ReportsTo; }
             set { _ReportsTo = value;}
         }

         public virtual System.String PhotoPath {
             get { return _PhotoPath; }
             set { _PhotoPath = value;}
         }

         public virtual Employee ReportsToEmployee{
             get { return _ReportsToEmployee; }
             set { _ReportsToEmployee = value;}
         }

         public virtual IList<Employee> Employees{
             get { return _Employees; }
             set { _Employees = value; }
         }
         

         public virtual IList<Order> Orders
         {
             get { return _Orders; }
             set { _Orders = value; }
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
