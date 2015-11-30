using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rhino.Commons;
using ToolCut.Core;
using ToolCut.Core.Controllers;
using ToolCut.Core.Domain;

namespace ToolCut.UI.Controls
{
    public partial class EditCommonData : UserControl
    {
        public EditCommonData()
        {
            InitializeComponent();
        }

        private void EditCommonData_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tool cd = new Tool();
            cd.Milling2 = Decimal.Parse(txbMilling.Text);
            cd.Rgh.Milling2 = Decimal.Parse(txbRghMilling.Text);
            cd.SemiFin.Milling2 = Decimal.Parse(txbSemiFinMilling.Text);
            cd.Fin.Milling2 = Decimal.Parse(txbSemiFinMilling.Text);
            
            cd.CrbDrill = Decimal.Parse(txbCrbDrill.Text);
            cd.HssDrill= Decimal.Parse(txbHsbDrill.Text);
            cd.Name = txbName.Text;

            ToolsController cdCtrl = new ToolsController();
            using (UnitOfWork.Start())
            {
                cdCtrl.SaveNew(cd);
                UnitOfWork.Current.Flush();
            }
        }
    }
}
