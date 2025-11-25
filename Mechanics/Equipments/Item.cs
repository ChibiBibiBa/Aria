using Aria.Mechanics.Abilities;
using Aria.Mechanics.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria.Mechanics.Equipments
{
    internal class Item : IItem
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public ItemStats Stats { get; private set; }


        public Item(string name, string description, ItemStats stats)
        {
            Name = name;
            Description = description;
            Stats = stats;
        }
    }
}
