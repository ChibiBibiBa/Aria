using Aria.GameObjects.Entities;

namespace Aria.Mechanics.Abilities
{
    public class DefensiveAbilityContext : AbilityContext
    {
        public DefensiveAbilityContext(float amount,  Entity target, Entity sender) : base(amount, target, sender)
        {
        }
    }
}