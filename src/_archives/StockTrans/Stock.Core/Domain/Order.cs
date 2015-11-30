using System;
using System.Collections.Generic;

namespace Stock.Core.Domain
{
    /// <summary>
    /// Order object for NHibernate mapped table Orders.
    /// </summary>
    [Serializable]
    public class Order : DomainObject<System.Int32>
    {

        #region Columns Names
        public static readonly string CustomerIDStr = "CustomerID";
        public static readonly string EmployeeIDStr = "EmployeeID";
        public static readonly string OrderDateStr = "OrderDate";
        public static readonly string RequiredDateStr = "RequiredDate";
        public static readonly string ShippedDateStr = "ShippedDate";
        public static readonly string ShipViaStr = "ShipVia";
        public static readonly string FreightStr = "Freight";
        public static readonly string ShipNameStr = "ShipName";
        public static readonly string ShipAddressStr = "ShipAddress";
        public static readonly string ShipCityStr = "ShipCity";
        public static readonly string ShipRegionStr = "ShipRegion";
        public static readonly string ShipPostalCodeStr = "ShipPostalCode";
        public static readonly string ShipCountryStr = "ShipCountry";
        #endregion

        #region Fields
        private System.String _CustomerID;
        private System.Int32? _EmployeeID;
        private System.DateTime? _OrderDate;
        private System.DateTime? _RequiredDate;
        private System.DateTime? _ShippedDate;
        private System.Int32? _ShipVia;
        private System.Decimal? _Freight;
        private System.String _ShipName;
        private System.String _ShipAddress;
        private System.String _ShipCity;
        private System.String _ShipRegion;
        private System.String _ShipPostalCode;
        private System.String _ShipCountry;
        //private Customer _Customer;
        private Employee _Employee;
        //private Shipper _ShipViaShipper;
        //private IList<OrderDetail> _OrderDetails = new List<OrderDetail>();
        #endregion

        #region Constructor
        public Order()
        {
        }

        public Order(System.Int32 id)
        {
            base.ID = id;
        }
        #endregion

        #region Properties
         public virtual System.String CustomerID {
             get { return _CustomerID; }
             set { _CustomerID = value;}
         }

         public virtual System.Int32? EmployeeID {
             get { return _EmployeeID; }
             set { _EmployeeID = value;}
         }

         public virtual System.DateTime? OrderDate {
             get { return _OrderDate; }
             set { _OrderDate = value;}
         }

         public virtual System.DateTime? RequiredDate {
             get { return _RequiredDate; }
             set { _RequiredDate = value;}
         }

         public virtual System.DateTime? ShippedDate {
             get { return _ShippedDate; }
             set { _ShippedDate = value;}
         }

         public virtual System.Int32? ShipVia {
             get { return _ShipVia; }
             set { _ShipVia = value;}
         }

         public virtual System.Decimal? Freight {
             get { return _Freight; }
             set { _Freight = value;}
         }

         public virtual System.String ShipName {
             get { return _ShipName; }
             set { _ShipName = value;}
         }

         public virtual System.String ShipAddress {
             get { return _ShipAddress; }
             set { _ShipAddress = value;}
         }

         public virtual System.String ShipCity {
             get { return _ShipCity; }
             set { _ShipCity = value;}
         }

         public virtual System.String ShipRegion {
             get { return _ShipRegion; }
             set { _ShipRegion = value;}
         }

         public virtual System.String ShipPostalCode {
             get { return _ShipPostalCode; }
             set { _ShipPostalCode = value;}
         }

         public virtual System.String ShipCountry {
             get { return _ShipCountry; }
             set { _ShipCountry = value;}
         }

         //public virtual Customer Customer{
         //    get { return _Customer; }
         //    set { _Customer = value;}
         //}

         public virtual Employee Employee{
             get { return _Employee; }
             set { _Employee = value;}
         }

         //public virtual Shipper ShipViaShipper{
         //    get { return _ShipViaShipper; }
         //    set { _ShipViaShipper = value;}
         //}

         //public virtual IList<OrderDetail> OrderDetails{
         //    get { return _OrderDetails; }
         //    set { _OrderDetails = value; }
         //}

        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion

     }
}
