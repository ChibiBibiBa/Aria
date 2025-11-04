using System.Numerics;
using Aria.GameObjects;
using Raylib_cs;
using Aria.templates;

namespace Aria.Systems.Movement
{
    public static class MovementManager
    {
        private static List<KinematicObject> kinematicObjects = new List<KinematicObject>();

        public static void Register(KinematicObject k)
        {
            kinematicObjects.Add(k);
        }

        public static void MoveAll()
        {
            foreach (var k in kinematicObjects)
            {
                MoveAndCollide(k);
            }
        }

        public static void MoveAndSlide(IGameObject o, Vector2D velocity) { }
        public static void MoveAndCollide(KinematicObject o)
        {
            var hitbox = o.Hitbox;
            Vector2D velocity = new Vector2D(o.Velocity);
            if (hitbox.CollisionLeft.Colliding && velocity.X < 0)
            {
                velocity.X = 0;
            }
            else if (hitbox.CollisionRight.Colliding && velocity.X > 0)
            {
                velocity.X = 0;
            }

            if (hitbox.CollisionDown.Colliding && velocity.Y < 0)
            {
                velocity.Y = 0;
            }
            else if (hitbox.CollisionTop.Colliding && velocity.Y > 0)
            {
                velocity.Y = 0;
            }
            o.SetVelocity(velocity);
            o.Move();
        }
        public static void Move(IGameObject o, Vector2D velocity) { }
        public static void MoveAndBounce(IGameObject o, Vector2D velocity) { }

    }
}