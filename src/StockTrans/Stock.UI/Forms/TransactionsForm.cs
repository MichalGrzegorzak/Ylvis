using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rhino.Commons;
using Stock.Core.Domain;
using Stock.Core.Controller;

namespace Stock
{
    public partial class TransactionsForm : Form
    {
        TransactionController transControl = new TransactionController();

        public TransactionsForm()
        {
            InitializeComponent();

            bindingSource1.DataSource = GetTransactions(null);
            dataGridView1.DataSource = bindingSource1.DataSource;

            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string companyId = txtCode.Text;
            DateTime date = dtpDate.Value;
            bool buy = chbBuy.Checked;
            int amount = Int32.Parse(txtAmount.Text);
            decimal price = Decimal.Parse(txtPrice.Text);
            decimal fee = Decimal.Parse(txtFee.Text);
            int groupId = 0;
            
            try
            {
                groupId = Int32.Parse(txtGroupId.Text);
            }
            catch
            {
            }

            using (IUnitOfWork unit = UnitOfWork.Start())
            {
                transControl.AddNewTransaction(date, companyId, amount, price, buy, fee, groupId);
                bindingSource1.DataSource = GetTransactions(unit);
                dataGridView1.DataSource = bindingSource1.DataSource;
            }
            //IoC.Resolve<IUnitOfWorkFactory>().Init();
        }

        private ICollection<Transaction> GetTransactions(IUnitOfWork unit)
        {
            ICollection<Transaction> result = null;

            if (unit == null)
            {
                using (UnitOfWork.Start())
                {
                    result = transControl.GetAllTransaction();
                }
            }
            else
            {
                result = transControl.GetAllTransaction();
            }
            return result;
        }

        private List<int> transactionsIds = new List<int>();
        private int min_group = Int32.MaxValue;
        public int MinGroupValue
        {
            get
            {
                return min_group;
            }
            set
            {
                min_group = value;
                textBox1.Text = min_group.ToString();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
                int group = (int)row.Cells[5].Value;
                int id = (int)row.Cells[0].Value;
                if((bool) row.Cells[6].Value)
                {
                    transactionsIds.Add(id);

                    if (MinGroupValue > group)
                        MinGroupValue = group;
                }
                else
                {
                    transactionsIds.Remove(id);
                }
            }
            
        }

        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (UnitOfWork.Start())
            {
                ICollection<Transaction> results = transControl.GetAllTransaction();
                dataGridView1.DataSource = results;
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (transactionsIds.Count <= 0)
                return;

            //assing
            using (IUnitOfWork unit = UnitOfWork.Start())
            {
                GroupController contr = new GroupController();
                contr.AssignTransactionsToGroup(transactionsIds, MinGroupValue);

                bindingSource1.DataSource = GetTransactions(unit);
                dataGridView1.DataSource = bindingSource1.DataSource;

                transactionsIds.Clear(); //clear the collection
            }

            //
            using (IUnitOfWork unit = UnitOfWork.Start())
            {
                GroupController contr = new GroupController();
                ICollection<Transaction> tran = contr.GetAllTransactionForGroup(1);
            }
        }

        
        
    }
}
