using Aria.GameObjects;
using Raylib_cs;

namespace Aria.Systems.Collision
{
    public static class CollisionManager
    {


        public static bool CheckCollision(IGameObject Collider, IGameObject Collidee)
        {
            return Raylib.CheckCollisionRecs(Collider.Hitbox.ToRectangle(), Collidee.Hitbox.ToRectangle());
        }
        private static List<IHitbox> hitboxes = new List<IHitbox>();

        public static void RegisterHitbox(IHitbox hitbox)
        {
            hitboxes.Add(hitbox);
        }

        public static void CollideAll()
        {
            ResetCollision();
            int lenght = hitboxes.Count;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    CollideTwo(hitboxes[i], hitboxes[j]);

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
                    second.CollisionRight.Colliding = true;
                }
                else
                {
                    first.CollisionRight.Colliding = true;
                    second.CollisionLeft.Colliding = true;
                }
            }
            else
            {
                if (dy > 0)
                {
                    first.CollisionDown.Colliding = true;
                    second.CollisionTop.Colliding = true;
                }
                else
                {
                    first.CollisionTop.Colliding = true;
                    second.CollisionDown.Colliding = true;
                }
            }
        }


        public static void ResetCollision()
        {
            foreach (var hitbox in hitboxes)
            {
                hitbox.IsColliding = false;
            }
        }

    }
}