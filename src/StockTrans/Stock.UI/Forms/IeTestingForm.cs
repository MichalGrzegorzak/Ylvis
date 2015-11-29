using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using Commons.Extensions;
using csExWB;
using IfacesEnumsStructsClasses;
using Stock.Core;
using Stock.Core.Controller;
using Stock.Core.Domain;

namespace Stock.Forms
{
    public partial class IeTestingForm : Form
    {
        public bool Start = true;
        
        public IeTestingForm()
        {
            InitializeComponent();
        }

        private MbankSettings _settings = null;

        public void Go(MbankSettings settings)
        {
            _settings = settings;
            cEXWB1.DocumentComplete += new csExWB.DocumentCompleteEventHandler(cEXWB1_DocumentComplete);
            //cEXWB1.Navigate("https://www.mbank.com.pl");
            cEXWB1.Navigate("http://www.parkiet.com/temat/63.html");
            //cEXWB1.Navigate("http://www.parkiet.com/notowania/ciagle.jsp");
            
        }

        private mBankStatus _status = mBankStatus.Login;
        private int _aktualnaTranzakcja = 0;
        private int _transacOnPage = 0;
        private List<Transaction> _transFound = new List<Transaction>();

        private void button1_Click(object sender, EventArgs e)
        {
            ////mshtml.HTMLDocument
            //int i = browser.Document.Forms.Count;
            //HTMLDocument doc = browser.Document as HTMLDocument;
            ////doc.B
        }

        private void ExtractCompanies(IHTMLDocument2 doc)
        {
            string text = doc.body.innerText;
            string html = doc.body.innerHTML;
        }

        

        void cEXWB1_DocumentComplete(object sender, csExWB.DocumentCompleteEventArgs e)
        {
            cEXWB browser = (cEXWB)sender;
            bool ok = false;

            IHTMLDocument2 doc22 = browser.GetActiveDocument();
            ExtractCompanies(doc22);

            switch (_status)
            {
                case mBankStatus.Login:
                    {
                        ok = browser.AutomationTask_PerformAuthentication("customer", "password",
                            _settings.UserId.ToString(), _settings.Password, 
                            false, true);
                        _status = mBankStatus.MainScreen;
                        _settings = null;
                        break;
                    }
                case mBankStatus.MainScreen:
                    {
                        if (browser.AutomationTask_PerformClickLink(Names.PapieryWartLink))
                            _status = mBankStatus.PapieryOff;
                        break;
                    }
                case mBankStatus.PapieryOff:
                    {
                        IHTMLDocument2 doc = GetFunctionFrame(browser);
                        IHTMLElementCollection elements = (IHTMLElementCollection)doc.links;
                        foreach (IHTMLElement element in elements)
                        {
                            if (element.innerText != null)
                                if (element.innerText == "Historia transakcji")
                                {
                                    _status = mBankStatus.HistoriaTransOff;
                                    element.click();
                                }
                        }
                        break;
                    }
                case mBankStatus.HistoriaTransOff:
                    {
                        IHTMLDocument2 doc = GetFunctionFrame(browser);
                        ok = browser.AutomationTask_PerformEnterData("daysCount", "3");
                        if (browser.AutomationTask_PerformSelectRadio2("dateType", "days"))
                        {
                            _status = mBankStatus.ListaTrans;
                            _aktualnaTranzakcja = 0;
                            browser.GetElementsByNameOrId("Submit")[0].click();
                        }
                        break;
                    }
                case mBankStatus.ListaTrans:
                    {
                        int znalezionaTransakcja = 0;
                        IHTMLDocument2 doc = GetFunctionFrame(browser);
                        IHTMLElementCollection coll = (IHTMLElementCollection) doc.links;

                        if (AllTransactionsProcessed(coll))
                            return;

                        foreach (IHTMLElement el in coll)
                        {
                            if(el.title == "Zobacz szczegóły transakcji")
                            {
                                if (znalezionaTransakcja == _aktualnaTranzakcja)
                                {
                                    _aktualnaTranzakcja++;
                                    _status = mBankStatus.TransZlisty;
                                    el.click();
                                    break;
                                }
                                znalezionaTransakcja++;
                            }
                        }
                        break;
                    }
                case mBankStatus.TransZlisty:
                    {
                        IHTMLDocument2 doc = GetFunctionFrame(browser);
                        Transaction t = ProcessTransaction(doc.body.innerText);
                        _transFound.Add(t);
                        
                        _status = mBankStatus.ListaTrans;
                        browser.GetElementsByNameOrId("Submit")[0].click(); //powrot
                        break;
                    }
                case mBankStatus.KoniecListy:
                    {
                        _transFound = new List<Transaction>();
                        _status = mBankStatus.End;
                        break;
                    }
                case mBankStatus.End:
                    {
                        break;
                    }
            }

        }

