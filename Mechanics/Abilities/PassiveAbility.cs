using System.Runtime.CompilerServices;

namespace Aria.Mechanics.Abilities
{
    public abstract class PassiveAbility
    {
        public readonly string Name = "";
        public readonly string Description = "";

        protected PassiveAbility(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            Effect = (AbilityContext context) => { return context; };
        }

        public AbilityHook Effect { get; private set; }
    }
}