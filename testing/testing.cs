using Aria.templates;
using Aria.GameObjects;
using Raylib_cs;

namespace Aria.testing
{
    public class Player : GameObject
    {
        public Player(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position,size)
        {
        }
    }

    public class StaticObject : GameObject
    {

        public StaticObject(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position, size)
        {
        }
    }

}