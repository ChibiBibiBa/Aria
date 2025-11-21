using Aria.templates;

using Aria.GameObjects;
using Aria.Systems.Movement;
using Aria.Systems.Collision;

namespace Aria.GameObjects
{
    public class KinematicObject : GameObject
    {
        public float Speed { get; private set; } = 0f;
        public float Acceleration { get; private set; } = 0f;
        public float MaxSpeed { get; private set; } = 0f;
        public float Weight { get; private set; } = 1f;
        public float Gravity { get; private set; } = 0.25f;
        public float Friction { get; private set; } = 0.85f;
        public Vector2D Velocity { get; private set; }
        public KinematicObject(Vector2D position, Vector2D size) : base(position, size)
        {
            MovementManager.Register(this);
        }

        public void ApplyVelocity(Vector2D velocity)
        {
            this.Velocity += velocity;
        }

        public void SetVelocity(Vector2D velocity)
        {
            this.Velocity = velocity;
        }

        public override void Move()
        {
            this.Position += Velocity;
            Velocity = new Vector2D(0, 0); 
        }
    }
}
