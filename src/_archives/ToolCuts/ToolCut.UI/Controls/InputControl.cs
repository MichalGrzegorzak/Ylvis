using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCut.UI
{
    public delegate void DataEntered(decimal diameter, decimal sfm);
    
    public partial class InputControl : UserControl
    {
        public event DataEntered DataEnteredEvent = null;
        
        public InputControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal dia = Decimal.Parse(txbToolDiameter.Text);
            decimal sfm = Decimal.Parse(txbToolSfm.Text);
            DataEnteredEvent.Invoke(dia, sfm);
        }
    }
}
