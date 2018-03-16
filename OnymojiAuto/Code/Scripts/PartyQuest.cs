using System.Threading;
using System.Threading.Tasks;
using OnymojiAuto.Code.Model;
using OnymojiAuto.Code.Services;

namespace OnymojiAuto.Code.Scripts
{
    public class PartyQuest
    {
        private const string BACK_IN_BATTLE_POINT = "BACK_IN_BATTLE_POINT";
        private const string BACK_IN_WAITING_POINT = "BACK_IN_WAITING_POINT";
        private const string EMO_IN_WAITING_POINT = "EMO_IN_WAITING_POINT";
        private const string EXPLORER_POINT = "EXPLORER_POINT";
        private const string INVITE_PARTY_POINT = "INVITE_PARTY_POINT";
        private const string QUIT_IN_WAITING_POINT = "QUIT_IN_WAITING_POINT";

        public static string ScriptName = "PartyQuest";
        public static string ConfigSection = "PartyQuest";

        public static string[] PartyQuestPoints =
        {
            BACK_IN_BATTLE_POINT,
            BACK_IN_WAITING_POINT,
            EMO_IN_WAITING_POINT,
            EXPLORER_POINT,
            INVITE_PARTY_POINT,
            QUIT_IN_WAITING_POINT
        };

        public static Window window;

        public static async void run()
        {
            if (window == null)
            {
                window = new Window("NoxPlayer");
            }

            var backInBattlePoint = ScriptHelper.getPointColorFromConfig(ConfigSection, BACK_IN_BATTLE_POINT);
            var backInWaitingPoint = ScriptHelper.getPointColorFromConfig(ConfigSection, BACK_IN_WAITING_POINT);
            var emoInWaitingPoint = ScriptHelper.getPointColorFromConfig(ConfigSection, EMO_IN_WAITING_POINT);
            var explorerPoint = ScriptHelper.getPointColorFromConfig(ConfigSection, EXPLORER_POINT);
            var invitePartyPoint = ScriptHelper.getPointColorFromConfig(ConfigSection, INVITE_PARTY_POINT);
            var quitOkInWaitingPoint = ScriptHelper.getPointColorFromConfig(ConfigSection, QUIT_IN_WAITING_POINT);

            if (window.isCorrectPixelByRelatedPos(backInBattlePoint))
            {
                ScriptHelper.Log("In Battle");
                if (!ScriptHelper.IS_TESTING)
                {
                }
            }
            else if (window.isCorrectPixelByRelatedPos(backInWaitingPoint))
            {
                if (window.isCorrectPixelByRelatedPos(emoInWaitingPoint))
                {
                    ScriptHelper.Log("Waiting");
                    if (!ScriptHelper.IS_TESTING)
                    {
                    }
                }
                else
                {
                    ScriptHelper.Log("Outed");
                    if (!ScriptHelper.IS_TESTING)
                    {
                        ScriptHelper.Log("Click Back");
                        window.clickByRelatedCoor(backInWaitingPoint);
                        await Task.Delay(500);
                        ScriptHelper.Log("Click OK");
                        window.clickByRelatedCoor(quitOkInWaitingPoint);
                    }
                }
            }
            else if (window.isCorrectPixelByRelatedPos(explorerPoint))
            {
                ScriptHelper.Log("Explorer");
            }
            else if (window.isCorrectPixelByRelatedPos(invitePartyPoint))
            {
                ScriptHelper.Log("Inviting");
                if (!ScriptHelper.IS_TESTING)
                {
                    ScriptHelper.Log("Click Accept");
                    window.clickByRelatedCoor(invitePartyPoint);
                }
            }
        }
    }
}