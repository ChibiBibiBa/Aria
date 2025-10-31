namespace Aria.Systems.Collision
{
    public class CollisionEntry
    {
        public bool Colliding { get; set; } = false;
        public CollidingWith Target { get; set; } = CollidingWith.None;

        public void Reset()
        {
            Colliding = false;
            Target = CollidingWith.None;
        }
    }
}