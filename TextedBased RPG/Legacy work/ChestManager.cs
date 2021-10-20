using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ChestManager
    {
        private int chestAmount = 999;
        private int chestCount;
        private Chest[] chest;
        private ItemProperties items;
        private Random random;


        public ChestManager(ItemProperties itemTarget, Random randomTarget)
        {
            chest = new Chest[chestAmount];
            items = itemTarget;
            random = randomTarget;
        }
        public void CreateChest(string item, int xPos, int yPos)
        {
            
            switch (item) {
                case "sword":
                    chest[chestCount] = new Chest(1, ITEM.SWORD, items, random);
                    break;
                case "raft":
                    chest[chestCount] = new Chest(0, ITEM.RAFT, items, random);
                    break;
                case "bow":
                    chest[chestCount] = new Chest(1, ITEM.BOW, items, random);
                    break;
                case "potion":
                    chest[chestCount] = new Chest(0, ITEM.POTION, items, random);
                    break;
                case "money":
                    chest[chestCount] = new Chest(0, ITEM.MONEY, items, random);
                    break;
                default:
                    chest[chestCount] = new Chest(0, ITEM.MONEY, items, random);
                    break;
            }
            chest[chestCount].SetPos(xPos, yPos);
            chestCount += 1;
        }
        public void FindPlayer(Player playerTarget)
        {
            for(int z = 0; z < chestCount; z++)
            {
                chest[z].FindPlayer(playerTarget);
            }
        }

        public void Draw()
        {
            for (int z = 0; z < chestCount; z++)
            {
                chest[z].Draw();
            }
        }

        public Chest LocateChest(int x, int y)
        {
            Chest chestTarget = null;
            for (int z = 0; z < chestCount; z++)
            {
                if ((chest[z].xPos == x) && (chest[z].yPos == y) && (chest[z].Opened == false))
                {
                    chestTarget = chest[z];
                }
            }
            return chestTarget;
        }
    }
}
