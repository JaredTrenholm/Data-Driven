using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class TownManager
    {
        private Town[] towns = new Town[999];
        private int townCount = 0;

        public void CreateTown(int x, int y,string name, string dialogue)
        {
            towns[townCount] = new Town(x, y, name, dialogue);
            townCount += 1;
        }
        public void SetPlayer(Player player)
        {
            for(int i = 0; i < townCount;i++)
            {
                towns[i].SetPlayer(player);
            }
        }
        public Town LocateTown(int x, int y)
        {
            Town townTarget = null;
            for (int z = 0; z < townCount; z++)
            {
                if ((towns[z].x == x) && (towns[z].y == y))
                {
                    townTarget = towns[z];
                }
            }
            return townTarget;
        }
        public void Draw()
        {
            for (int z = 0; z < townCount; z++)
            {
                towns[z].Draw();
            }
        }
    }
}
