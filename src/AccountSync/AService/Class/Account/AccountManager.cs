using System;
using System.Collections.Generic;
using AServiceContract;
using log4net;

namespace AService
{
    public delegate void AccountUpdated(Account account);

    public class AccountManager
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");
        public Account Main;
        public List<Account> AccountsToSync = new List<Account>();
        public static PositionsDispatcher dispatcher = new PositionsDispatcher();

        public event AccountUpdated AccountUpdatedHandler;

        #region GetAccountsDetails

        private  List<Account> GetAccountsDetails(IList<Credentials> credentials)
        {
            List<Account> result = new List<Account>();
            
            if(ServSettings.UseFakeAccountsDetails)
            {
                Account acc0 = new Account(credentials[0]);
                acc0.Pos = new Position(-2);
                result.Add(acc0);
                Account acc1 = new Account(credentials[1]);
                acc1.Pos = new Position(-1);
                result.Add(acc1);
            }
            else
            {
                using (BossaSpider spider = new BossaSpider())
                {
                    foreach (Credentials cred in credentials)
                    {
                        Account acc = new Account(cred);
                        spider.Login(acc);
                        acc.Pos = spider.GetCurrentPosition();
                        spider.Logout();
                        result.Add(acc);
                    }
                }
            }

            return result;
        }

        public void InitializeAccountsDetails(IList<Credentials> credentials)
        {
            List<Account> accountsList = GetAccountsDetails(credentials);

            int i = 0;
            foreach (Account acc in accountsList)
            {
                if (i == 0)
                {
                    Main = acc;
                    dispatcher.AddPosition(acc.Pos);
                }
                else
                    AccountsToSync.Add(acc);

                log.Info("Account " + acc.Id + " state: " + acc.Pos.Size + acc.Pos.Direct);
                i++;
            }
        }

        #endregion

        public void FireAccountUpdated(Account account)
        {
            if (AccountUpdatedHandler != null)
            {
                AccountUpdatedHandler.Invoke(account);
            }
        }

        public void RefreshAllAccounts()
        {
            using (BossaSpider spider = new BossaSpider())
            {
                foreach (Account acc in AccountsToSync)
                {
                    spider.Login(acc);
                    Position currect = spider.GetCurrentPosition();
                    if (acc.Pos.Direct != currect.Direct)
                        throw new Exception("What the f...");

                    acc.Pos = currect;
                    //mozna by sprawdzic czy sie wykonalo !!
                    //currect = spider.GetCurrentPosition(); 
                    spider.Logout();

                    FireAccountUpdated(acc);
                }
            }
        }

        public void UpdateAllAccounts(Position p)
        {
            bool res = dispatcher.AddIfValid(p);
            if(!res)
                return;
            
            Position org = new Position(p.Size, p.Direct, p.Price, p.Date);
            using (BossaSpider spider = new BossaSpider())
            {
                foreach (Account acc in AccountsToSync)
                {
                    //adjust position to each account
                    p = AdjustPosition4Account(acc, org);
                    
                    spider.Login(acc);
                    bool compleated = spider.ChangePositionTo(p);
                    //mozna by sprawdzic czy sie wykonalo !!
                    //currect = spider.GetCurrention Position(); 
                    spider.Logout();

                    if(compleated)
                    {
                        acc.Pos = org;
                        FireAccountUpdated(acc); 
                    }
                    
                }
            }
        }

        private Position AdjustPosition4Account(Account acc, Position newPos)
        {
            Position p = new Position(newPos.Size, newPos.Direct, newPos.Price, newPos.Date);
            if(acc.Pos.Size == 0)
                return p;

            p.Size = p.Size*2;

            return p;
        }

        public Position GetMainAccountPosition()
        {
            Position position;
            using (BossaSpider spider = new BossaSpider())
            {
                spider.Login(Main);
                position = spider.GetCurrentPosition();
                spider.Logout();
            }
            
            Main.Pos = position;
            //FireAccountUpdated(Main);

            return position;
        }
    }
}
