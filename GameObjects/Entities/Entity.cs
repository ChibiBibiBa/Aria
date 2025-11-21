using Aria.GameObjects;
using Aria.Mechanics.Stats;
using Aria.templates;

namespace Aria.GameObjects.Entities
{
    public class Entity : KinematicObject
    {

        public EntityStats Stats { get; private set; }

        public bool Alive { get; private set; } = true;
        public bool Invulnerable { get; private set; } = false;

        public Entity(Vector2D position, Vector2D size, EntityStats stats) : base(position, size)
        {
            this.Stats = stats;
        }
        public void DealDamage() { }
        public void Heal() { }
        public void Kill() { }
    }
}