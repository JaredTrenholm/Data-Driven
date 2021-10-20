using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {

        private Player player;


        private Random random = new Random();
        private Hud HUD;
        private TownManager towns;
        private List<Shop> shops = new List<Shop>();
        private EnemyManager enemies;
        private ChestManager chests;
        private NPCManager npcs;

        private GameLoopConditionals gameLoop;

        private ItemProperties items;

        List<ITEM> stockListForShop1 = new List<ITEM>();
        List<ITEM> stockListForShop2 = new List<ITEM>();
        List<ITEM> stockListForShop3 = new List<ITEM>();
        /*





        */
        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 
        //constructor
        /* public GameManager()
         {

         }*/
        //private methods
        private void SetUpShops()
        {
            stockListForShop1.Add(ITEM.POTION);
            stockListForShop1.Add(ITEM.SWORD);
            stockListForShop1.Add(ITEM.BOW);
            shops.Add(new Shop("The $hop", $"You sure look like you could use a boat!,\ntoo bad I sold my last one to a guy in town! :D HA,HA,HA.", 16, 7, items, stockListForShop1, 3)); // I-0
            shops[0].itemsInShop = shops[0].itemsInShop;
            shops[0].SetPlayer(player);

            stockListForShop2.Add(ITEM.POTION);
            stockListForShop2.Add(ITEM.SWORD);
            stockListForShop2.Add(ITEM.BOW);
            stockListForShop2.Add(ITEM.RAFT);
            shops.Add(new Shop("CommerceSuperCentre", "I didn't know what these other shop keepers should say", 18, 8, items, stockListForShop2, 6)); // I-1
            shops[1].SetPlayer(player);

            stockListForShop3.Add(ITEM.SWORD);
            shops.Add(new Shop("Lorem Ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 19, 9, items, stockListForShop3, 19)); // I-2
            shops[2].SetPlayer(player);
        }

        //public methods
        public void RunGame()
        {
            InitObjects();

            while (gameLoop.GameLoopActive() == true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                towns.Draw();
                shops[0].Draw();
                shops[1].Draw();
                shops[2].Draw();
                chests.Draw();
                enemies.Draw();
                npcs.Draw();
                player.Draw();
                Renderer.Draw();
                HUD.Display();
                player.MovePlayer();
                player.SetAttackMessage(" ");
                enemies.Update();
                player.Update();
            }

            GameEnding();



        }  

        private void InitObjects()
        {
            Map.LoadMap();

            DataReading dataReader = new DataReading();

            items = new ItemProperties();
            enemies = new EnemyManager(random);
            chests = new ChestManager(items, random);
            towns = new TownManager();
            npcs = new NPCManager();

            dataReader.LoadData(enemies, npcs, towns, chests);
            
            HUD = new Hud();
            player = new Player(enemies, chests, towns, shops, npcs, HUD, items);
            towns.SetPlayer(player);
            
            HUD.findTargets(player, enemies.GetEnemies());
            enemies.enemyInitialize(player, enemies);
            chests.FindPlayer(player);
            Renderer.FindPlayer(player);
            Map.FindPlayer(player);

            SetUpShops();

            gameLoop = new GameLoopConditionals(enemies, player);
        }

        private void GameEnding()
        {
            if (gameLoop.CheckCondition() == 1)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have died!");
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 2)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have defeated all of the bandits!");
                Console.WriteLine("Upon defeating " + Global.BOSS_NAME + " and his army, you finally are at peace and able to head home.");
                Console.WriteLine("The stories of what you did travel across the land and bandits fear your name.");
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 3)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have defeated the Bandit Lord!");
                Console.WriteLine("Upon defeating " + Global.BOSS_NAME + ", you realize there is work yet to be finished.");
                Console.WriteLine("You may have shattered the Bandit army, but you did not defeat all of them.");
                Console.WriteLine("The remaining bandit army caused chaos across the land as they searched for a new leader.");
                Console.ReadKey(true);
            }
        }
    }
}
