using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using Core.Accounts;
using Core.Watcher;
using log4net;

namespace Core.Model
{
    public class MonitorGmail : MonitorBase
    {
        GmailWatcher watcher = new GmailWatcher();

        public MonitorGmail() 
        {
        }

        protected override bool PositionHasChanged()
        {
            SysCmd syg = watcher.GetCommand();
            if (syg != SysCmd.None)
                return true;
            
            return false;
        }

        protected override Position GetCurrentPosition()
        {
            //Framework.Inst.MainAccount.ChangeAccount();
            Framework.Inst.MainAccount.Login();
            Position p = Framework.Inst.MainAccount.GetCurrentPosition();
            Framework.Inst.MainAccount.Logout();
            return p;
        }
    }
}