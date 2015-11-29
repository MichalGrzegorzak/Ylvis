using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.Accounts;

namespace Core.UI
{
    public partial class AccountUserCtrl : UserControl,IAccountUserCtrl
    {
        private AccountBase account;

        public AccountUserCtrl()
        {
            InitializeComponent();
        }
        public AccountUserCtrl(AccountBase account)
        {
            InitializeComponent();
            this.account = account;
        }

        public void BindToAccount()
        {
            Position = account.Position;

            grbAccount.Text += account.Credentials.AccountId.ToString();
            txbPrice.Text = account.Position.EntryPoint.ToString();
            txbDate.Text = account.Position.EntryDate.ToShortDateString() 
                + " " +  account.Position.EntryDate.ToShortTimeString();
            //txbStop.Text = account.Position.
        }

        public void RefreshPosition()
        {
            account.Login();
            account.GetCurrentPosition();
            account.Logout();
        }

        public Position Position
        {
            set
            {
                txbPosition.Text = account.Position.ToString();
                if (account.Position.Direction == "K")
                    txbPosition.BackColor = Color.Green;
                else if (account.Position.Direction == "S")
                    txbPosition.BackColor = Color.Red;
                else
                    txbPosition.BackColor = Color.White;
            }
        }

        
    }
}
