﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AServiceAgent;

namespace AServiceClient
{
    public interface IAccountUserCtrl
    {
        void BindToAccount();
        void RefreshPosition();
        Position Position { set; }
    }
}
