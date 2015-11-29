using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using WatTest.Properties;
using Core.Makler;

namespace WatTest.Forms
{
    public partial class LoginAndPassForm : Form
    {
        private int _accountId;

        public LoginAndPassForm(int accountId)
        {
            _accountId = accountId;
            InitializeComponent();

            if(_accountId == 0)
            {
                lblAccountId.Text = "Main Account";
            }
            else
            {
                lblAccountId.Text += " " + _accountId;
            }
           
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            Credentials uap = new Credentials();
            uap.Login = txbLogin.Text.Trim();
            uap.Pass = txbPass.Text.Trim();
            uap.Id = _accountId;

            if(_accountId == 0)
            {
                CoreSettings.MainAccount = uap;
            }
            else if(_accountId == 1)
            {
                CoreSettings.TestAccount = uap;
            }
            else
            {
                throw new NotSupportedException("Unknow account id = " + _accountId);
            }

            this.Close();
        }
    }
}
