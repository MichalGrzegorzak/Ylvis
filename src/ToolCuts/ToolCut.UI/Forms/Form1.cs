using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCut.Core;
using ToolCut.Core.Controllers;
using ToolCut.Core.Domain;
using ToolCut.UI.Controls;

namespace ToolCut.UI
{
    public partial class Form1 : Form
    {
        ToolsController ctrl = new ToolsController();
        IList<Tool> commonDataList = new List<Tool>();

        public Form1()
        {
            InitializeComponent();

            commonDataList = ctrl.GetAllTools();
            foreach (Tool data in commonDataList)
            {
                cmbTools.Items.Add(data.Name);
            }
            cmbTools.SelectedIndex = 0;
            
        }

        private void editTool_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            EditCommonData c = new EditCommonData();
            splitContainer1.Panel2.Controls.Add(c);
        }

        private void defineNewToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Controls.Clear();

            InputControl ctrl = new InputControl();
            ctrl.DataEnteredEvent += new DataEntered(ctrl_DataEnteredEvent);
            splitContainer1.Panel1.Controls.Add(ctrl);
        }

        void ctrl_DataEnteredEvent(decimal diameter, decimal sfm)
        {
            splitContainer1.Panel2.Controls.Clear();

            Guid g = commonDataList[cmbTools.SelectedIndex].ID;
            ResultsControl c = new ResultsControl();
            c.SetControl(diameter, sfm, g);
            splitContainer1.Panel2.Controls.Add(c);
        }
    }
}
