using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ShopManager
    {
        private ItemManager items;
        private List<Shop> shops = new List<Shop>();
        private List<ITEM> shopStock = new List<ITEM>();

        public ShopManager(ItemManager itemsRef)
        {
            items = itemsRef;
        }

        public void CreateShop(string name, string dialogue, int x, int y, int tax, List<string> inventory)
        {
            shopStock.Clear();
            shopStock = items.FormItemList(inventory);
            shops.Add(new Shop(name, dialogue, x, y, items, shopStock, tax)); // I-0
        }
        public void GivePlayerReference(Player player)
        {
            foreach (Shop shop in shops)
            {
                shop.SetPlayer(player);
            }
        }
        public void Draw()
        {
            foreach (Shop shop in shops)
            {
                shop.Draw();
            }
        }
        public Shop LocateShops(int x, int y)
        {
            foreach(Shop shop in shops)
            {
                if(shop.x == x && shop.y == y)
                {
                    return shop;
                }
            }
            return null;
        }
    }
}
