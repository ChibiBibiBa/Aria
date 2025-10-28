using Aria.templates;
using Raylib_cs;

namespace Aria.testing
{
    public class Capsule
    {
    }

    public class Player : GameObject
    {
        public Player(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position, tags, size)
        {
        }
    }

    public class Tree : GameObject
    {

        public Tree(Vector2D position, GameObjectTags[] tags, Vector2D size) : base(position, tags, size)
        {
        }
    }

}