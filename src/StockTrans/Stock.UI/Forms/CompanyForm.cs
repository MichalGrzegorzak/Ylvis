using System;
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

namespace Stock.Forms
{
    public partial class CompanyForm : Form
    {
        CompanyController compControl = new CompanyController();

        public CompanyForm()
        {
            InitializeComponent();

            bindingSource1.DataSource = GetCompanies(null);
            dataGridView1.DataSource = bindingSource1.DataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            string fullName = textBox2.Text;

            using(IUnitOfWork unit = UnitOfWork.Start())
            {
                compControl.AddNewCompany(code, fullName);
                bindingSource1.DataSource = GetCompanies(unit);
                dataGridView1.DataSource = bindingSource1.DataSource;
            }
        }

        private ICollection<Company> GetCompanies(IUnitOfWork unit)
        {
            ICollection<Company> result = null;

            if(unit == null)
            {
                using(UnitOfWork.Start())
                {
                    result = compControl.GetAllCompanies();
                }
            }
            else
            {
                result = compControl.GetAllCompanies();
            }
            return result;
        }
    }
}
