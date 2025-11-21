using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria.Mechanics.Stats
{
    public class EntityStats
    {
        public int Attack { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public EntityStats(int attack, int maxHealth, int currentHealth)
        {
            Attack = attack;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}
