using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Stock.Core.Manager;
using Stock.Interfaces;
using Stock.Core.Domain;
using Stock.Presenters;

namespace Stock.Test.PresenterTests
{
    [TestFixture]
    public class CreditPresenterTest
    {
        #region Setup
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        } 
        #endregion

        [Test]
        public void WhenWeChangeTheViewDoesTheModelUpdate()
        {
            MockView mockView = new MockView();
            Credit credit = CreateSampleCredit();
            new CreditPresenter(credit, mockView, new BasicEmptyManager<Credit>() );

            string bankName = "New Bank Name";
            mockView.BankName = bankName;
            mockView.FireDataChanged();

            Assert.AreEqual(bankName, credit.BankName);
        }

        [Test]
        public void DoesViewCorrespondToModel()
        {
            MockView mockView = new MockView();
            Credit credit = CreateSampleCredit();
            new CreditPresenter(credit, mockView, new BasicEmptyManager<Credit>());

            Assert.AreEqual(credit.BankName, mockView.BankName);
        }

        private static Credit CreateSampleCredit()
        {
            Credit credit = new Credit();
            credit.BankName = "Sample Bank Name";
            return credit;
        }

        class MockView : ICreditView
        {

            #region ICreditViewMVP Members

            private string _BankName;
            public string BankName
            {
                get
                {
                    return _BankName;
                }
                set
                {
                    _BankName = value;
                }
            }

            private string _Name;
            public string Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }
            }

            private DateTime _StartDate;
            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }
                set
                {
                    _StartDate = value;
                }
            }

            private DateTime _FinishDate;
            public DateTime FinishDate
            {
                get
                {
                    return _FinishDate;
                }
                set
                {
                    _FinishDate = value;
                }
            }

            private decimal _Amount;
            public decimal Amount
            {
                get
                {
                    return _Amount;
                }
                set
                {
                    _Amount = value;
                }
            }

            private decimal _YearlyInterestPercent;
            public decimal YearlyInterestPercent
            {
                get
                {
                    return _YearlyInterestPercent;
                }
                set
                {
                    _YearlyInterestPercent = value;
                }
            }

            private decimal _ProvisionPercent;
            public decimal ProvisionPercent
            {
                get
                {
                    return _ProvisionPercent;
                }
                set
                {
                    _ProvisionPercent = value;
                }
            }

            private decimal _InsurancePercent;
            public decimal InsurancePercent
            {
                get
                {
                    return _InsurancePercent;
                }
                set
                {
                    _InsurancePercent = value;
                }
            }

            private decimal _MinInstallment;
            public decimal MinInstallment
            {
                get
                {
                    return _MinInstallment;
                }
                set
                {
                    _MinInstallment = value;
                }
            }

            private ICollection<Credit> collection;
            public ICollection<Credit> ItemsList
            {
                set { collection = value; }
            }

            public event EventHandler AddItem;
            
            public event EventHandler GetItem;

            public event EventHandler ItemsListChanged;

            public event EventHandler ItemChanged;

            #endregion

            public void FireDataChanged()
            {
                if (this.ItemChanged != null)
                {
                    this.ItemChanged(null, EventArgs.Empty);
                }
            }
        }
    }
}
