using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.Extensions;

namespace Core.UI.Controls
{
    public partial class DoActionOnPosition : UserControl
    {
        public event Action BtnAction = null;
        
        public DoActionOnPosition()
        {
            InitializeComponent();

            //SETUP
            cmbDirection.SelectedIndex = 0;
        }

        public int PositionSize
        {
            get
            {
                return txbSize.Text.Parse<Int32>();
            }
        }

        public string PositionDir
        {
            get
            {
                return cmbDirection.SelectedItem.ToString();
            }
        }

        public string BtnName
        {
            set
            {
                btnAction.Text = value;
            }
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = cmbDirection.SelectedItem.ToString().Trim();
            if(dir == "K")
            {
                txbSize.BackColor = Color.Green;
            }
            else if(dir == "S")
            {
                txbSize.BackColor = Color.Red;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (BtnAction == null)
                throw new Exception("DoActionOnPosition -> Action must be connected to button!!");

            BtnAction.Invoke();
        }
    }
}
