using System;
using Raylib_cs;

namespace Aria.templates
{
    public interface IGameObject
    {
        Vector2D Position { get; set; }
        GameObjectTags[] Tags { get; set; }
        Rectangle Collider { get; set; }
    }

    public class GameObject : IGameObject
    {

        private Vector2D _position;
        public Vector2D Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Collider = new Rectangle(_position.X, _position.Y, Collider.Width, Collider.Height);
            }
        }
        public GameObjectTags[] Tags { get; set; }
        public Rectangle Collider { get; set; }

        public GameObject(Vector2D position, GameObjectTags[] tags, Vector2D size)
        {
            this._position = position;
            this.Tags = tags;
            this.Collider = new Rectangle(position.X, position.Y, size.X, size.Y);
        }

    }

}