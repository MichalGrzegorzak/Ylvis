using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using Commons.Extensions;
using Stock.Core;
using Stock.Properties;

namespace Stock.Forms
{
    public partial class ConfigureMbank : Form
    {
        public ConfigureMbank()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MbankSettings settings = new MbankSettings())
            {
                settings.UserId = txbLogin.Text.Trim().Parse<Int32>();
                settings.Password = txbPass.Text.Trim();

                Settings.Default.MyMbankSettings = settings;
                Settings.Default.Save();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
