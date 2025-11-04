using Aria.templates;
using Raylib_cs;

namespace Aria.Systems.Collision
{
    public interface IHitbox
    {
        Vector2D Center { get; }
        CollisionEntry CollisionTop { get; set; }
        CollisionEntry CollisionRight { get; set; }
        CollisionEntry CollisionLeft { get; set; }
        CollisionEntry CollisionDown { get; set; }
        bool IsColliding { get; set; }
        Rectangle ToRectangle();
        void SetPosition(float X, float Y);
    }

    public class Hitbox : IHitbox
    {
        private float x;
        private float y;
        private float height;
        private float width;
        public float X { get => x; private set => x = value; }
        public float Y { get => y; private set => y = value; }
        public float Height { get => height; private set => height = value; }
        public float Width { get => width; private set => width = value; }
        public CollisionEntry CollisionTop { get; set; } = new CollisionEntry();
        public CollisionEntry CollisionRight { get; set; } = new CollisionEntry();
        public CollisionEntry CollisionLeft { get; set; } = new CollisionEntry();
        public CollisionEntry CollisionDown { get; set; } = new CollisionEntry();
        public bool IsColliding
        {
            get
            {
                return CollisionTop.Colliding || CollisionRight.Colliding || CollisionLeft.Colliding || CollisionDown.Colliding;
            }
            set
            {
                CollisionTop.Colliding = value;
                CollisionRight.Colliding = value;
                CollisionLeft.Colliding = value;
                CollisionDown.Colliding = value;
            }
        }

        public Hitbox(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public Vector2D Center
        {
            get
            {
                return new Vector2D(Width / 2, Height / 2);
            }
        }


        public Rectangle ToRectangle()
        {
            return new Rectangle(x, y, width, height);
        }
        public void SetPosition(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

    }


}