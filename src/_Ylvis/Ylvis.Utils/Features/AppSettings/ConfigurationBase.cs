using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Ylvis.Utils.Extensions;
using Ylvis.Utils.Features.TypesParsing;

namespace Ylvis.Utils.Features.AppSettings
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
            string item = Configuration.AppSettings[key] ?? def.IfNotNull(x => x.ToString());
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

        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
            //File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(C pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings));
            //File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static C Load(string fileName = DEFAULT_FILENAME)
        {
            C t = new C();
            if (File.Exists(fileName))
                t = JsonConvert.DeserializeObject<C>(File.ReadAllText(fileName));
                //t = (new JavaScriptSerializer()).Deserialize<C>(File.ReadAllText(fileName));
            return t;
        }
    }

    public interface IConfigurationBase
    {
        void Initialize(IConfigurationManager configuration);
    }
}
