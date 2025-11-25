using Aria.GameObjects.Entities;

namespace Aria.Mechanics.Abilities
{
    public class HealingAbilityContext : AbilityContext
    {
        public HealingAbilityContext(float amount, Entity target, Entity sender) : base(amount, target, sender)
        {
        }
    }
}