using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showoff.Core.Configuration
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings
        {
            get;
        }

        string ConnectionStrings(string name);

        T GetSection<T>(string sectionName);
    }
}
