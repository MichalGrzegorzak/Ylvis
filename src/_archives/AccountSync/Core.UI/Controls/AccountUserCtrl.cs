using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AServiceAgent;

namespace Core.UI.Controls
{
    public partial class AccountUserCtrl : UserControl
    {
        public int Id = 0;
        
        public AccountUserCtrl()
        {
            InitializeComponent();
        }

        public AccountUserCtrl(int id)
        {
            InitializeComponent();
            Id = id;
            grbAccount.Text = "Account: " + id;
        }

        public void Bind(Position pos)
        {
            Position = pos;

            txbPrice.Text = pos.Price.ToString();
            txbDate.Text = pos.Date.ToShortDateString()
                           + " " + pos.Date.ToShortTimeString();
            //txbStop.Text = account.Position.
        }

        public Position Position
        {
            set
            {
                txbPosition.Text = value.Size + " " + value.Direct;
                if (value.Direct == "K")
                    txbPosition.BackColor = Color.Green;
                else if (value.Direct == "S")
                    txbPosition.BackColor = Color.Red;
                else
                    txbPosition.BackColor = Color.White;
            }
        }

        
    }
}
