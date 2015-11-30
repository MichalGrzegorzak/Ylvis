using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Commons.UI
{
    public interface ILoginPassForm
    {
        int Id { get; }
        AccountCredentials Credits { get; set; }

        event CredentialsSavedHandler SavePressed;

        void Show();
        void Close();
        void Dispose();
    }
}
