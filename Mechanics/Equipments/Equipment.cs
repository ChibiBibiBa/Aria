using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria.Mechanics.Equipments
{
    internal class Equipment
    {
        public int MaxCapacity { get; private set; }
        public List<Item> items { get; private set; } = new List<Item>();
        public Equipment(int maxCapacity) { this.MaxCapacity = maxCapacity; }
        public bool InsertItem(Item item)
        {
            if (MaxCapacity <= items.Count)
            {
                return false;
            }
            items.Add(item);
            return true;
        }
        public bool RemoveItem(Item item)
        {
            return items.Remove(item);
        }
    }
}
