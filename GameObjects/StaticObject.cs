using Aria.templates;


namespace Aria.GameObjects
{
    internal class StaticObject : GameObject
    {
        public StaticObject(Vector2D position, Vector2D size):base(position, size) { }

        public override void Move()
        {
            return;
        }
    }
}
