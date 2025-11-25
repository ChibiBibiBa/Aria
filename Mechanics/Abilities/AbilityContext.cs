using Aria.GameObjects.Entities;

namespace Aria.Mechanics.Abilities
{
    public class AbilityContext
    {
        public readonly float amount;
        public readonly Entity target;
        public readonly Entity sender;
        public float finalAmount = 0f;

        public AbilityContext(float amount, Entity target, Entity sender)
        {
            this.amount = amount;
            this.target = target;
            this.sender = target;
        }
    }
}