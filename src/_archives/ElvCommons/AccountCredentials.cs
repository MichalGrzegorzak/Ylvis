using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commons
{
    public class AccountCredentials
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        //#region IDisposable Members

        //public void Dispose()
        //{
        //    Login = string.Empty;
        //    Pass = string.Empty;
        //}

        //#endregion
    }
}
