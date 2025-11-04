using Aria.GameObjects;
using Aria.templates;
using Raylib_cs;

namespace Aria.Systems.Gravity
{
    public static class GravityManager
    {
        private static readonly float gravity = 500f;
        private static List<KinematicObject> kinematicObjects = new List<KinematicObject>();

        public static void Register(KinematicObject k)
        {
            kinematicObjects.Add(k);
        }

        public static void ApplyGravity()
        {
            foreach (var obj in kinematicObjects)
            {
                if(obj.Hitbox.CollisionDown.Colliding && obj.Hitbox.CollisionDown.Target == Collision.CollidingWith.Enviroment)
                {
                    obj.Airborne = true;
                }
                if (obj.Airborne)
                {
                    continue;
                }
                obj.ApplyVelocity(new Vector2D(0, 1 * gravity * obj.Gravity * Raylib.GetFrameTime()));
            }
        }
    }
}