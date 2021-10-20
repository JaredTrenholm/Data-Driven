using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    enum ITEM
    { 
        NULL,
        SWORD,
        BOW,
        POTION,
        RAFT,
        MONEY
    }
    enum ITEMTYPE
    { 
       NULL,
       ITEM,
       WEAPON
    }
    class ItemProperties
    {
        private string weaponName;

        private string[] itemsList = new string[999];
        private int[] itemTypes = new int[999];
        private int itemsCount;

        private int[] effect = new int[999];
        private int[] pricing = new int[999];

        public void CreateItem(string name, int type, int price, int effectValue)
        {
            itemsList[itemsCount] = name;
            itemTypes[itemsCount] = type;
            effect[itemsCount] = effectValue;
            pricing[itemsCount] = price;
            itemsCount += 1;
        }
        public int GetWeaponTypeID()
        {
            return 1;
        }
        public string GetWeaponName(int weaponID)
        {
            for (int x = 0; x < itemsCount; x++)
            {
                if(itemTypes[weaponID] == 1)
                    return itemsList[weaponID];
            }
            return " ";
        }

        public int GetWeaponAttack(string WeaponID)
        {
            for(int x = 0; x < itemsCount; x++)
            {
                if(WeaponID == itemsList[x])
                {
                    return effect[x];
                }
            }
            return 0;
        }

        public string GetItemName(string ItemID)
        {
            for (int x = 0; x < itemsCount; x++)
            {
                if (ItemID == itemsList[x])
                {
                    return itemsList[x];
                }
            }
            return " ";
        }
        public bool CheckItemName(string itemName)
        {
            for (int x = 0; x < itemsCount; x++)
            {
                if (itemName == itemsList[x])
                {
                    return true;
                }
            }
            return false;
        }

        public int GetItemPrice(string itemName)
        {
            for (int x = 0; x < itemsCount; x++)
            {
                if (itemName == itemsList[x])
                {
                    return pricing[x];
                }
            }
            return 0;
        }

    }
}
