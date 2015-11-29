using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rhino.Commons;
using ToolCut.Core.Controllers;
using ToolCut.Core.Domain;

namespace ToolCut.UI
{
    public partial class ResultsControl : UserControl
    {
        public ResultsControl()
        {
            InitializeComponent();
        }

        public void SetControl(decimal dia, decimal sfm, Guid tool)
        {
            _dia = dia;
            _sfm = sfm;

            using (UnitOfWork.Start())
            {
                ToolsController ctrl = new ToolsController();
                _cd = ctrl.Get(tool);
            }

            Calculate();
        }

        private decimal _dia;
        private decimal _sfm;
        private Tool _cd = null;

        private void Calculate()
        {
            decimal milling = Math.Round(_sfm / _dia * _cd.Milling2, 0);
            decimal crbDrill = Math.Round(_cd.CrbDrill / _dia, 0);
            decimal hssDrill = Math.Round(_cd.HssDrill/_dia, 0);
            decimal reamer = Math.Round(_cd.Reamer/_dia, 0);

            decimal rghMilling = Math.Round(milling * 0.02M, 0);
            decimal rghCrbDrill = Math.Round(crbDrill * 0.0018M, 1);
            decimal rghHssDrill = Math.Round(hssDrill * 0.0018M, 1);
            decimal rghRemer = Math.Round(reamer * 0.01M, 1);

            decimal semiFinMilling = Math.Round(milling * _cd.SemiFin.Milling2, 0); //.SemiFinMilling, 0);
            decimal finMilling = Math.Round(milling * _cd.Fin.Milling2, 0); //FinMilling, 0);

            lblMillingRes.Text = milling.ToString();
            lblCrbRes.Text = crbDrill.ToString();
            lblHssRes.Text = hssDrill.ToString();
            lblReamerRes.Text = reamer.ToString();

            lblRghMilling.Text = rghMilling.ToString();
            lblRghCrbDrill.Text = rghCrbDrill.ToString();
            lblRghHssDrill.Text = rghHssDrill.ToString();
            lblRghRemer.Text = rghRemer.ToString();

            lblSemiFinMilling.Text = semiFinMilling.ToString();
            lblFinMillng.Text = finMilling.ToString();
        }
    
    }
}
