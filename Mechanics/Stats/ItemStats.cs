using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria.Mechanics.Stats
{
    public class ItemStats
    {
        public int Attack { get; private set; }

        public int Health { get; private set; }

        public ItemStats(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }
}
