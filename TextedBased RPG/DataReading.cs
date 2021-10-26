using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class DataReading
    {
        static string[] fileNames = { "ItemPropertiesAndNames", "Intro", "GoodEnding", "MediumEnding", "DeathEnding","EnemyTypes", "TitleScreen","Player", "Enemy", "NPC", "Towns", "Chests", "Shops"}; //Text files will be read in order. Put vital files first

        public void LoadData(EnemyManager enemyManager, NPCManager npcManager, TownManager townManager, ChestManager chestManager, ItemManager items, Player player, ShopManager shops)
        {
            try
            {
                string[] fileLoaded;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    //Simply way to detect files and say which is missing.
                    try
                    {
                        fileLoaded = System.IO.File.ReadAllLines("DataFiles/" + fileNames[i] + ".txt");
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("You are missing the: " + fileNames[i] + ".txt file!");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    //actual loading of file
                    fileLoaded = System.IO.File.ReadAllLines("DataFiles/" + fileNames[i] + ".txt");

                    //Compares file name to cases to detect which method to fire off.
                    //ALL PARSE METHODS WORK DIFFERENTLY FOR DIFFERENT PURPOSES
                    switch (fileNames[i])
                    {
                        case "DeathEnding":
                            Global.DEATH_ENDING = fileLoaded;
                            break;
                        case "MediumEnding":
                            Global.MEDIUM_ENDING = fileLoaded;
                            break;
                        case "GoodEnding":
                            Global.GOOD_ENDING = fileLoaded;
                            break;
                        case "Intro":
                            Global.INTRO_TEXT = fileLoaded;
                            break;
                        case "TitleScreen":
                            Global.TITLE = fileLoaded;
                            break;
                        case "Shops":
                            ParseShops(fileLoaded, shops);
                            break;
                        case "EnemyTypes":
                            ParseEnemyTypes(fileLoaded);
                            break;
                        case "Player":
                            ParsePlayer(fileLoaded, player);
                            break;
                        case "ItemPropertiesAndNames":
                            ParseItemProperties(fileLoaded, items);
                            break;
                        case "Enemy":
                            ParseEnemies(fileLoaded, enemyManager);
                            break;
                        case "NPC":
                            ParseNPC(fileLoaded, npcManager);
                            break;
                        case "Towns":
                            ParseTown(fileLoaded, townManager);
                            break;
                        case "Chests":
                            ParseChest(fileLoaded, chestManager);
                            break;
                    }
                }
            } catch
            {
                Console.Clear();
                Console.WriteLine("There is an error with your data files. Things like typos, or blank values will cause this.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        private void ParseShops(string[] fileLoaded, ShopManager shops)
        {
            List<string> items = new List<string>();
            int x = -1;
            int y = -1;
            int tax = -1;
            string name = "";
            string dialogue = "";
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');

                for (int n = 0; n < lineSplit.Length; n++)
                {
                    if (lineSplit[n].ToLower() == "name")
                    {
                        name = lineSplit[n + 1];
                        n += 1;
                    }
                    else if (lineSplit[n].ToLower() == "dialogue")
                    {
                        dialogue = lineSplit[n + 1];
                        n += 1;
                    }
                    else if (lineSplit[n].ToLower() == "x")
                    {
                        x = Convert.ToInt16(lineSplit[n + 1]);
                        n += 1;
                    }
                    else if (lineSplit[n].ToLower() == "y")
                    {
                        y = Convert.ToInt16(lineSplit[n + 1]);
                        n += 1;
                    }
                    else if (lineSplit[n].ToLower() == "tax")
                    {
                        tax = Convert.ToInt16(lineSplit[n + 1]);
                        n += 1;
                    }
                    else
                    {
                        items.Add(lineSplit[n].ToLower());
                    }

                    if (lineSplit[n].ToLower() == "end" && x > 0 && y > 0)
                    {
                        if (name != "")
                            if (dialogue != "")
                                if (items.Count > 0)
                                {
                                    shops.CreateShop(name, dialogue, x, y, tax, items);
                                    name = "";
                                    x = -1;
                                    y = -1;
                                    tax = -1;
                                    dialogue = "";
                                    items.Clear();
                                }
                    }
                }
            }
            if (x > 0)
                if (y > 0)
                    if (name != "")
                        if (dialogue != "")
                            if (items.Count > 0)
                            {
                                shops.CreateShop(name, dialogue, x, y, tax, items);
                            }


        }
        private void ParseEnemyTypes(string[] fileLoaded)
        {
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "bossname")
                    {
                        Global.BOSS_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "bosshealth")
                    {
                        Global.BOSS_HEALTH = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "bossavatar")
                    {
                        Global.BOSS_AVATAR = lineSplit[x + 1];
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "bossattack")
                    {
                        Global.BOSS_ATTACK = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "firstname")
                    {
                        Global.FIRST_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "firsthealth")
                    {
                        Global.FIRST_HEALTH = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "firstavatar")
                    {
                        Global.FIRST_AVATAR = lineSplit[x + 1];
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "firstattack")
                    {
                        Global.FIRST_ATTACK = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "secondname")
                    {
                        Global.SECOND_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "secondhealth")
                    {
                        Global.SECOND_HEALTH = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "secondavatar")
                    {
                        Global.SECOND_AVATAR = lineSplit[x + 1];
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "secondattack")
                    {
                        Global.SECOND_ATTACK = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "thirdname")
                    {
                        Global.THIRD_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "thirdhealth")
                    {
                        Global.THIRD_HEALTH = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "thirdavatar")
                    {
                        Global.THIRD_AVATAR = lineSplit[x + 1];
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "thirdattack")
                    {
                        Global.THIRD_ATTACK = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                }
            }
        }
        private void ParseItemProperties(string[] fileLoaded, ItemManager itemManager)
        {
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "weapononename")
                    {
                        itemManager.fistName = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weapontwoname")
                    {
                        itemManager.bowName = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weaponthreename")
                    {
                        itemManager.swordName = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weapononedamage")
                    {
                        itemManager.fistDamage = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weapontwodamage")
                    {
                        itemManager.bowDamage = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weaponthreedamage")
                    {
                        itemManager.fistDamage = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weapontwoprice")
                    {
                        itemManager.bowPrice = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "weaponthreeprice")
                    {
                        itemManager.swordPrice = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "boatname")
                    {
                        itemManager.boatName = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "boatprice")
                    {
                        itemManager.boatPrice = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "potionname")
                    {
                        itemManager.potionName = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "potionhealing")
                    {
                        Global.POTION_HEAL = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "potionprice")
                    {
                        itemManager.potionPrice = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "moneyname")
                    {
                        itemManager.moneyName = lineSplit[x + 1];
                        Global.MONEY_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "moneyvalue")
                    {
                        itemManager.moneyValue = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                }
            }
        }
        private void ParsePlayer(string[] fileLoaded, Player player)
        {
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "name")
                    {
                        Global.PLAYER_NAME = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "attack")
                    {
                        Global.BASE_ATTACK = Convert.ToInt16(lineSplit[x + 1]);
                        player.ChangeAttack(Global.BASE_ATTACK);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "health")
                    {
                        player.ChangeHealth(Convert.ToInt16(lineSplit[x + 1]));
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "potions")
                    {
                        player.potionNumber = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "money")
                    {
                        player.money = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }
                }
            }
        }
        private void ParseChest(string[] fileLoaded, ChestManager chestManager)
        {
            string item = "";
            int xPos = -1;
            int yPos = -1;
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "item")
                    {
                        item = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "x")
                    {
                        xPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "y")
                    {
                        yPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (xPos != -1 && yPos != -1 && item != "")
                    {
                        chestManager.CreateChest(item.ToLower(), xPos, yPos);
                        item = "";
                        xPos = -1;
                        yPos = -1;
                        break;
                    }

                }
            }
        }
        private void ParseNPC(string[] fileLoaded, NPCManager npcManager)
        {
            string dialogue = "";
            int xPos = -1;
            int yPos = -1;
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "dialogue")
                    {
                        dialogue = lineSplit[x+1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "x")
                    {
                        xPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "y")
                    {
                        yPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (xPos != -1 && yPos != -1 && dialogue != "")
                    {
                        npcManager.CreateNPC(xPos, yPos, dialogue);
                        dialogue = "";
                        xPos = -1;
                        yPos = -1;
                        break;
                    }

                }
            }
        }
        private void ParseTown(string[] fileLoaded, TownManager townManager)
        {
            string name = "";
            string dialogue = "";
            int xPos = -1;
            int yPos = -1;
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "name")
                    {
                        name = lineSplit[x + 1];
                        x += 1;
                    }
                    if (lineSplit[x].ToLower() == "dialogue")
                    {
                        dialogue = lineSplit[x + 1];
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "x")
                    {
                        xPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "y")
                    {
                        yPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (xPos != -1 && yPos != -1 && dialogue != "" && name != "")
                    {
                        townManager.CreateTown(xPos, yPos,name, dialogue);
                        dialogue = "";
                        name = "";
                        xPos = -1;
                        yPos = -1;
                        break;
                    }

                }
            }
        }
        private void ParseEnemies(string[] fileLoaded, EnemyManager enemyManager)
        {
            string enemyType = "";
            int xPos = -1;
            int yPos = -1;
            for (int i = 0; i < fileLoaded.Length; i++)
            {
                string[] lineSplit = fileLoaded[i].Split('=');
                for (int x = 0; x < lineSplit.Length; x++)
                {
                    if (lineSplit[x].ToLower() == "type")
                    {
                        enemyType = lineSplit[x + 1].ToLower();
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "x")
                    {
                        xPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if (lineSplit[x].ToLower() == "y")
                    {
                        yPos = Convert.ToInt16(lineSplit[x + 1]);
                        x += 1;
                    }

                    if(xPos != -1 && yPos != -1 && enemyType != "")
                    {
                        enemyManager.CreateEnemy(xPos,yPos,enemyType);
                        enemyType = "";
                        xPos = -1;
                        yPos = -1;
                        break;
                    }

                }
            }
        }
    }
}
