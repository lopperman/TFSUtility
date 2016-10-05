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
        private static string _projectName;
        private static Configuration _config = null;

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

        public static Configuration TfsConfiguration
        {
            get
            {
                if (_config == null)
                {
                    ExeConfigurationFileMap configMap = new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = ConfigFilePath
                    };
                    var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                    if (config == null)
                    {
                        throw new ConfigurationException(string.Format("Configuration file: {0} is missing.", ConfigFilePath));
                    }
                    _config = config;

                }

                return _config;
            }
        }


        public static string TFSUri
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_tfsUri))
                {

                    if (!TfsConfiguration.AppSettings.Settings.AllKeys.ToList().Contains("TFSRootUri"))
                    {
                        throw new ConfigurationException(string.Format("Configuration file: {0} is missing key and/or value for TFSRootUri",ConfigFilePath));
                    }
                    _tfsUri = TfsConfiguration.AppSettings.Settings["TFSRootUri"].Value;
                }
                return _tfsUri;
            }
        }

        public static string ProjectName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_projectName))
                {
                    if (!TfsConfiguration.AppSettings.Settings.AllKeys.ToList().Contains("TFSProjectName"))
                    {
                        throw new ConfigurationException(string.Format("Configuration file: {0} is missing key and/or value for TFSProjectName", ConfigFilePath));
                    }
                    _projectName = TfsConfiguration.AppSettings.Settings["TFSProjectName"].Value;
                }
                return _projectName;
            }
        }
    }
}
