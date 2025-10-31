using Raylib_cs;

namespace Aria.Systems.Drawing
{
    public static class DrawingHelper
    {
        public static void DrawRectangle(Rectangle rect, Color color)
        {
            Raylib.DrawRectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, color);
        }
    }
}