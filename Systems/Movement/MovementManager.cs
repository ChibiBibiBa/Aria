using System.Numerics;
using Aria.GameObjects;
using Raylib_cs;
using Aria.templates;

namespace Aria.Systems.Movement
{
    public static class MovementManager
    {

        public static void MoveAndSlide(IGameObject o, Vector2D velocity) { }
        public static void MoveAndCollide(IGameObject o, Vector2D velocity)
        {
            var hitbox = o.Hitbox;
            if (hitbox.CollisionLeft && velocity.X < 0)
            {
                velocity.X = 0;
            }
            else if (hitbox.CollisionRight && velocity.X > 0)
            {
                velocity.X = 0;
            }
            if (hitbox.CollisionDown && velocity.Y < 0)
            {
                velocity.Y = 0;
            }
            else if (hitbox.CollisionTop && velocity.Y > 0)
            {
                velocity.Y = 0;
            }
            o.MoveTo(velocity);
        }
        public static void Move(IGameObject o, Vector2D velocity) { }
        public static void MoveAndBounce(IGameObject o, Vector2D velocity) { }

    }
}