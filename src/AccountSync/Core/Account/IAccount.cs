using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons;

namespace Core.Model.Accounts
{
    public interface IAccount
    {
        Position GetCurrentPosition();
        bool LookForNewPosition();
        void Login();
        bool ChangePositionTo(Position newPosition);
        Position Position { get; set; }
        AccountCredentials Credentials { get; set; }
        //bool TestOnly { get; set; }
    }
}
