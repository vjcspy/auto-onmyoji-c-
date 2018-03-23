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
        private static readonly FileIniDataParser parser = new FileIniDataParser();

        public static void setConfig(string section, string key, string value)
        {
            getData();
            data[section][key] = value;
            parser.WriteFile("Configuration.ini", data);
        }

        public static string getConfig(string section, string key)
        {
            getData();
            return data[section][key];
        }

        public static void clearKey(string section, string key)
        {
            getData();
            data[section].RemoveKey(key);
            parser.WriteFile("Configuration.ini", data);
        }

        public static IniData getData()
        {
            if (data == null)
            {
                var parser = new FileIniDataParser();
                if (!File.Exists(("Configuration.ini")))
                {
                    File.Create(("Configuration.ini"));

                }

                data = parser.ReadFile("Configuration.ini");
            }

            return data;
        }
    }
}
