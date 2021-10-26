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
        BOAT,
        MONEY
    }
    enum ITEMTYPE
    { 
       NULL,
       ITEM,
       WEAPON
    }
    class ItemManager
    {
        private string weaponName;
        private string itemName;

        private int attackMod;


        public string swordName = "Sword";
        public string bowName = "Bow";
        public string fistName = "Fist";
        public string potionName = "Potion";
        public string boatName = "Boat";
        public string moneyName = "Gold";

        public int swordDamage = 20;
        public int bowDamage = 15;
        public int fistDamage = 0;

        public int swordPrice = 20;
        public int bowPrice = 15;
        public int boatPrice = 215;
        public int potionPrice = 10;

        public int moneyValue = 5;

        public List<ITEM> FormItemList(List<string> inventory)
        {
            List<ITEM> newInventory = new List<ITEM>();

            foreach(string item in inventory)
            {
                if (item.ToLower() == swordName.ToLower())
                {
                    newInventory.Add(ITEM.SWORD);
                } else if (item.ToLower() == bowName.ToLower())
                {
                    newInventory.Add(ITEM.BOW);
                }
                else if (item.ToLower() == potionName.ToLower())
                {
                    newInventory.Add(ITEM.POTION);
                }
                else if (item.ToLower() == boatName.ToLower())
                {
                    newInventory.Add(ITEM.BOAT);
                }
            }

            return newInventory;
        }
        public string GetWeaponName(ITEM WeaponID)
        {
            if (WeaponID == ITEM.NULL)
            {
                weaponName = fistName;
            }
            else if (WeaponID == ITEM.SWORD)
            {
                weaponName = swordName;
            }
            else if (WeaponID == ITEM.BOW)
            {
                weaponName = bowName; //5 attack
            }
            return weaponName;
        }

        public int GetWeaponAttack(ITEM WeaponID)
        {
            if (WeaponID == ITEM.NULL)
            {
                attackMod = fistDamage;
            }
            else if (WeaponID == ITEM.SWORD)
            {
                attackMod = swordDamage;
            }
            else if (WeaponID == ITEM.BOW)
            {
                attackMod = bowDamage;
            }
            return attackMod;
        }

        public string GetItemName(ITEM ItemID)
        {
            if (ItemID == ITEM.NULL)
            {
                itemName = "None"; //nothing
            }
            else if (ItemID == ITEM.POTION)
            {
                itemName = potionName;
            }
            else if (ItemID == ITEM.BOAT)
            {
                itemName = bowName;
            }
            else if (ItemID == ITEM.MONEY)
            {
                itemName = moneyName;
            }
            return itemName;
        }

        public int GetItemPrice(ITEM itemID)
        {
            int price = 0;
            if (itemID == ITEM.NULL)
            {
                price = 0;
            }
            else if (itemID == ITEM.POTION)
            {
                price = potionPrice;
            }
            else if (itemID == ITEM.BOW)
            {
                price = bowPrice;
            }
            else if (itemID == ITEM.SWORD)
            {
                price = swordPrice;
            }
            else if (itemID == ITEM.BOAT)
            {
                price = bowPrice;
            }
            return price;
        }

    }
}
