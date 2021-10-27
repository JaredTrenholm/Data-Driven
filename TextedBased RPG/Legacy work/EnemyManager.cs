using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class EnemyManager
    {
        private static int enemyAmount = 999;
        private int enemyCount = 0;
        private Enemy[] enemy = new Enemy[enemyAmount];
        private int enemyLimit = enemyAmount;
        private Random random;
        private int bossID = -1;

        public EnemyManager(Random randomTarget)
        {
            random = randomTarget;
        }

        public bool AllDeadCheck()
        {
            int deaths = 0;
            for (int z = 0; z < enemyCount; z++)
            {
                if (enemy[z].alive == true)
                {
                }
                else
                {
                    deaths = deaths + 1;
                }
            }

            if(deaths >= enemyLimit)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public Enemy[] GetEnemies()
        {
            return enemy;
        }
        public void CreateEnemy(int x, int y, string type)
        {
            switch (type.ToLower()) {
                case "dog":
                    enemy[enemyCount] = new SecondEnemy(random);
                    break;
                case "slime":
                    enemy[enemyCount] = new FirstEnemy(random);
                    break;
                case "bandit":
                    enemy[enemyCount] = new ThirdEnemy(random);
                    break;
                case "boss":
                    if (bossID == -1)
                    {
                        enemy[enemyCount] = new Boss(random);
                        bossID = enemyCount;
                    } else
                    {
                        enemy[enemyCount] = new ThirdEnemy(random);
                    }
                    break;
                default:
                    enemy[enemyCount] = new FirstEnemy(random);
                    break;
            }
            enemy[enemyCount].SetPos(x, y);
            enemyCount++;
        }
        public void enemyInitialize(Player playerTarget, EnemyManager enemies)
        {
            for (int x = 0; x < enemyCount; x++)
            {
                enemy[x].SetSpeciesType(0);
                enemy[x].GetPlayerTarget(playerTarget);
                enemy[x].GrabManager(enemies);
            }
        }


        public bool BossDead()
        {
            if (bossID != -1)
            {
                if (enemy[bossID].alive == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }
        public int GetCount()
        {
            return enemyCount;
        }
        public Enemy LocateEnemy(int x, int y)
        {
            Enemy enemyTarget = null;
            for (int z = 0; z < enemyCount; z++)
            {
                if((enemy[z].CharacterX == x) && (enemy[z].CharacterY == y) && (enemy[z].alive == true))
                {
                    enemyTarget = enemy[z];
                }
            }
            return enemyTarget;
        }

        public void Update()
        {
            for (int z = 0; z < enemyCount; z++)
            {
                if (enemy[z].alive == true)
                {
                    enemy[z].EnemyTurn();
                }
            }
        }

        public void Draw()
        {
            for (int z = 0; z < enemyCount; z++)
            {
                if (enemy[z].alive == true)
                {
                    enemy[z].Draw();
                }
                else
                {
                    enemy[z].SetAttackMessage(" ");
                }
            }
        }

    }
}
