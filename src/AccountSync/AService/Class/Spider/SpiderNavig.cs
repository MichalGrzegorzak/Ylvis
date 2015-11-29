using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AService
{
    public interface ISpiderNavig
    {
        Uri UrlLogin { get; set;}
        Uri UrlLogout { get; set; }
        Uri UrlPosition { get; set; }
        Uri UrlCheck4Changes { get; set; }
        Uri UrlNewOrder { get; set; }
    }

    public class NavigBase : ISpiderNavig
    {
        protected Uri _UrlLogin = new Uri("https://www.bossa.pl");
        protected Uri _UrlLogout = new Uri("https://www.bossa.pl/servlet/logout");
        protected Uri _UrlPosition = new Uri("https://www.bossa.pl/servlet/wyciagfw");
        protected Uri _UrlCheck4Changes = new Uri("https://www.bossa.pl/0/outlook.html");
        protected Uri _UrlNewOrder = new Uri("https://www.bossa.pl/servlet/zlec?FormID=P2");

        public Uri UrlLogin
        {
            get { return _UrlLogin; }
            set { _UrlLogin = value; }
        }

        public Uri UrlLogout
        {
            get { return _UrlLogout; }
            set { _UrlLogout = value; }
        }

        public Uri UrlPosition
        {
            get { return _UrlPosition; }
            set { _UrlPosition = value; }
        }

        public Uri UrlCheck4Changes
        {
            get { return _UrlCheck4Changes; }
            set { _UrlCheck4Changes = value; }
        }

        public Uri UrlNewOrder
        {
            get { return _UrlNewOrder; }
            set { _UrlNewOrder = value; }
        }
    }

    public class BossaNavig : NavigBase
    {
        public BossaNavig()
        {
         _UrlLogin = new Uri("https://www.bossa.pl");
         _UrlLogout = new Uri("https://www.bossa.pl/servlet/logout");
         _UrlPosition = new Uri("https://www.bossa.pl/servlet/wyciagfw");
         _UrlCheck4Changes = new Uri("https://www.bossa.pl/0/outlook.html");
         _UrlNewOrder = new Uri("https://www.bossa.pl/servlet/zlec?FormID=P2");    
        }
        
    }

    public class TestBossaNavig : NavigBase
    {
        public TestBossaNavig()
        {
            _UrlLogin = new Uri(HtmlTestBaseUri, "Main1.html");
            _UrlLogout = new Uri("https://www.bossa.pl/servlet/logout");
            _UrlPosition = new Uri(HtmlTestBaseUri, "CurrentPosition.html");
            _UrlCheck4Changes = new Uri("https://www.bossa.pl/0/outlook.html");
            _UrlNewOrder = new Uri(HtmlTestBaseUri, "NewOrder.html"); 
        }

        private static Uri _htmlTestBaseUri;
        public static Uri HtmlTestBaseUri
        {
            get
            {
                if (_htmlTestBaseUri == null)
                {
                    _htmlTestBaseUri = new Uri(GetHtmlTestFilesLocation());
                }
                return _htmlTestBaseUri;
            }
        }
        private static string GetHtmlTestFilesLocation()
        {
            var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            // Search for the html directory in the current domains base directory
            // Valid when executing WatiN UnitTests in a deployed situation. 
            var htmlTestFilesLocation = baseDirectory.FullName + @"html\Bossa\";

            if (!Directory.Exists(htmlTestFilesLocation))
            {
                // If html directory not found, search one dir up in the directory tree
                // Valid when executing WatiN UnitTests from within Visual Studio
                htmlTestFilesLocation = baseDirectory.Parent.FullName + @"html\Bossa\";
            }

            return htmlTestFilesLocation;
        }
    }

}
