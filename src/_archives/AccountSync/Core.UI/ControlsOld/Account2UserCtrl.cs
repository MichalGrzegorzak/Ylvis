using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.Accounts;

namespace Core.UI
{
    public partial class Account2UserCtrl : UserControl, IAccountUserCtrl
    {
        private AccountBase account;

        public Account2UserCtrl()
        {
            InitializeComponent();
        }
        public Account2UserCtrl(AccountBase account)
        {
            InitializeComponent();
            this.account = account;
        }

        public void BindToAccount()
        {
            Position = account.Position;

            grbAccount.Text += account.Credentials.AccountId.ToString();
            lblEntry.Text += " " + account.Position.EntryPoint.ToString();
            lblDate.Text += " " + account.Position.EntryDate.ToShortDateString() 
                + " " +  account.Position.EntryDate.ToShortTimeString();
            //txbStop.Text += account.Position.
        }

        public void RefreshPosition()
        {
            account.GetCurrentPosition();
        }

        public Position Position
        {
            set
            {
                lblPositionEnter.Text = account.Position.ToString();

                if (account.Position.Direction == "K")
                    lblPositionEnter.ForeColor = Color.Green;
                else if (account.Position.Direction == "S")
                    lblPositionEnter.ForeColor = Color.Red;
                else
                    lblPositionEnter.ForeColor = Color.White;
            }
        }

        
    }
}
