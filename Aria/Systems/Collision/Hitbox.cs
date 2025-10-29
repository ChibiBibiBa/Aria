using Aria.templates;
using Raylib_cs;

namespace Aria.Systems.Collision
{
    public interface IHitbox
    {
        Vector2D Center { get; }
        bool CollisionTop { get; set; }
        bool CollisionRight { get; set; }
        bool CollisionLeft { get; set; }
        bool CollisionDown { get; set; }
        bool IsColliding { get; set; }
        Rectangle ToRectangle();
        void UpdatePosition(float X, float Y);
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
        public bool CollisionTop { get; set; }
        public bool CollisionRight { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionDown { get; set; }
        public bool IsColliding
        {
            get
            {
                return CollisionTop || CollisionRight || CollisionLeft || CollisionDown;
            }
            set
            {
                CollisionTop = value;
                CollisionRight = value;
                CollisionLeft = value;
                CollisionDown = value;
            }
        }

        public Hitbox(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            CollisionManager.RegisterHitbox(this);
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
        public void UpdatePosition(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void SetCollision(CollidingOn c)
        {
            throw new NotImplementedException();
        }
    }

    public enum CollidingOn
    {
        NotColliding = 0,
        Top,
        Left,
        Down,
        Right,
    }
}