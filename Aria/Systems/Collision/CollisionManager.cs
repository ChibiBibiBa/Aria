using Aria.templates;
using Raylib_cs;

namespace Aria.Systems.Collision
{

    public class CollisionManager
    {
        private static CollisionManager? _instance;
        public static CollisionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new();
                }
                return _instance;
            }
        }

        public bool CheckCollision(IGameObject Collider, IGameObject Collidee)
        {
            return Raylib.CheckCollisionRecs(Collider.Collider, Collidee.Collider);
        }
    }
}