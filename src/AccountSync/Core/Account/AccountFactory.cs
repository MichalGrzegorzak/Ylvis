using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons;
using Core.Accounts;

namespace Core.Accounts
{
    public abstract class AccountFactory
    {
        public static AccountBase Create(ChooseAccount choice)
        {
            AccountNavigation navig = new AccountNavigation();
            return Create(choice, null, navig);
        }

        public static AccountBase Create(ChooseAccount choice, AccountCredentials credit, AccountNavigation navig)
        {
            AccountBase acc = null;
            switch (choice)
            {
                case ChooseAccount.Main:
                    {
                        credit = Framework.Inst.CredentialsList[0];
                        credit.AccountId = 1;
                        acc = new BossaAccount(credit, navig);
                        break;
                    }
                case ChooseAccount.Account1:
                    {
                        credit = Framework.Inst.CredentialsList[1];
                        credit.AccountId = 2;
                        acc = new BossaAccount(credit, navig);
                        break;
                    }
            //    case ChooseAccount.Test:
            //        {
            //            if(credit == null)
            //                credit = new Credentials();
                        
            //            acc = new BossaAccount(credit, navig);
            //            break;
            //        }
            }
            
            return acc;
        }
    }

    public enum ChooseAccount
    {
        Main,
        Account1
        //,Test
    }
}
