using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace Commons.UI
{
    public class ShowFormGetValue<F> where F : ILoginPassForm, new()
    {
        public ShowFormGetValue(CredentialsSavedHandler handler)
        {
            ILoginPassForm form = new F();
            form.SavePressed += handler;
            form.Show();
        }
    }

    
}
