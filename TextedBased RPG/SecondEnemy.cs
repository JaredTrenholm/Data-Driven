using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class SecondEnemy : Enemy
    {

        public SecondEnemy(Random random) : base(random)
        {

            maxHealth = Global.SECOND_HEALTH;
            health = maxHealth;
            alive = true;
            name = Global.SECOND_NAME;
            attack = Global.SECOND_ATTACK;
            Avatar = Global.SECOND_AVATAR;
        }
    }
}
