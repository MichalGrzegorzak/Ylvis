using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using Stock.Core.Controller;
using Stock.Core.Domain;

namespace Stock.Forms
{
    public partial class CreditForm : Form
    {
        CreditManager controller = new CreditManager();

        public CreditForm()
        {
            InitializeComponent();

            bindingSource1.DataSource = GetCredits();
            dataGridView1.DataSource = bindingSource1.DataSource;
        }

        private ICollection<Credit> GetCredits()
        {
            return controller.GetAllCredits();
        }

        private void AddCreditButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string bankName = BankNametextBox.Text;
            DateTime startDate = StartDateDateTimePicker.Value;
            DateTime finishDate = FinishDateDateTimePicker.Value;
            decimal amount = Decimal.Parse(AmountTextBox.Text);
            decimal yearlyInterstPercent = Decimal.Parse(YearlyInterestPercentTextBox.Text);
            decimal provisionPercent = Decimal.Parse(ProvisionPercentTextBox.Text);
            decimal insurancePercent = Decimal.Parse(InsurancePercentTextBox.Text);
            decimal minInstallment = Decimal.Parse(MinInstallmentTextBox.Text);

            controller.AddNewCredit(name, bankName, startDate, finishDate, amount, yearlyInterstPercent, provisionPercent, insurancePercent, minInstallment);

            bindingSource1.DataSource = GetCredits();
            dataGridView1.DataSource = bindingSource1.DataSource;
        }

        private static readonly ILog logger = LogManager.GetLogger(typeof(CreditForm));

        private void button1_Click(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();

            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");

        }
    } 
}
