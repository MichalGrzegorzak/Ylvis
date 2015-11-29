using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock.Interfaces;
using System.Collections;
using Stock.Core.Domain;

namespace Stock.Forms
{
    public partial class CreditFormMVP : Form, ICreditView
    {
        public CreditFormMVP()
        {
            InitializeComponent();
            //AddCreditButton.Click += AddItem;
        }


        #region ICreditViewMVP Members

        public string BankName
        {
            get
            {
                return this.BankNameTextBox.Text;
            }
            set
            {
                this.BankNameTextBox.Text = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.StartDateDateTimePicker.Value;
            }
            set
            {
                this.StartDateDateTimePicker.Value = value;
            }
        }

        public DateTime FinishDate
        {
            get
            {
                return this.FinishDateDateTimePicker.Value;
            }
            set
            {
                this.FinishDateDateTimePicker.Value = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return Decimal.Parse(this.AmountTextBox.Text);
            }
            set
            {
                this.AmountTextBox.Text = value.ToString();
            }
        }

        public decimal YearlyInterestPercent
        {
            get
            {
                return Decimal.Parse(YearlyInterestPercentTextBox.Text);
            }
            set
            {
                this.YearlyInterestPercentTextBox.Text = value.ToString();
            }
        }

        public decimal ProvisionPercent
        {
            get
            {
                return Decimal.Parse(ProvisionPercentTextBox.Text);
            }
            set
            {
                this.ProvisionPercentTextBox.Text = value.ToString();
            }
        }

        public decimal InsurancePercent
        {
            get
            {
                return Decimal.Parse(InsurancePercentTextBox.Text);
            }
            set
            {
                this.InsurancePercentTextBox.Text = value.ToString();
            }
        }

        public decimal MinInstallment
        {
            get
            {
                return Decimal.Parse(MinInstallmentTextBox.Text);
            }
            set
            {
                this.MinInstallmentTextBox.Text = value.ToString();
            }
        }

        public event EventHandler AddItem;
        public event EventHandler GetItem;
        public event EventHandler ItemsListChanged;
        public event EventHandler ItemChanged;

        public ICollection<Credit> ItemsList
        {
            set
            {
                this.dataGridView1.DataSource = value;
            }
        }

        #endregion

        private void AddCreditButton_Click(object sender, EventArgs e)
        {
            //if (this.AddCredit != null)
            //{
            //    this.AddCredit(sender, e);
            //    this.ItemsListChanged(sender, e);
            //}
            AddItem(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new GenericForm();
            f.Show();

        }

    }
}
