using Aria.GameObjects;
using Aria.templates;
using Aria.GameObjects.Entities;


namespace Aria.GameObjects.Entities.Player
{
    public class Player : Entity
    {
        public new float Speed { get; private set; } = 300f;
        public new float Acceleration { get; private set; } = 100f;
        public new float MaxSpeed { get; private set; } = 500f;
        public float DashSpeedModifier { get; private set; } = 3f;

        public PlayerController Controller { get; private set; }
        public Player(Vector2D position, Vector2D size) : base(position, size)
        {
            Controller = new PlayerController(this);
        }
    }
}