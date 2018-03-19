using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnymojiAuto.Code.Scripts
{
    class Snake
    {
        public const string SCRIPT_NAME = "Snake";

        public const string BACK_IN_BATTLE = "BACK_IN_BATTLE";
        const string MONSTER_1 = "MONSTER_1";
        const string MONSTER_2 = "MONSTER_2";
        const string MONSTER_3 = "MONSTER_3";
        const string WAITING_SNAKE = "WAITING";
        const string NEW_SNAKE = "NEW_SNAKE";
        const string CONFIRM_NEW_SNAKE = "CONFIRM_NEW_SNAKE";
        const string READY_SNAKE = "READY_SNAKE";

        public const string SKILLS_MASTER = "SKILLS_MASTER";
        public const string SKILLS_DAMAGE = "SKILLS_DAMAGE";
        public const string SKILLS_SPEED = "SKILLS_SPEED";

        // Related position of skills
        static decimal[] skill1 = { 76.79128m, 92.28723m };
        static decimal[] skill2 = { 85.35826m, 92.15426m };
        //static decimal[] skill3 = { 1, 2 };

        public static string[] Points = {
            BACK_IN_BATTLE,
            MONSTER_1,
            MONSTER_2,
            MONSTER_3,
            WAITING_SNAKE,
            NEW_SNAKE,
            CONFIRM_NEW_SNAKE,
            READY_SNAKE
        };

        private static int _masterNumberCastingSkill = 0;
        private static Random rnd = new Random();

        public  static void run()
        {
            var _backInBattle = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, BACK_IN_BATTLE);
            var _monster1 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, MONSTER_1);
            var _monster2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, MONSTER_2);
            var _monster3 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, MONSTER_3);
            var _watingSnake = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, WAITING_SNAKE);
            var _newSnake = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, NEW_SNAKE);
            var _confirmNewSnake = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, CONFIRM_NEW_SNAKE);
            var _readySnake = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, READY_SNAKE);

            var _masterSkill1 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_MASTER + "skill1");
            var _masterSkill2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_MASTER + "skill2");
            var _damageSkill1 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_DAMAGE + "skill1");
            var _damageSkill2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_DAMAGE + "skill2");
            var _speedSkill1 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_SPEED + "skill1");
            var _speedSkill2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, SKILLS_SPEED + "skill2");

            Console.Clear();

            if (ScriptHelper.window.isCorrectPixelByRelatedPos(_backInBattle))
            {
                Console.WriteLine("In Battle");
                if (ScriptHelper.window.isCorrectPixelByRelatedPos(_readySnake))
                {
                    Console.WriteLine("Ready");
                    if (!ScriptHelper.IS_TESTING)
                    {
                        ScriptHelper.window.clickByRelatedCoor(_readySnake);
                    }
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(_masterSkill1))
                {
                    Console.WriteLine("Master Turn");
                    if (ScriptHelper.window.isCorrectPixelByRelatedPos(_masterSkill2))
                    {
                        if (_masterNumberCastingSkill % 5 == 0)
                        {
                            if (!ScriptHelper.IS_TESTING)
                            {
                                Console.WriteLine("Master Select Skill2");
                                ScriptHelper.window.clickByRelatedCoor(_masterSkill2);
                            }
                            _masterNumberCastingSkill += 1;
                        }

                    }

                    if (!ScriptHelper.IS_TESTING)
                    {
                        Console.WriteLine("Master Attack");
                        ScriptHelper.window.clickByRelatedCoor(_monster1);
                        Thread.Sleep(200);
                        ScriptHelper.window.clickByRelatedCoor(_monster3);
                        Thread.Sleep(200);
                        ScriptHelper.window.clickByRelatedCoor(_monster2);
                    }
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(_damageSkill1))
                {
                    Console.WriteLine("Damage Turn");

                    if (!ScriptHelper.IS_TESTING)
                    {
                        Console.WriteLine("Damage Attack");
                        ScriptHelper.window.clickByRelatedCoor(_monster1);
                        Thread.Sleep(200);
                        ScriptHelper.window.clickByRelatedCoor(_monster3);
                        Thread.Sleep(200);
                        ScriptHelper.window.clickByRelatedCoor(_monster2);
                    }
                }
                else if (ScriptHelper.window.isCorrectPixelByRelatedPos(_speedSkill1))
                {
                    Console.WriteLine("Speed Turn");

                    if (ScriptHelper.window.isCorrectPixelByRelatedPos(_speedSkill2))
                    {
                        Console.WriteLine("Speed Select Skill 2");
                        ScriptHelper.window.clickByRelatedCoor(_speedSkill2);
                        Thread.Sleep(500);
                        Console.WriteLine("Speed Cast Skill 2");
                        ScriptHelper.window.clickByRelatedCoor(rnd.Next(40, 60), 67);
                    }
                    else
                    {
                        if (!ScriptHelper.IS_TESTING)
                        {
                            Console.WriteLine("Speed Attack");
                            ScriptHelper.window.clickByRelatedCoor(_monster1);
                            Thread.Sleep(200);
                            ScriptHelper.window.clickByRelatedCoor(_monster3);
                            Thread.Sleep(200);
                            ScriptHelper.window.clickByRelatedCoor(_monster2);
                        }
                    }
                }
            }
            else if (ScriptHelper.window.isCorrectPixelByRelatedPos(_watingSnake))
            {
                Console.WriteLine("In waiting snake");
                if (!ScriptHelper.IS_TESTING)
                {
                    Console.WriteLine("New Snake");
                    ScriptHelper.window.clickByRelatedCoor(_newSnake);
                }
            }
            else
            {
                Console.WriteLine("SPAM");
                if (!ScriptHelper.IS_TESTING)
                {
                    Console.WriteLine("Click SPAM");
                    ScriptHelper.window.clickByRelatedCoor(rnd.Next(40, 60), 67);
                }
            }
            Thread.Sleep(2000);
        }

        public static void saveSkillsData(string id)
        {
            //skill 1:
            string[] _skill1Data = { skill1[0].ToString(), skill1[1].ToString(), ScriptHelper.window.getColorOfPixelByRelatedPos(skill1[0], skill1[1]).ToString() };
            ScriptHelper.setPointDataToConfig(SCRIPT_NAME, id + "skill1", _skill1Data);

            //skill 2:
            string[] _skill2Data = { skill2[0].ToString(), skill2[1].ToString(), ScriptHelper.window.getColorOfPixelByRelatedPos(skill2[0], skill2[1]).ToString() };
            ScriptHelper.setPointDataToConfig(SCRIPT_NAME, id + "skill2", _skill2Data);

            //skill 3:
            //string[] _skill3Data = { skill3[0].ToString(), skill3[1].ToString(), ScriptHelper.window.getColorOfPixelByRelatedPos(skill3[0], skill3[1]).ToString() };
            //ScriptHelper.setPointDataToConfig(SCRIPT_NAME, id + "skill3", _skill3Data);
        }

        public static bool isExistedDataSkill(string id)
        {
            var _skillPoint1 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, id + "skill1");
            var _skillPoint2 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, id + "skill2");
            //var _skillPoint3 = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, id + "skill3");

            if (_skillPoint1.color != 0 && _skillPoint2.color != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
