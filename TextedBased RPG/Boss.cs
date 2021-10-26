using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Boss : Enemy
    {
        public Boss(Random random) : base(random)
        {
            maxHealth = Global.BOSS_HEALTH;
            health = maxHealth;
            alive = true;
            name = Global.BOSS_NAME;
            attack = Global.BOSS_ATTACK;
            Avatar = Global.BOSS_AVATAR;
        }
    }
}
