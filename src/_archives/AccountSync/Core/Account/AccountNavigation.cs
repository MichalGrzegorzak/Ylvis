using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Accounts
{
    public class AccountNavigation
    {
        public Uri Login = new Uri("https://www.bossa.pl");
        public Uri Position = new Uri("https://www.bossa.pl/servlet/wyciagfw");
        public Uri Check4Changes = new Uri("https://www.bossa.pl/0/outlook.html");
        public Uri NewOrder = new Uri("https://www.bossa.pl/servlet/zlec?FormID=P2");

        public Uri StartFrom = new Uri("https://www.bossa.pl");
    }
}
