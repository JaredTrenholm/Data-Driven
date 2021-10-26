using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ThirdEnemy : Enemy
    {

        public ThirdEnemy(Random random) : base(random)
        {
            maxHealth = Global.THIRD_HEALTH;
            health = maxHealth;
            alive = true;
            name = Global.THIRD_NAME;
            attack = Global.THIRD_ATTACK;
            Avatar = Global.THIRD_AVATAR;
        }
    }
}
