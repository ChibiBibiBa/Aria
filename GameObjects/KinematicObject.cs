using Aria.templates;

using Aria.GameObjects;

namespace Aria.GameObjects
{
    public class KinematicObject : GameObject
    {
        public float Speed { get; private set; } = 0f;
        public float Acceleration { get; private set; } = 0f;
        public float MaxSpeed { get; private set; } = 0f;
        public float Weight { get; private set; } = 1f;
        public float Gravity { get; private set; } = 1f;

        
        public KinematicObject(Vector2D position, Vector2D size) : base(position,size) { }

        public override void MoveTo(Vector2D newPosition)
        {
            this.Position += newPosition;
        }
    }
}
