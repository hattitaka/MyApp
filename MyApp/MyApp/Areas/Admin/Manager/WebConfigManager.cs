using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace MyApp.Areas.Admin.Manager
{
    public class WebConfigManager
    {
        private static WebConfigManager _webConfig;

        private static object _lockObject = new object();

        public readonly WebConfigSetting setting = new WebConfigSetting();

        private WebConfigManager()
        {
            Dictionary<string, string> KeyValues = WebConfigurationManager.AppSettings.AllKeys
                .ToDictionary(key => key, keyValue => WebConfigurationManager.AppSettings[keyValue]);

            PropertyInfo[] propertys = setting.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                var value = string.Empty;
                if (KeyValues.TryGetValue(property.Name, out value))
                {
                    property.SetValue(setting, value);
                }
            }
        }

        public static WebConfigManager GetInstance()
        {
            if (_webConfig == null)
            {
                lock (_lockObject)
                {
                    if (_webConfig == null)
                    {
                        _webConfig = new WebConfigManager();
                    }
                }
            }
            return _webConfig;
        }
    }

    public class WebConfigSetting
    {
        public string Production
        {
            get;
            set;
        }
    }
}