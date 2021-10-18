using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class DataReading
    {
        static List<Action> methodList = new List<Action>();
        static string[] fileNames = { "Enemy"};

        // EXAMPLE OF USING TXT TO LOAD METHODS
        /*static void Main(string[] args)
        {
            LoadData();
            foreach (var i in methodList)
            {
                i();
            }
            Console.ReadKey(true);
        }
        static void Fire()
        {
            Console.WriteLine("FIRE!");
        }
        static void Reload()
        {
            Console.WriteLine("Reload!");
        }
        static void Surrender()
        {
            Console.WriteLine("Surrender...");
        }

        static void AddMethod(string methodToAdd)
        {
            switch (methodToAdd)
            {
                case "Fire":
                    methodList.Add(Fire);
                    break;
                case "Reload":
                    methodList.Add(Reload);
                    break;
                case "Surrender":
                    methodList.Add(Surrender);
                    break;
                default:
                    Console.WriteLine(methodToAdd + " is not a method and therefore cannot be called from your data file.");
                    Console.ReadKey(true);
                    break;
            }
        }*/

        public void LoadData(EnemyManager enemyManager)
        {
            string[] fileLoaded;
            for(int i = 0; i < fileNames.Length; i++)
            {
                fileLoaded = System.IO.File.ReadAllLines(fileNames[i] + ".txt");

                switch (fileNames[i]) {
                    case "Enemy":
                        ParseEnemies(fileLoaded, enemyManager);
                        break;
                    case "NPC":
                        ParseNPC(fileLoaded);
                        break;
                }
            }
        }
        private void ParseNPC(string[] fileLoaded)
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
                        dialogue = lineSplit[x + 1].ToLower();
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
                        dialogue = "";
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
