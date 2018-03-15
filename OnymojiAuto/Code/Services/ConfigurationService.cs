using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace OnymojiAuto.Code.Services
{
    public class ConfigurationService
    {

        private static IniData data = null;
        private static readonly FileIniDataParser parser =  new FileIniDataParser();

        public static void setConfig(string section,string key,string value)
        {
            ConfigurationService.getData();
            ConfigurationService.data[section][key] = value;
            parser.WriteFile("Configuration.ini", ConfigurationService.data);
        }

        public static string getConfig(string section, string key)
        {
            ConfigurationService.getData();
            return ConfigurationService.data[section][key];
        }

        private static IniData getData()
        {
            if(ConfigurationService.data == null)
            {
                var parser = new FileIniDataParser();
                if (!File.Exists(("Configuration.ini")))
                {
                    File.Create(("Configuration.ini"));          
            
                }

                ConfigurationService.data = parser.ReadFile("Configuration.ini");
            }
            
            return ConfigurationService.data;
        }
    }
}
