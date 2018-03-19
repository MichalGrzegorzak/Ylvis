using System;
using Commons;
using WatiN.Core;

namespace Core.Accounts
{
    public abstract class AccountBase
    {
        public IE Ie
        {
            get
            {
                return Framework.Inst.browser;
            }
            set
            {
                Framework.Inst.browser = value;
            }
        }

        private Position _position;
        public Position Position
        {
            get
            {
                if (_position == null)
                    _position = GetCurrentPosition();

                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public AccountCredentials Credentials { get; set; }
        public AccountNavigation Links { get; set; }

        public AccountBase(AccountCredentials cred, AccountNavigation navig) 
        {
            if (cred == null)
                throw new ArgumentNullException("Credentials must be passed!");

            if (navig == null)
                throw new ArgumentNullException("AccountNavigation must be passed!");

            //LastPosition = new Position(0, 0, DateTime.Now);
            Credentials = cred;
            this.Links = navig;
        }

        public abstract Position GetCurrentPosition();
        public abstract bool LookForNewPosition();
        public abstract void Login();
        public abstract void Logout();
        public abstract void ChangeAccount();
        public abstract bool ChangePositionTo(Position newPosition);

        public void Clear()
        {
            Ie.ClearCache();
            Ie.ClearCookies();
        }

        public void Reopen()
        {
            Ie.Reopen();
        }
    }
}