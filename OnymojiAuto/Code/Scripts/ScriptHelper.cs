using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using OnymojiAuto.Code.Model;
using OnymojiAuto.Code.Services;

namespace OnymojiAuto.Code.Scripts
{
    public class ScriptHelper
    {

        public static Window window = new Window("NoxPlayer");

        public static int _checkInterruptAuto = 0;
        public static Stopwatch _watchTimeSpent;

        public static bool IS_TESTING = false;
        private static readonly List<PointColor> _pointColors = new List<PointColor>();
        public static Subject<int> checkInterrupt = new Subject<int>();
        public static Subject<object> checkIdlSubject = new Subject<object>();

        public static void setPointDataToConfig(string section, string id, string[] data)
        {
            ConfigurationService.setConfig(section, getXKey(id), data[0]);
            ConfigurationService.setConfig(section, getYKey(id), data[1]);
            ConfigurationService.setConfig(section, getColorKey(id), data[2]);
        }

        public static void setDataToConfig(string section, string id, string data)
        {
            ConfigurationService.setConfig(section, id, data);
        }

        public static PointColor getPointColorFromConfig(string section, string id)
        {
            PointColor _pc;
            var x = ConfigurationService.getConfig(section, getXKey(id));
            var y = ConfigurationService.getConfig(section, getYKey(id));
            var cl = ConfigurationService.getConfig(section, getColorKey(id));

            try
            {
                _pc = new PointColor(id, decimal.Parse(x), decimal.Parse(y), decimal.Parse(cl));
            }
            catch
            {
                _pc = new PointColor(id);
            }

            _pointColors.Add(_pc);

            return _pc;
        }

        public static void Log(string mess)
        {
            Console.WriteLine(mess);
        }

        private static string getXKey(string id)
        {
            return id + "X";
        }

        private static string getYKey(string id)
        {
            return id + "Y";
        }

        private static string getColorKey(string id)
        {
            return id + "Color";
        }
    }
}