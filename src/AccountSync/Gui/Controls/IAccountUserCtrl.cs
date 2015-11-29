using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace WatTest.Controls
{
    public interface IAccountUserCtrl
    {
        void BindToAccount();
        void RefreshPosition();
        Position Position { set; }
    }
}
