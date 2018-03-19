using System.Collections.Specialized;
using System.Configuration;

namespace Ylvis.Utils.Features.AppSettings
{
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        private NameValueCollection _appSettings;
        private ConnectionStringSettingsCollection _connectionString;

        public void InitForTest()
        {
            _appSettings = new NameValueCollection();
            _connectionString = new ConnectionStringSettingsCollection();
        }

        public NameValueCollection AppSettings
        {
            get
            {
                return _appSettings ?? ConfigurationManager.AppSettings;
            }
        }

        public string ConnectionStrings(string name)
        {
            var conn = _connectionString ?? ConfigurationManager.ConnectionStrings;
            return conn[name].ConnectionString;
        }

        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}
