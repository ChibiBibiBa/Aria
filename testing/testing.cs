using Aria.templates;
using Aria.GameObjects;
using Raylib_cs;

namespace Aria.testing
{

    public class StaticObject : GameObject
    {

        public StaticObject(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position, size)
        {
        }
    }

}