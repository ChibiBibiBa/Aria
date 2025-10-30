using Aria.GameObjects;
using Aria.templates;


namespace Aria.Entities.Player
{
    public class Player : GameObject
    {
        public float MovementSpeed { get; private set; } = 400f;
        public float DashSpeedModifier { get; private set; } = 2f;
        public PlayerMovement Movement { get; private set; }
        public Player(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position, size)
        {
            Movement = new PlayerMovement(this);
        }
    }
}