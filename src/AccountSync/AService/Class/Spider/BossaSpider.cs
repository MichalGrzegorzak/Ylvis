using System;
using AServiceContract;
using Core;
using log4net;
using WatiN.Core;
using Commons.Extensions;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Exceptions;

namespace AService
{
    public class BossaSpider : IDisposable
    {
        private static readonly ILog logSpider = LogManager.GetLogger("Spider");
        private static readonly ILog logGuilog = LogManager.GetLogger("GuiLogger");

        //public static Uri UrlLogin = new Uri("https://www.bossa.pl");
        //public static Uri UrlLogout = new Uri("https://www.bossa.pl/servlet/logout");
        //public static Uri UrlPosition = new Uri("https://www.bossa.pl/servlet/wyciagfw");
        //public static Uri UrlCheck4Changes = new Uri("https://www.bossa.pl/0/outlook.html");
        //public static Uri UrlNewOrder = new Uri("https://www.bossa.pl/servlet/zlec?FormID=P2");

        public static ISpiderNavig Navig = new BossaNavig();
        //new BossaNavig();
        
        private static IE _ie;
        public static IE Ie
        {
            get
            {
                if(_ie == null)
                    _ie = new IE();

                return _ie;
            }
            set
            {
                _ie = value;
            }
        }

        public static bool EnableOrdering = false;

        private Credentials cred = null;
        private Account acc = null;

        public BossaSpider()
        {
            _ie = new IE();
            //navig = new BossaNavig();
        }

        private static void CallTrace(string message)
        {
            logSpider.Info(message);
        }

        public void Login(Account acc)
        {
            this.cred = acc.cred;
            this.acc = acc;
            CallTrace("Loging to " + cred.Login);

            Ie.GoTo(Navig.UrlLogin);
            Frame fra = Ie.Frame(Find.ByName("vibmain"));
            fra.TextField(Find.ByName("user")).TypeText(cred.Login);
            fra.TextField(Find.ByName("pin")).TypeText(cred.Pass);
            fra.Button(Find.ByName("ac")).Click();

            CallTrace("Loging successfull.");
        }

        public void Logout()
        {
            CallTrace("Login out & clear...");
            Ie.GoToNoWait(Navig.UrlLogout);
            Ie.ClearCache();
            Ie.ClearCookies();
        }

        public Position GetCurrentPosition()
        {
            CallTrace("Getting current position..");

            int value = 0;
            Ie.GoTo(Navig.UrlPosition);

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

            Position pos = new Position(value);
            CallTrace("Current position: " + pos.ToString());

            return pos;
        }

        public bool ChangePositionTo(Position newPosition)
        {
            CallTrace("Change position called to: " + newPosition.ToString());
            Ie.GoTo(Navig.UrlNewOrder);

            string s = Ie.Html;
            //PL0GF0000281 - U09
            //PL0GF0000281 - Z09
            //{"No item was found in the selectlist matching constraint: Attribute 'value' equals 'PL0GF0000281' ignoring case"}
            try
            {
                Ie.SelectList(Find.ByName("SecCode")).SelectByValue("PL0GF0000281"); //fw20
                Ie.SelectList(Find.ByName("OrdType")).SelectByValue(newPosition.Direct); //order

                Ie.TextField(Find.ByName("OrdQty")).TypeText(newPosition.Size.ToString()); //size of position
                Ie.SelectList(Find.ByName("OrdLimitType")).SelectByValue("P"); //P = PKC
                Ie.WaitForComplete(1);

                try
                {
                    Ie.Button(Find.ByName("bc")).Click(); //przelicz 
                }
                catch(ElementDisabledException)
                {
                    //swallow ex, only for Live testing, when after session
                }
            }
            catch (Exception ex)
            {
                string mess = "Failed to place order on account: " + acc.Id + "\n";
                Exception excc = new Exception(mess, ex);
                logSpider.Fatal(excc);
                logGuilog.Fatal(mess + "Most likely contract not added to list!");
                return false;
            }

            if (EnableOrdering)
            {
                try
                {
                    CallTrace("Executing order...");
                    var confirmDialogHandler = new ConfirmDialogHandler();
                    Ie.DialogWatcher.Add(confirmDialogHandler);

                    try
                    {
                        Ie.Button(Find.ByName("bs")).ClickNoWait(); //ORDER !!!
                    }
                    catch (ElementDisabledException)
                    {
                        //swallow ex, only for Live testing, when after session
                    }
                    
                    confirmDialogHandler.WaitUntilExists();
                    confirmDialogHandler.OKButton.Click(); //CONFIRM
                    Ie.WaitForComplete();
                    Ie.DialogWatcher.RemoveAll(confirmDialogHandler); 
                }
                catch (Exception ex)
                {
                    string mess = "Failed to execute order on account: " + acc.Id + "\n";
                    Exception excc = new Exception(mess, ex);
                    logSpider.Fatal(excc);
                    logGuilog.Fatal(mess);
                    return false;
                }
            }

            CallTrace("Change position OK. CurrentPos: " + newPosition.ToString());
            return true;
        }

        //public bool LookForNewPosition()
        //{
        //    CallTrace("Looking for new position..");

        //    bool result = false;
        //    Ie.GoTo(UrlCheck4Changes);

        //    Frame fra = null;
        //    try
        //    {
        //        fra = Ie.Frame(Find.ByName("outlook1"));
        //    }
        //    catch (FrameNotFoundException ex)
        //    {
        //        CallTrace("RELOGING -> FrameNotFoundException");
        //        //Logme();
        //        fra = Ie.Frame(Find.ByName("outlook1"));
        //    }

        //    if (fra.Tables[0].TableRows.Count <= 1)
        //        return false;

        //    string operacja = fra.Tables[0].TableRows[1].TableCells[3].Text;
        //    int ilosc = fra.Tables[0].TableRows[1].TableCells[4].Text.Parse<int>();
        //    if (operacja == "S")
        //        ilosc = ilosc*-1;

        //    Position pos = new Position(0, ilosc, DateTime.Now);
        //    if (!pos.IsEqual(Position)) //detect position change
        //    {
        //        Position = pos;
        //        result = true;
        //        CallTrace("New position detected -> " + pos.ToString());
        //    }
        //    return result;
        //}

        //public override void ChangeAccount()
        //{
        //    Logout();
        //    Login();
        //}

        #region IDisposable Members

        public void Dispose()
        {
            _ie.Close();
            _ie = null;
        }

        #endregion
    }
}