        private bool AllTransactionsProcessed(IHTMLElementCollection coll)
        {
            if (_transacOnPage == 0)
            {
                foreach (IHTMLElement el in coll) //count how many transactions on page
                {
                    if (el.title == "Zobacz szczegóły transakcji")
                    {
                        _transacOnPage++;
                    }
                }
            }
            else if (_aktualnaTranzakcja == _transacOnPage) //wyjscie z petli
            {
                _status = mBankStatus.KoniecListy;
                return true;
            }
            
            return false;
        }

        private Transaction ProcessTransaction(string source)
        {
            DateTime dataTrans =    GetElementText("ctl21_ctl02_DetailsItem_0_3_0").Parse<DateTime>();
            DateTime dataZlecenia = GetElementText("ctl21_ctl03_DetailsItem_1_3_0").Parse<DateTime>();
            DateTime godzinaTrans = GetElementText("ctl21_ctl04_DetailsItem_2_3_0").Parse<DateTime>();
            Int32 nrZlecenia =      GetElementText("ctl21_ctl05_DetailsItem_3_3_0").Parse<Int32>();
            string nazwaPapieru =   GetElementText("ctl21_ctl06_DetailsItem_4_3_0");
            string kodPapieru =     GetElementText("ctl21_ctl07_DetailsItem_5_3_0");
            string rodzajTrans =    GetElementText("ctl21_ctl08_DetailsItem_6_3_0");
            Int32 liczWykon =       GetElementText("ctl21_ctl09_DetailsItem_7_3_0").Parse<Int32>();

            source = source.Replace("\r", "");
            string[] ss = source.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
            decimal kursTrans = GetValueFromInsideOf("Kurs transakcji", ss, "PLN").Parse<decimal>();
            decimal prowizja = GetValueFromInsideOf("Prowizja", ss, "PLN").Parse<decimal>();
            decimal wartTrans = GetValueFromInsideOf("Wartość transakcji", ss, "PLN").Parse<decimal>();
            DateTime full = dataTrans.Add(godzinaTrans.TimeOfDay);

            //need to have unique name
            string id = nazwaPapieru.Substring(0, 3);

            Transaction t = new Transaction();
            t.Amount = liczWykon;
            t.Date = full;
            t.Price = kursTrans;
            t.Fee = prowizja;
            t.GroupId = 0;
            t.Company = new Company(id);
            t.Buy = rodzajTrans == "KUPNO" ? true : false;

            return t;
            //TransactionController controller = new TransactionController();
            //controller.AddNewTransaction
            //    (full, "MSZ", , kursTrans, true, prowizja, 0);
        }

        public string GetValueFromInsideOf(string lookFor, string[] lookIn, params string[] toRemove)
        {
            string result = null;
            
            foreach (string word in lookIn)
            {
                if(word.StartsWith(lookFor))
                {
                    result = word.Replace(lookFor, "");
                    
                    foreach (string r in toRemove) //remove additional
                    {
                        result = result.Replace(r, "").Trim();
                    }
                    return result;
                }
            }

            return null;
        }

        public string GetElementText(string nameOrId)
        {
            string text = cEXWB1.GetElementsByNameOrId(nameOrId)[0].innerText;
            return text;
        }

        #region GetFrame Helpers
        public static IHTMLDocument2 GetFunctionFrame(cEXWB browser)
        {
            return GetDocumentFromFrame(browser, "FunctionFrame");
        }

        public static IHTMLDocument2 GetNavigationFrame(cEXWB browser)
        {
            return GetDocumentFromFrame(browser, "Navigation");
        }

