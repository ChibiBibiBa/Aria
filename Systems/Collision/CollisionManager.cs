using Aria.GameObjects;
using Aria.GameObjects.Entities.Enemies;
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

                    CollideTwo(first, second);
                }
            }
        }
        public static void CollideTwo(GameObject first, GameObject second)
        {
            Rectangle a = first.Hitbox.ToRectangle();
            Rectangle b = second.Hitbox.ToRectangle();

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
                    SetCollision(first.Hitbox.CollisionLeft, second);
                }
                else
                {
                    SetCollision(first.Hitbox.CollisionRight, second);
                }
            }
            else
            {
                if (dy > 0)
                {
                    SetCollision(first.Hitbox.CollisionTop, second);
                }
                else
                {
                    SetCollision(first.Hitbox.CollisionDown, second);
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

        public static void SetCollision(CollisionEntry first, GameObject second)
        {
            first.Colliding = true;
            if (second is Prop)
            {
                first.Target = CollidingWith.Enviroment;
            }
            if (second is Enemy)
            {
                first.Target = CollidingWith.Enemy;
            }
        }

    }
}