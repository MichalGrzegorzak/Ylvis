using System;
using System.Collections.Generic;
using System.Threading;
using Core.Accounts;

namespace Core.Model
{
    public class AccountUpdater
    {
        public bool UpdaterEnabled = true;
        private OperationsQueue accOperationsQueue = null;

        #region .CTOR
        public AccountUpdater()
            : this(new OperationsQueue())
        {
        }

        public AccountUpdater(OperationsQueue queue)
        {
            accOperationsQueue = queue;
        } 
        #endregion

        void monitor_UpdateAccountEvent(object sender, NewPositionArg e)
        {
            accOperationsQueue.Add(e);
        }

        private readonly int _checkForEverySecond = 1;
        private int _currentSecond = 0;

        public void StartUpdater()
        {
            _currentSecond++;
            if (_currentSecond != _checkForEverySecond)
                return;

            _currentSecond = 0;

            //while (UpdaterEnabled)
            {
                NewPositionArg arg = accOperationsQueue.Get();
                if (arg != null)
                {
                    if (arg.Execute)
                        arg.Account.ChangePositionTo(arg.ToPosition);
                }
            }
        }

        public bool Update(NewPositionArg action)
        {
            return accOperationsQueue.Update(action);
        }
    }

    
}