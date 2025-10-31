using Aria.GameObjects;
using Aria.templates;

namespace Aria.GameObjects.Entities
{
    public class Entity : KinematicObject
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public bool Alive { get; private set; } = true;
        public bool Invulnerable { get; private set; } = false;
        public Entity(Vector2D position, Vector2D size) : base(position, size)
        {

        }
        public void DealDamage() { }
        public void Heal() { }
        public void Kill() { }
    }
}