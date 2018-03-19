using System.Collections.Specialized;

namespace Ylvis.Utils.Features.AppSettings
{
    public interface IConfigurationManager
    {
        NameValueCollection AppSettings
        {
            get;
        }

        string ConnectionStrings(string name);

        T GetSection<T>(string sectionName);

        void InitForTest();
    }
}
