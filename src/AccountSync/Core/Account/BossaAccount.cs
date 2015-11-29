using System;
using Commons;
using Core;
using Core.Model.Accounts;
using WatiN.Core;
using Commons.Extensions;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Exceptions;

namespace Core.Accounts
{
    public class BossaAccount : AccountBase, IAccount
    {
        public BossaAccount(AccountCredentials cred, AccountNavigation navig) : base(cred, navig)
        { }

        public override Position GetCurrentPosition()
        {
            Framework.CallTrace("Getting current position..");

            int value = 0;
            Ie.GoTo(Links.Position);

            if (Ie.Tables.Count < 4)
            {
                string source = Ie.Html;
                throw new Exception("not logged in!");
            }

            if (Ie.Tables[4].TableRows.Count > 2)
            {
                foreach (TableRow tr in Ie.Tables[4].TableRows)
                {
                    if (tr.TableCells.Count > 1)
                    {
                        if (tr.TableCells[0].Text.StartsWith("FW20"))
                        {
                            value = tr.TableCells[2].Text.Parse<int>();
                        }
                    }
                }
            }
            
            Position pos = new Position(0, value, DateTime.Now);
            Position = pos;

            Framework.CallTrace("Current position: " + pos.ToString());
            return pos;
        }

        public override bool LookForNewPosition()
        {
            Framework.CallTrace("Looking for new position..");

            bool result = false;
            Ie.GoTo(Links.Check4Changes);

            Frame fra = null;
            try
            {
                fra = Ie.Frame(Find.ByName("outlook1"));
            }
            catch (FrameNotFoundException ex)
            {
                Framework.CallTrace("RELOGING -> FrameNotFoundException");
                Login();
                fra = Ie.Frame(Find.ByName("outlook1"));
            }

            if (fra.Tables[0].TableRows.Count <= 1)
                return false;

            string operacja = fra.Tables[0].TableRows[1].TableCells[3].Text;
            int ilosc = fra.Tables[0].TableRows[1].TableCells[4].Text.Parse<int>();
            if (operacja == "S")
                ilosc = ilosc*-1;

            Position pos = new Position(0, ilosc, DateTime.Now);
            if (!pos.IsEqual(Position)) //detect position change
            {
                Position = pos;
                result = true;
                Framework.CallTrace("New position detected -> " + pos.ToString());
            }
            return result;
        }

        public override void ChangeAccount()
        {
            Logout();
            Login();
        }

        public override void Logout()
        {
            //var confirmDialogHandler = new ConfirmDialogHandler();
            //Ie.DialogWatcher.Add(confirmDialogHandler);
            //////Ie.Element("buttonId").ClickNoWait();
            //confirmDialogHandler.WaitUntilExists();
            //confirmDialogHandler.OKButton.Click();
            //Ie.WaitForComplete();
            //Ie.DialogWatcher.RemoveAll(confirmDialogHandler);         

            Ie.GoToNoWait("https://www.bossa.pl/servlet/logout");
            Ie.ClearCache();
            Ie.ClearCookies();
            Framework.CallTrace("Logout & clear...");
        }

        private int _tryToLog = 3;

        public override void Login()
        {
            Framework.CallTrace("Loging to " + Credentials.Login);

            try
            {
                Ie.GoTo(Links.Login);
                Frame fra = Ie.Frame(Find.ByName("vibmain"));
                fra.TextField(Find.ByName("user")).TypeText(Credentials.Login);
                fra.TextField(Find.ByName("pin")).TypeText(Credentials.Pass);
                fra.Button(Find.ByName("ac")).Click();
            }
            catch (FrameNotFoundException ex)
            {
                if (_tryToLog > 0)
                {
                    Framework.CallTrace("Cannot logging, renewing! Tryies:" + _tryToLog);
                    _tryToLog = _tryToLog--;
                    Login();
                }
                else
                    throw;
            }
            
            Framework.CallTrace("Loging successfull.");
        }

        public override bool ChangePositionTo(Position newPosition)
        {
            Framework.CallTrace("Change position called to: " + newPosition.ToString());
            Ie.GoTo(Links.NewOrder);

            string s = Ie.Html;
            Ie.SelectList(Find.ByName("SecCode")).SelectByValue("PL0GF0000281"); //fw20
            Ie.SelectList(Find.ByName("OrdType")).SelectByValue(newPosition.Direction); //order


            Ie.TextField(Find.ByName("OrdQty")).TypeText(newPosition.Size.ToString()); //size of position
            Ie.SelectList(Find.ByName("OrdLimitType")).SelectByValue("P"); //P = PKC
            Ie.WaitForComplete(1);
            
            Ie.Button(Find.ByName("bc")).Click(); //przelicz

            if (Framework.Inst.OrderingEnabled)
            {
                Framework.CallTrace("Executing order...");
                var confirmDialogHandler = new ConfirmDialogHandler();
                Ie.DialogWatcher.Add(confirmDialogHandler);

                Ie.Button(Find.ByName("bs")).ClickNoWait(); //ORDER !!!
                
                confirmDialogHandler.WaitUntilExists();
                confirmDialogHandler.OKButton.Click(); //CONFIRM
                Ie.WaitForComplete();
                Ie.DialogWatcher.RemoveAll(confirmDialogHandler);   
            }

            Position = newPosition;
            Framework.CallTrace("Change position OK. CurrentPos: " + Position.ToString());
            return true;
        }
    }
}