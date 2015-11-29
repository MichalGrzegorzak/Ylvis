using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.Core
{
    public class MbankSettings : IDisposable
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            UserId = 0;
            Password = string.Empty;
        }

        #endregion
    }
}
