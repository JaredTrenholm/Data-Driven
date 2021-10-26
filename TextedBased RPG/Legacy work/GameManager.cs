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
        private ShopManager shops;
        
        private EnemyManager enemies;
        private ChestManager chests;
        private NPCManager npcs;

        private GameLoopConditionals gameLoop;

        private ItemManager items;

        
       //9 left of the player is the map border
       //10 right of the player is the map border
       //4 up of the player is the map border
       //5 down of the player is the map border
 
        public void RunGame()
        {
            while (gameLoop.GameLoopActive() == true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                towns.Draw();
                shops.Draw();
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

        public void InitObjects()
        {
            Map.LoadMap();

            DataReading dataReader = new DataReading();

            items = new ItemManager();
            enemies = new EnemyManager(random);
            chests = new ChestManager(items, random);
            towns = new TownManager();
            npcs = new NPCManager();
            HUD = new Hud();
            shops = new ShopManager(items);
            player = new Player(enemies, chests, towns, shops, npcs, HUD, items);
            dataReader.LoadData(enemies, npcs, towns, chests, items, player, shops);
            shops.GivePlayerReference(player);
            towns.SetPlayer(player);
            
            HUD.findTargets(player, enemies.GetEnemies());
            enemies.enemyInitialize(player, enemies);
            chests.FindPlayer(player);
            Renderer.FindPlayer(player);
            Map.FindPlayer(player);


            gameLoop = new GameLoopConditionals(enemies, player);
        }

        private void GameEnding()
        {
            if (gameLoop.CheckCondition() == 1)
            {
                Console.Clear();
                foreach(string line in Global.DEATH_ENDING)
                {
                    Console.WriteLine(line);
                }
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 2)
            {
                Console.Clear();
                foreach (string line in Global.GOOD_ENDING)
                {
                    Console.WriteLine(line);
                }
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 3)
            {
                Console.Clear();
                foreach (string line in Global.MEDIUM_ENDING)
                {
                    Console.WriteLine(line);
                }
                Console.ReadKey(true);
            }
        }
    }
}
