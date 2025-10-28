using Aria.testing;
using Raylib_cs;

namespace Aria.Systems.Movement
{
    public class MovementManager
    {
        private float speed = 700f;

        private static MovementManager? _instance;
        public static MovementManager Instance
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

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public void MovePlayer(Player player)
        {
            
        }

    }
}