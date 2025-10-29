using System.Numerics;

namespace Aria.templates
{
    public interface IVector
    {
        float X
        {
            get; set;
        }
    }
    public interface IVector2D : IVector
    {
        float Y { get; set; }
    }

    public struct Vector2D : IVector2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2D(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector2D(Vector2D vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }

        public void Set(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }
    }

    public static class VectorHelper
    {
        public static Vector2D Normalize(Vector2D vector)
        {
            float lenght = MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (lenght > 0)
            {
                vector.X /= lenght;
                vector.Y /= lenght;
            }

            return vector;
        }
    }


}
