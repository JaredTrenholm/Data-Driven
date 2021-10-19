using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class FriendlyNPC
    {
        public string dialogue;
        public int x;
        public int y;



        public FriendlyNPC(int xPos, int yPos, string dialogue)
        {
            x = xPos;
            y = yPos;
            this.dialogue = dialogue;

        }

        public void Draw()
        {
            Renderer.RenderData[y, x] = "F";
        }
        public void Talk()
        {
            Console.Clear();
            Console.WriteLine("You encountered a friendly traveler. Here is what they had to say.");
            Console.WriteLine();
            Console.WriteLine(dialogue);
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
