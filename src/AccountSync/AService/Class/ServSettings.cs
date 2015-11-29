using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace AService
{
    public abstract class ServSettings
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");

        public static bool GetPositionFromAccount = true;
        public static bool DispatcherValidationEnabled
        {
            set{ PositionsDispatcher.ValidationEnabled = value;}
        }
        public static bool UseFakeAccountsDetails = false;

        public static ISpiderNavig SpiderNavigation
        {
            set{ BossaSpider.Navig = value;}
        }
        public static bool SpiderOrderingEnabled
        {
            set{ BossaSpider.EnableOrdering = value;}
        }

        public static void Configure4Test()
        {
            //GetPositionFromAccount = true;
            Is4Live = false;
            DispatcherValidationEnabled = false;
            SpiderOrderingEnabled = false;
            UseFakeAccountsDetails = true;
            SpiderNavigation = new TestBossaNavig();

            log.Info("Configure4Test");
        }

        public static bool Is4Live = false;

        public static void Configure4Live()
        {
            //GetPositionFromAccount = true;
            Is4Live = true;
            DispatcherValidationEnabled = false;
            SpiderOrderingEnabled = true;
            UseFakeAccountsDetails = false;
            SpiderNavigation = new BossaNavig();

            log.Info("Configure4Live");
        }

        //private void Init(params string[] args)
        //{
        //    if(args != null && args.Length > 0)
        //    {
        //        if(args[0] == "proxy")
        //        {
                    
        //        }
        //    }
        //}

    }
}
