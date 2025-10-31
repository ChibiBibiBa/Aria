using System;
using Raylib_cs;
using Aria.templates;
using Aria.Systems.Drawing;
using Aria.Systems.Collision;
using System.Numerics;
using Aria.Entities.Player;
using Aria.GameObjects;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = Raylib.GetMonitorWidth(0);
            var height = Raylib.GetMonitorHeight(0);

            Player player = new Player(new Vector2D((1920 / 2) + 25, (1080 / 2) + 25), new Vector2D(50, 50));

            StaticObject tree = new StaticObject(new Vector2D(500, 200),  new Vector2D(75, 75));
            StaticObject house = new StaticObject(new Vector2D(700, 700),  new Vector2D(400, 120));

            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);

            Camera2D camera = new Camera2D();
            camera.Offset = new Vector2(1920 / 2, 1080 / 2);
            camera.Rotation = 0f;
            camera.Zoom = 1f;

            StaticObject BorderNorth = new StaticObject(new Vector2D(0, -1), new Vector2D(1920, 1));
            StaticObject BorderSouth = new StaticObject(new Vector2D(0, 1080),  new Vector2D(1920, 1));
            StaticObject BorderEast = new StaticObject(new Vector2D(1920, 0), new Vector2D(1, 1080));
            StaticObject BorderWest = new StaticObject(new Vector2D(-1, 0),  new Vector2D(1, 1080));

            Raylib.InitWindow(width, height, "Aria");
            // Raylib.InitWindow(200, 200, "Aria");

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();
                Raylib.BeginMode2D(camera);
                Raylib.ClearBackground(Color.Black);

                DrawingHelper.DrawRectangle(tree.Hitbox.ToRectangle(), Color.Green);

                DrawingHelper.DrawRectangle(player.Hitbox.ToRectangle(), Color.Blue);

                DrawingHelper.DrawRectangle(house.Hitbox.ToRectangle(), Color.Orange);

                Raylib.EndMode2D();
                Raylib.EndDrawing();

                CollisionManager.CollideAll();

                player.Controller.MovePlayer();
                camera.Target = player.Position.ToClassicVector();

            }
            Raylib.CloseWindow();
        }
    }
}