        public static IHTMLDocument2 GetDocumentFromFrame(cEXWB browser, string frameName)
        {
            List<IWebBrowser2> frames = browser.GetFrames();
            foreach (IWebBrowser2 wb in frames)
            {
                IHTMLFrameBase elem = (IHTMLFrameBase)wb;
                if ((!string.IsNullOrEmpty(elem.name))
                    && (elem.name == frameName))
                {
                    IHTMLDocument2 doc = (IHTMLDocument2)wb.Document;
                    //string body = doc2.body.innerHTML;
                    return doc;
                }

            }
            return null;
        }
        #endregion

        #region GetElementsByNameOrId
        /// <summary>
        /// Attempts to return a List of IHTMLElements with the given Name or Id
        /// If document is frameset then all frames are searched
        /// </summary>
        /// <param name="NameOrId">Name or Id of the element</param>
        /// <returns></returns>
        public static List<IHTMLElement> GetElementsByNameOrId(cEXWB browser, string NameOrId)
        {
            List<IHTMLElement> elemCols = new List<IHTMLElement>();

            if ((browser == null) ||
                string.IsNullOrEmpty(NameOrId))
                return elemCols;

            IHTMLDocument2 doc2 = browser.WebbrowserObject.Document as IHTMLDocument2;
            if (doc2 == null)
                return elemCols;

            IHTMLElementCollection col = null;
            string elemname = string.Empty;
            if (browser.FramesCount() > 0)
            {
                List<IWebBrowser2> frames = browser.GetFrames();
                if (frames == null)
                    return elemCols;
                IHTMLDocument2 framedoc = null;

                foreach (IWebBrowser2 wb in frames)
                {
                    if (wb == null)
                        continue;
                    framedoc = wb.Document as IHTMLDocument2;
                    if (framedoc == null)
                        continue;
                    col = framedoc.all as IHTMLElementCollection;
                    if (col == null)
                        continue;
                    foreach (IHTMLElement elem in col)
                    {
                        if (elem != null)
                        {
                            elemname = elem.getAttribute("name", 0) as string;
                            if ((elem.id == NameOrId) ||
                                (elemname == NameOrId))
                            {
                                elemCols.Add(elem);
                            }
                        }
                    }
                }
            }
            else
            {
                col = doc2.all as IHTMLElementCollection;
                if (col == null)
                    return elemCols;
                foreach (IHTMLElement elem in col)
                {
                    if (elem != null)
                    {
                        elemname = elem.getAttribute("name", 0) as string;
                        if ((elem.id == NameOrId) ||
                            (elemname == NameOrId))
                        {
                            elemCols.Add(elem);
                        }
                    }
                }
            }

            return elemCols;
        }
        #endregion
    }       

    public enum mBankStatus
    {
        Login = 0,
        MainScreen = 1,
        PapieryOff = 2,
        HistoriaTransOff = 3,
        ListaTrans = 4,
        TransZlisty = 5,
        KoniecListy = 6,
        PapieryOnL = 9,
        End = 100
    }

    public static class Names
    {
        public static string PapieryWartLink = "ctl19_ctl08_MLink_5_1";
        public static string RachunekEkonto = "ctl19_ctl04_MLink_2_1";
    }
}


//Decimal kursTrans = GetElementText("ctl21_ctl10_MLabel_8_1").Parse<Decimal>();
//Decimal prowizja =      GetElementText("ctl21_ctl11_DetailsItem_9_3_0").Parse<Decimal>();
//Decimal wartTrans  =    GetElementText("ctl21_ctl12_DetailsItem_10_3_0").Parse<Decimal>();
//Int32 nrDysp =      GetElementText("ctl21_ctl04_DetailsItem_2_3_0").Parse<Int32>();
//DateTime dtSesji =  GetElementText("ctl21_ctl09_DetailsItem_7_3_0").Parse<DateTime>(); 
//DateTime dtWazn =   GetElementText("ctl21_ctl10_DetailsItem_8_3_0").Parse<DateTime>(); 
//string status =     GetElementText("ctl21_ctl11_DetailsItem_9_3_0");
//Int32 liczZlecona = GetElementText("ctl21_ctl12_DetailsItem_10_3_0").Parse<Int32>(); 
//Int32 liczPoRed =   GetElementText("ctl21_ctl13_DetailsItem_11_3_0").Parse<Int32>(); 
