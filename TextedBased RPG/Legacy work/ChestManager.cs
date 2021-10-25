using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ChestManager
    {
        private int chestAmount = 0;
        private Chest[] chest;
        private ItemManager items;
        private Random random;


        public ChestManager(ItemManager itemTarget, Random randomTarget)
        {
            chest = new Chest[999];
            items = itemTarget;
            random = randomTarget;
        }
        public void CreateChest(string type, int x, int y)
        {
            chest[chestAmount] = new Chest(items);
            if(type.ToLower() == items.bowName.ToLower())
            {
                chest[chestAmount].ChangeID(ITEM.BOW);
                chest[chestAmount].ChangeType(ITEMTYPE.WEAPON);
            }
            else if(type.ToLower() == items.swordName.ToLower())
            {
                chest[chestAmount].ChangeID(ITEM.SWORD);
                chest[chestAmount].ChangeType(ITEMTYPE.WEAPON);
            }
            else if (type.ToLower() == items.boatName.ToLower())
            {
                chest[chestAmount].ChangeID(ITEM.RAFT);
                chest[chestAmount].ChangeType(ITEMTYPE.ITEM);
            }
            else if (type.ToLower() == items.potionName.ToLower())
            {
                chest[chestAmount].ChangeID(ITEM.POTION);
                chest[chestAmount].ChangeType(ITEMTYPE.ITEM);
            }
            else if (type.ToLower() == items.moneyName.ToLower())
            {
                chest[chestAmount].ChangeID(ITEM.MONEY);
                chest[chestAmount].ChangeType(ITEMTYPE.ITEM);
            }
            chest[chestAmount].SetPos(x, y);
            chestAmount += 1;
        }

        public void FindPlayer(Player playerTarget)
        {
            for (int z = 0; z < chestAmount; z++)
            {
                if(chest[z] != null)
                 chest[z].FindPlayer(playerTarget);
                else
                {
                    chestAmount -= 1;
                }
            }
        }

        public void Draw()
        {
            for (int z = 0; z < chestAmount; z++)
            {
                chest[z].Draw();
            }
        }

        public Chest LocateChest(int x, int y)
        {
            Chest chestTarget = null;
            for (int z = 0; z < chestAmount; z++)
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
