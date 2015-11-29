using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AServiceAgent;
using log4net;
using Position = AServiceAgent.Position;

namespace Core.UI.Controls
{
    public partial class Accounts : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");
        
        public Accounts()
        {
            InitializeComponent();
        }

        public void Initialize(IList<Account> accounts)
        {
            foreach (Account acc in accounts)
            {
                AccountUserCtrl ctrl = new AccountUserCtrl(acc.Id);
                panel1.Controls.Add(ctrl);
                ctrl.Bind(acc.Pos);
            }
            log.Info("Accounts initialized.");
        }

        public void UpdateAccount(int id, Position pos)
        {
            foreach (var c in panel1.Controls)
            {
                AccountUserCtrl ctrl = (AccountUserCtrl) c;
                if(ctrl.Id == id)
                {
                    ctrl.Bind(pos);
                    log.Info("Accounts Id: " + id + " position is: " + pos.Size + pos.Direct);
                    break;
                }
            }
        }
    }
}
