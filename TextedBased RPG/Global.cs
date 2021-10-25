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


        public static string PLAYER_NAME = "You";

        public static string MONEY_NAME = "Gold";

        public static string BOSS_NAME = "Serdun";
        public static string BOSS_AVATAR = "B";
        public static int BOSS_HEALTH = 100;
        public static int BOSS_ATTACK = 10;

        public static string DOG_NAME = "Dog";
        public static string DOG_AVATAR = "D";
        public static int DOG_HEALTH = 10;
        public static int DOG_ATTACK = 1;

        public static string SLIME_NAME = "Slime";
        public static string SLIME_AVATAR = "S";
        public static int SLIME_HEALTH = 10;
        public static int SLIME_ATTACK = 1;

        public static string BANDIT_NAME = "Bandit";
        public static string BANDIT_AVATAR = "E";
        public static int BANDIT_HEALTH = 10;
        public static int BANDIT_ATTACK = 10;
    }
}
