using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using Core.Accounts;
using log4net;

namespace Core.Model
{
    public delegate void NewPosition(Position newPos);

    public abstract class MonitorBase
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(MonitorBase));

        public event NewPosition PositionChangeHandler;
        public Position LastPosition = null;
        public bool IsFirstSignal = true;

        public MonitorBase()
        {
        }

        public bool AreAccountsInSync()
        {
            bool result = true;
            Framework.Inst.MainAccount.Login();
            LastPosition = Framework.Inst.MainAccount.GetCurrentPosition();
            Framework.Inst.MainAccount.Logout();

            foreach (AccountBase account in Framework.Inst.AccountsList)
            {
                if (!LastPosition.IsEqual(account.Position))
                {
                    result = false;
                }
            }

            Framework.CallTrace("AreAccountsInSync = " + result);
            return result;
        }

        public int CheckEverySec = 20;
        private int currentSec = 0;

        public bool DetectChange()
        {
            currentSec++;
            if (currentSec != CheckEverySec)
                return false;
            else
                currentSec = 0;

            if (PositionHasChanged()) //detect signal
            {
                Framework.CallTrace("PositionHasChanged!");

                Position current = GetCurrentPosition(); //get signal position
                Framework.CallTrace("Curr pos: " + current.ToString());

                if (SignalIsCorrect(current)) //check if it`s OK
                {
                    Framework.CallTrace("SignalIsCorrect!");

                    PositionChangeHandler.Invoke(current); //update other accounts
                    IsFirstSignal = false;
                    return true;
                }
            }
            return false;
        }

        protected abstract bool PositionHasChanged();

        protected abstract Position GetCurrentPosition();

        protected virtual bool SignalIsCorrect(Position signalPosition)
        {
            if(!Framework.Inst.SignalsRulesChecking)
            {
                Framework.CallTrace("Skipping signals checking..");
                return true;
            }
            if (IsFirstSignal)
            {
                Framework.CallTrace("It`s first signal. OK");
                return true;
            }

            Framework.CallTrace("Verifing signals..");
            if (LastPosition.EntryDate.AddMinutes(8).Subtract(signalPosition.EntryDate) > new TimeSpan(0, 0, 10))
            {
                LogWithDetails("To short time between signals! Ignoring it!", LastPosition, signalPosition);
                return false;
            }

            if (LastPosition.Direction == signalPosition.Direction)
            {
                LogWithDetails("Same direction signal detected. Ignoring it!", LastPosition, signalPosition);
                return false;
            }

            return true;
        }

        protected static void LogWithDetails(string message, Position last, Position toPosition)
        {
            string m = "Last " + GetDetails(last) + "\n" + "To: " + GetDetails(toPosition) + "\n";
            Framework.CallTrace(message + "\n" + m);
            log.Warn(message + "\n" + m);
        }

        protected static string GetDetails(Position last)
        {
            string m = "pos: " + last.Size + " " + last.Direction
                        + ", date: " + last.EntryDate + ", price:" + last.EntryPoint;
            return m;
        }

    }
}