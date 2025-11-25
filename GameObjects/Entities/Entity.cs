using Aria.GameObjects;
using Aria.Mechanics.Stats;
using Aria.templates;
using Aria.Mechanics.Abilities;

namespace Aria.GameObjects.Entities
{
    public class Entity : KinematicObject
    {

        public EntityStats Stats { get; private set; }
        public bool Alive { get; private set; } = true;
        public bool Invulnerable { get; private set; } = false;

        public Entity(Vector2D position, Vector2D size) : base(position, size)
        {
            this.Stats = new(0, 0, 0);
        }
        public void DealDamage() { }
        public void Heal() { }
        public void Kill() { }

        public List<HealingAbilityHook> onHealingCast { get; private set; } = new();
        public List<DamagingAbilityHook> onAttack { get; private set; } = new();
        public List<DefensiveAbilityHook> onHit { get; private set; } = new();

        public void AddOnHit(DefensiveAbilityHook ability)
        {
            this.onHit.Add(ability);
        }

        public void AddOnAttack(DamagingAbilityHook ability)
        {
            this.onAttack.Add(ability);
        }

        public void AddOnHealingCast(HealingAbilityHook ability)
        {
            this.onHealingCast.Add(ability);
        }

    }

}