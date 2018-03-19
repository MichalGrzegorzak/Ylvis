using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Features.Extensions;

namespace Showoff.Core.Configuration
{
    public abstract class ConfigurationBase<C> : IConfigurationBase
    where C : class, IConfigurationBase, new()
    {
        public IConfigurationManager Configuration { get; protected set; }

        static ConfigurationBase()
        {
            Inst = new C();
        }

        protected ConfigurationBase()
        {
            Initialize(new ConfigurationManagerWrapper());
        }

        public static C Inst { get; private set; }

        /// <summary>
        /// Should be used only in test scenarios, after mocking Configuration
        /// </summary>
        public abstract void Initialize(IConfigurationManager configuration);

        protected T ReadAppSettingsEntry<T>(string key, T def = default(T)) where T : IConvertible
        {
            string item = Configuration.AppSettings[key] ?? def.IfNotDefault(x => x.ToString());
            return ConvertIfNotNull<T>(item);
        }

        private T ConvertIfNotNull<T>(object item) where T : IConvertible 
        {
            if (item == null)
                return default(T);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            return (T)tc.ConvertFrom(item);
        }

        protected List<T> ReadEnumListValues<T>(string appKey) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
            }

            var result = new List<T>();
            string item = Configuration.AppSettings[appKey];
            if (string.IsNullOrEmpty(item))
                return result;

            string[] list = item.Split(new[] { ",", " ", "|", ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in list)
            {
                result.Add(s.ParseToEnum<T>());
            }
            return result;
        }

        protected List<T> ListAllEnumValues<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("ListAllEnumValues<T> can only be called for types derived from System.Enum", "T");

            return Enum.GetValues(typeof(T)).OfType<T>().ToList();
        }
    }

    public interface IConfigurationBase
    {
        void Initialize(IConfigurationManager configuration);
    }
}
