using System.Numerics;
using Aria.templates;
using Raylib_cs;

namespace Aria.Systems.Movement
{
    public class Accelerator
    {
        private Vector2D PreviousDirections = new Vector2D(0, 0);
        private float PreviousSpeed = 0f;
        private float MaxSpeed = 0f;
        private float Acceleration = 0f;

        public Accelerator(float maxSpeed, float acceleration)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
        }

        public float Accelerate(Vector2D directions, float speed)
        {
            if (PreviousDirections == directions)
            {
                speed = PreviousSpeed + Acceleration * Raylib.GetFrameTime();
                if (speed > MaxSpeed)
                {
                    speed = MaxSpeed;
                }
            }
            PreviousSpeed = speed;
            PreviousDirections = directions;

            return speed;
        }
    }
}