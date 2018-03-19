using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using WatTest.Controls;

namespace WatTest.Forms
{
    public partial class Form1 : Form
    {
        List<IAccountUserCtrl> AccountsUcList = new List<IAccountUserCtrl>();

        public Form1()
        {
            InitializeComponent();

            AccountUserCtrl main = new AccountUserCtrl(Framework.Inst.MainAccount);
            AccountUserCtrl acc1 = new AccountUserCtrl(Framework.Inst.TestAccount);
            accountsPanel.Controls.Add(main);
            accountsPanel.Controls.Add(acc1);
            AccountsUcList.Add(main);
            AccountsUcList.Add(acc1);

            BindAll();
        }

        public void BindAll()
        {
            foreach (IAccountUserCtrl a in AccountsUcList)
                a.BindToAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Framework.Inst.Configure4Live();
            
            //Framework.Inst.MainAccount.Login();
            //Framework.Inst.MainAccount.GetCurrentPosition();
            //Framework.Inst.TestAccount.Login();
            //Framework.Inst.TestAccount.GetCurrentPosition();

            foreach (IAccountUserCtrl a in AccountsUcList)
                a.RefreshPosition();

            BindAll();
        }
    }
}
