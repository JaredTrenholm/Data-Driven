using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class NPCManager
    {
        private FriendlyNPC[] npcs = new FriendlyNPC[999];
        private int npcCount = 0;

        public void CreateNPC(int x, int y, string dialogue)
        {
            npcs[npcCount] = new FriendlyNPC(x,y,dialogue);
            npcCount += 1;
        }
        public FriendlyNPC LocateNPC(int x, int y)
        {
            FriendlyNPC npcTarget = null;
            for (int z = 0; z < npcCount; z++)
            {
                if ((npcs[z].x == x) && (npcs[z].y == y))
                {
                    npcTarget = npcs[z];
                }
            }
            return npcTarget;
        }
        public void Draw()
        {
            for (int z = 0; z < npcCount; z++)
            {
                npcs[z].Draw();
            }
        }
    }
}
