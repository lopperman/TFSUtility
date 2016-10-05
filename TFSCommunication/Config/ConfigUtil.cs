using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommunication.Config
{
    public static class ConfigUtil
    {
        private static string _configFilePath = string.Empty;
        private static string _tfsUri = string.Empty;

        public static string ConfigFilePath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_configFilePath))
                {
                    _configFilePath = Settings.Default.ConfigFile;
                }
                return _configFilePath;
            }
        }

        public static string TFSUri
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_tfsUri))
                {
                    ExeConfigurationFileMap configMap = new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = ConfigFilePath
                    };
                    var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

                    if (!config.AppSettings.Settings.AllKeys.ToList().Contains("TFSRootUri"))
                    {
                        throw new ConfigurationException(string.Format("Configuration file: {0} is missing key and/or value for TFSRootUri",ConfigFilePath));
                    }
                    _tfsUri = config.AppSettings.Settings["TFSRootUri"].Value;
                }
                return _tfsUri;
            }
        }
    }
}
