using System;
using System.Web;
using Elmah;

namespace Showoff.Notices.BusinessLogic.Logging
{
    public static class ElmahExtension
    {
        public const string ElmahApplicationName = "FNC_Notices";
        public static string ConnectionString = null;

        public static void LogToElmah(this Exception ex)
        {
            if (ConnectionString == null)
                NormalElmahLog(ex);
            else
                ErrorLogForPredefinedConnectionString(ex);
        }

        /// <summary>
        /// Prepared for integration tests
        /// </summary>
        private static void ErrorLogForPredefinedConnectionString(Exception ex)
        {
            var log = new SqlErrorLog(ConnectionString);
            log.ApplicationName = ElmahApplicationName;
            log.Log(new Error(ex));
        }

        private static void NormalElmahLog(Exception ex)
        {
            if (HttpContext.Current != null)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            else
            {
                if (httpApplication == null) 
                    InitNoContext();

                ErrorSignal.Get(httpApplication).Raise(ex);
            }
        }

        private static void InitNoContext()
        {
            httpApplication = new HttpApplication();
            errorFilter.Init(httpApplication);

            (ErrorEmail as IHttpModule).Init(httpApplication);
            errorFilter.HookFiltering(ErrorEmail);

            (ErrorLog as IHttpModule).Init(httpApplication);
            errorFilter.HookFiltering(ErrorLog);

            (ErrorTweet as IHttpModule).Init(httpApplication);
            errorFilter.HookFiltering(ErrorTweet);
        }

        private static HttpApplication httpApplication = null;
        private static ErrorFilterConsole errorFilter = new ErrorFilterConsole();

        public static ErrorMailModule ErrorEmail = new ErrorMailModule();
        public static ErrorLogModule ErrorLog = new ErrorLogModule();
        public static ErrorTweetModule ErrorTweet = new ErrorTweetModule();

            

        private class ErrorFilterConsole : ErrorFilterModule
        {
            public void HookFiltering(IExceptionFiltering module)
            {
                module.Filtering += new ExceptionFilterEventHandler(base.OnErrorModuleFiltering);
            }
        }
    }
}
