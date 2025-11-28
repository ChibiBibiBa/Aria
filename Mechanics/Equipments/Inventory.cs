namespace Aria.Mechanics.Equipments
{
    public class Inventory
    {

        public int MaxCapacity { get; private set; }
        public List<Item> items { get; private set; } = new List<Item>();

        public Inventory(int MaxCapacity)
        {
            this.MaxCapacity = MaxCapacity;
        }


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