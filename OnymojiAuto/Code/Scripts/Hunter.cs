using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnymojiAuto.Code.Model;
using OnymojiAuto.Code.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;
using System.Threading;

namespace OnymojiAuto.Code.Scripts
{
    class Hunter
    {
        public const string SCRIPT_NAME = "Hunter";

        public const string MONSTER_1 = "MONSTER_1";
        public const string MONSTER_2 = "MONSTER_2";
        public const string MONSTER_3 = "MONSTER_3";
        public const string MONSTER_4 = "MONSTER_4";
        public const string MONSTER_5 = "MONSTER_5";
        public const string READY = "READY";
        public const string REFRESH = "REFRESH";
        public const string REFRESH2 = "REFRESH2";
        public const string GO_PARTY = "GO_PARTY";


        private static Dictionary<string, int> _calTurnMonster = new Dictionary<string, int>();
        private static bool IsFound = false;

        public static string[] Points = {
            MONSTER_1,
            MONSTER_2,
            MONSTER_3,
            MONSTER_4,
            MONSTER_5,
            READY,
            REFRESH,
            REFRESH2,
            GO_PARTY,
        };

        public static void run()
        {
            if (IsFound)
            {
                return;
            }

            Console.Clear();

            var refresh = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, REFRESH);
            var refresh2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, REFRESH2);

            if (ScriptHelper.window.isCorrectPixelByRelatedPos(refresh) || ScriptHelper.window.isCorrectPixelByRelatedPos(refresh2))
            {
                Points.ToList().ForEach((x =>
                {
                    if (x.IndexOf("MON") > -1)
                        scanHunting(x);
                }));
            }

            if (!IsFound)
            {
                Thread.Sleep(800);
                CheckState();
            }
        }

        private static void CheckState()
        {

            try
            {
                var ready = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, READY);
                var refresh = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, REFRESH);
                var refresh2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, REFRESH2);
                var goParty = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, GO_PARTY);

                if (ScriptHelper.window.isCorrectPixelByRelatedPos(ready))
                {
                    Console.WriteLine("Battle");
                    ScriptHelper.window.clickByRelatedCoor(ready);
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(goParty))
                {
                    Console.WriteLine("Go Party");
                    ScriptHelper.window.clickByRelatedCoor(goParty);
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(refresh))
                {
                    Console.WriteLine("Refresh");
                    ScriptHelper.window.clickByRelatedCoor(refresh);
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(refresh2))
                {
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + ": " + "Refresh");
                    ScriptHelper.window.clickByRelatedCoor(refresh2);
                }
                else
                {
                    ScriptHelper.Log("Click Spam");
                    ScriptHelper.window.clickByRelatedCoor(22.85106m, 7.95947m);
                }
            }
            catch
            {

            }
        }

        private static void scanHunting(string id)
        {
            Console.WriteLine("Finding Id" + id);
            try
            {
                var screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                var g = Graphics.FromImage(screenCapture);

                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 screenCapture.Size,
                                 CopyPixelOperation.SourceCopy);

                var _realSearchInTop = ScriptHelper.window.getRealCoor(32m, 27);
                var _realSearchInBottom = ScriptHelper.window.getRealCoor(32m, 76);

                var monsterData = ConfigurationService.getConfig(SCRIPT_NAME, id);
                if (monsterData != null)
                {
                    var monsterColors = JsonConvert.DeserializeObject<List<object>>(monsterData);

                    if (monsterColors != null && monsterColors.Count() > 0)
                    {
                        for (var _searchY = _realSearchInTop[1]; _searchY < _realSearchInBottom[1]; _searchY++)
                        {
                            for (var _searchX = _realSearchInTop[0]; _searchX < _realSearchInTop[0] + 20; _searchX++)
                            {
                                var _isValid = true;

                                for (var _k = 0; _k < monsterColors.Count(); _k++)
                                {
                                    if ((string)(monsterColors[_k] as JObject)["color"] != screenCapture.GetPixel(_searchX + _k, _searchY).ToArgb().ToString())
                                    {
                                        _isValid = false;
                                        break;
                                    }
                                }

                                if (_isValid == true)
                                {
                                    IsFound = true;
                                    // 81.7 - 33.2
                                    var _relatedPointFound = ScriptHelper.window.getPositionRelatedWindow(_searchX, _searchY);
                                    ScriptHelper.window.clickByRelatedCoor(_relatedPointFound[0] + 81.7m - 33.2m, _relatedPointFound[1]);
                                    Console.WriteLine("FOUND");
                                    ScriptHelper.window.clickByRelatedCoor(_relatedPointFound[0] + 81.7m - 33.2m, _relatedPointFound[1]);
                                    Thread.Sleep(500);
                                    IsFound = false;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
