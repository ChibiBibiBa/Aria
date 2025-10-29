using System;

using Raylib_cs;
using Aria.testing;
using Aria.templates;
using Aria.Systems.Movement;
using Aria.Systems.Drawing;
using Aria.Systems.Collision;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(new Vector2D(0, 0), [GameObjectTags.Player], new Vector2D(50, 50));

            var MovementManager = new PlayerMovement(player);

            StaticObject tree = new StaticObject(new Vector2D(500, 200), [GameObjectTags.Static], new Vector2D(75, 75));
            StaticObject house = new StaticObject(new Vector2D(700, 700), [GameObjectTags.Static], new Vector2D(120, 400));




            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);

            var width = Raylib.GetMonitorWidth(0);
            var height = Raylib.GetMonitorHeight(0);

            StaticObject BorderNorth = new StaticObject(new Vector2D(0, -1), [GameObjectTags.Static], new Vector2D(1920, 1));
            StaticObject BorderSouth = new StaticObject(new Vector2D(0, 1080), [GameObjectTags.Static], new Vector2D(1920, 1));
            StaticObject BorderEast = new StaticObject(new Vector2D(1920, 0), [GameObjectTags.Static], new Vector2D(1, 1080));
            StaticObject BorderWest = new StaticObject(new Vector2D(-1, 0), [GameObjectTags.Static], new Vector2D(1, 1080));

            Raylib.InitWindow(width, height, "Aria");
            // Raylib.InitWindow(200, 200, "Aria");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                DrawingHelper.DrawRectangle(tree.Hitbox.ToRectangle(), Color.Green);

                DrawingHelper.DrawRectangle(player.Hitbox.ToRectangle(), Color.Blue);

                DrawingHelper.DrawRectangle(house.Hitbox.ToRectangle(), Color.Orange);

                Raylib.EndDrawing();

                CollisionManager.CollideAll();

                MovementManager.MovePlayer();

            }
            Raylib.CloseWindow();
        }
    }
}