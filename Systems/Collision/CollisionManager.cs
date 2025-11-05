using Aria.GameObjects;
using Aria.GameObjects.Enviroment;
using Raylib_cs;

namespace Aria.Systems.Collision
{
    public static class CollisionManager
    {
        private static List<GameObject> objects = new List<GameObject>();

        public static void RegisterHitbox(GameObject hitbox)
        {
            objects.Add(hitbox);
        }

        public static void CollideAll()
        {
            ResetCollision();
            int lenght = objects.Count;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    var first = objects[i];
                    var second = objects[j];

                    CollideTwo(first.Hitbox, second.Hitbox);
                    if (first.Hitbox.IsColliding)
                    {
                        CheckCollisionType(first, second);
                    }
                }
            }
        }
        public static void CollideTwo(IHitbox first, IHitbox second)
        {
            Rectangle a = first.ToRectangle();
            Rectangle b = second.ToRectangle();

            if (!Raylib.CheckCollisionRecs(a, b))
                return;

            float aCenterX = a.X + a.Width * 0.5f;
            float aCenterY = a.Y + a.Height * 0.5f;
            float bCenterX = b.X + b.Width * 0.5f;
            float bCenterY = b.Y + b.Height * 0.5f;

            float dx = aCenterX - bCenterX;
            float dy = aCenterY - bCenterY;

            float overlapX = (a.Width + b.Width) * 0.5f - MathF.Abs(dx);
            float overlapY = (a.Height + b.Height) * 0.5f - MathF.Abs(dy);

            if (overlapX < overlapY)
            {
                if (dx > 0)
                {
                    first.CollisionLeft.Colliding = true;
                }
                else
                {
                    first.CollisionRight.Colliding = true;
                }
            }
            else
            {
                if (dy > 0)
                {
                    first.CollisionDown.Colliding = true;
                }
                else
                {
                    first.CollisionTop.Colliding = true;
                }
            }
        }

        public static void ResetCollision()
        {
            foreach (var hitbox in objects)
            {
                hitbox.Hitbox.IsColliding = false;
            }
        }

        public static void CheckCollisionType(GameObject first, GameObject second)
        {
            if (first.Hitbox.CollisionTop.Colliding)
            {
                if (second is Prop)
                {
                    first.Hitbox.CollisionDown.Target = CollidingWith.Enviroment;
                }
            }
        }

    }
}