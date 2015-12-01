using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commons.UI
{
    public delegate void CredentialsSavedHandler(AccountCredentials credit);

    public partial class LoginAndPassForm : Form, ILoginPassForm
    {
        public static int FormCounter = 0;
        
        public LoginAndPassForm()
        {
            Id = FormCounter++;
            InitializeComponent();

            if (Id == 0)
            {
                lblAccountId.Text = "Main Account";
            }
            else
            {
                lblAccountId.Text += " " + Id;
            }
        }

        public int Id { get; set;}
        public string Title;
        private AccountCredentials _credits;
        public AccountCredentials Credits
        {
            get
            {
                _credits = new AccountCredentials()
                   {
                       AccountId = Id, Login = txbLogin.Text.Trim(), Pass = txbPass.Text.Trim()
                   };
                return _credits;
            }
            set
            {
                _credits = value;
            }
        }

        public event CredentialsSavedHandler SavePressed;

        public void btnSave_Click(object sender, EventArgs e)
        {
            if(SavePressed != null)
            {
                SavePressed.Invoke(Credits);
            }
            
            SavePressed = null;
            this.Close();
        }
    }
}
