using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using Core.Accounts;
using log4net;

namespace Core.Model
{
    public class MonitorWww : MonitorBase
    {
        public MonitorWww()
        {
        }

        protected override bool PositionHasChanged()
        {
            return Framework.Inst.MainAccount.LookForNewPosition();
        }

        protected override Position GetCurrentPosition()
        {
            return Framework.Inst.MainAccount.Position;
        }
    }
}