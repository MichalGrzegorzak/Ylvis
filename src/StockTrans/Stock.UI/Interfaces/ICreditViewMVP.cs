using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Core.Domain;

namespace Stock.Interfaces
{
    public interface ICreditViewMVP
    {
        System.String BankName { get; set; }

        System.String Name { get; set; }
        
        System.DateTime StartDate { get; set; }
        
        System.DateTime FinishDate { get; set; }
        
        System.Decimal Amount { get; set; }
        
        System.Decimal YearlyInterestPercent { get; set; }
        
        System.Decimal ProvisionPercent { get; set; }
        
        System.Decimal InsurancePercent { get; set; }
        
        System.Decimal MinInstallment { get; set; }

        ICollection<Credit> CreditSource { set; }

        event EventHandler AddCredit;
        event EventHandler DataSourceChanged;
        event EventHandler DataChanged;

        
    }
}
