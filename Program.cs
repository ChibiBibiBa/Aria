using System;

using Raylib_cs;
using Aria.testing;
using Aria.templates;
using Aria.Systems.Movement;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            float speed = 700f;



            Player player = new Player(new Vector2D(0, 0), [GameObjectTags.Player], new Vector2D(50, 50));

            var MovementManager = new PlayerMovement(player);

            Tree tree = new Tree(new Vector2D(500, 200), [GameObjectTags.Static], new Vector2D(75, 75));

            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);

            Raylib.InitWindow(Raylib.GetMonitorWidth(0), Raylib.GetMonitorHeight(0), "Aria");



            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawRectangle((int)tree.Collider.X, (int)tree.Collider.Y, (int)tree.Collider.Width, (int)tree.Collider.Height, Color.Yellow);

                Raylib.DrawRectangle((int)player.Collider.X, (int)player.Collider.Y, (int)player.Collider.Width, (int)player.Collider.Height, Color.Green);

                Raylib.EndDrawing();

                MovementManager.MovePlayer();

            }
            Raylib.CloseWindow();
        }
    }
}