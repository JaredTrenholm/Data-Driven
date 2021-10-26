using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class Global
    {
        //EXPERIMENTAL DON'T TOUCH IF YOU DON'T KNOW HOW THEY WORK. MIGHT REQUIRE SOME MINOR CODING IN THE PROGRAM
        public static int MAP_X_LENGTH = 53;
        public static int MAP_Y_LENGTH = 29;
        public static int RENDER_WIDTH = 20;
        public static int RENDER_LENGTH = 10;
        public static int PLAYER_Y_OFFSET = MAP_Y_LENGTH - 9;
        public static int PLAYER_X_OFFSET = MAP_X_LENGTH-19;

        //FREE TO MODIFY

        public static int BASE_ATTACK = 10;
        public static int POTION_HEAL = 25;

        public static string[] TITLE;
        public static string[] INTRO_TEXT;

        public static string[] DEATH_ENDING;
        public static string[] MEDIUM_ENDING;
        public static string[] GOOD_ENDING;

        public static string PLAYER_NAME = "You";

        public static string MONEY_NAME = "Gold";

        public static string BOSS_NAME = "Serdun";
        public static string BOSS_AVATAR = "B";
        public static int BOSS_HEALTH = 100;
        public static int BOSS_ATTACK = 10;

        public static string FIRST_NAME = "Dog";
        public static string FIRST_AVATAR = "D";
        public static int FIRST_HEALTH = 10;
        public static int FIRST_ATTACK = 1;

        public static string SECOND_NAME = "Slime";
        public static string SECOND_AVATAR = "S";
        public static int SECOND_HEALTH = 10;
        public static int SECOND_ATTACK = 1;

        public static string THIRD_NAME = "Bandit";
        public static string THIRD_AVATAR = "E";
        public static int THIRD_HEALTH = 10;
        public static int THIRD_ATTACK = 10;
    }
}
