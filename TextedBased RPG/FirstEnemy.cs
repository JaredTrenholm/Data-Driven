using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class FirstEnemy : Enemy
    {

        public FirstEnemy(Random random) : base(random)
        {
            maxHealth = Global.FIRST_HEALTH;
            health = maxHealth;
            alive = true;
            name = Global.FIRST_NAME;
            attack = Global.FIRST_ATTACK;
            Avatar = Global.FIRST_AVATAR;

        }
    }
}
