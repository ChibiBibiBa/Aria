using Raylib_cs;
using Aria.templates;
using Aria.Systems.Collision;
using System.Numerics;

namespace Aria.GameObjects
{
    public interface IGameObject
    {
        Vector2D Position { get; set; }
        IHitbox Hitbox { get; set; }

        void Move();
    }

    public abstract class GameObject : IGameObject
    {
        public string DebugName = "GameObject";
        private Vector2D _position;
        public Vector2D Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Hitbox.SetPosition(_position.X, _position.Y);
            }
        }
        public IHitbox Hitbox { get; set; }

        public GameObject(Vector2D position, Vector2D size)
        {
            this._position = position;
            this.Hitbox = new Hitbox(position.X, position.Y, size.X, size.Y);
            CollisionManager.RegisterHitbox(this);
        }

        public abstract void Move();
        public void SetDebugName(string dn)
        {
            DebugName = dn;
        }
    }

}