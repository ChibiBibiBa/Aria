using Aria.GameObjects.Entities;

namespace Aria.Mechanics.Abilities
{
    public class DamagingAbilityContext : AbilityContext
    {
        public readonly bool isCrit;
        public DamagingAbilityContext(float amount, bool isCrit, Entity target, Entity sender) : base(amount, target, sender)
        {
            this.isCrit = isCrit;
        }
    }
}