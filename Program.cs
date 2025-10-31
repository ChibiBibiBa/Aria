using Raylib_cs;
using Aria.templates;
using Aria.Systems.Drawing;
using Aria.Systems.Collision;
using System.Numerics;
using Aria.GameObjects.Entities.Player;
using Aria.GameObjects;
using Aria.Systems.Movement;
using Aria.Context;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);

            Raylib.InitWindow(ContextData.Window.Width, ContextData.Window.Height, "Aria");
            // Raylib.InitWindow(200, 200, "Aria");
            ContextData.Window.UpdateSize();

            Player player = new Player(new Vector2D((ContextData.Window.Width / 2) + 25, (ContextData.Window.Height / 2) + 25), new Vector2D(50, 50));

            ContextData.SetPlayer(player);

            StaticObject tree = new StaticObject(new Vector2D(500, 200), new Vector2D(75, 75));
            StaticObject house = new StaticObject(new Vector2D(700, 700), new Vector2D(400, 120));


            Camera2D camera = new Camera2D();
            camera.Offset = new Vector2(ContextData.Window.Width / 2, ContextData.Window.Height / 2);
            camera.Rotation = 0f;
            camera.Zoom = 1f;

            StaticObject BorderNorth = new StaticObject(new Vector2D(0, -1), new Vector2D(ContextData.Window.Width, 1));
            StaticObject BorderSouth = new StaticObject(new Vector2D(0, ContextData.Window.Height), new Vector2D(ContextData.Window.Width, 1));
            StaticObject BorderEast = new StaticObject(new Vector2D(ContextData.Window.Width, 0), new Vector2D(1, ContextData.Window.Height));
            StaticObject BorderWest = new StaticObject(new Vector2D(-1, 0), new Vector2D(1, ContextData.Window.Height));


            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();
                Raylib.BeginMode2D(camera);
                Raylib.ClearBackground(Color.Black);

                DrawingHelper.DrawRectangle(tree.Hitbox.ToRectangle(), Color.Green);

                DrawingHelper.DrawRectangle(player.Hitbox.ToRectangle(), Color.Blue);

                DrawingHelper.DrawRectangle(house.Hitbox.ToRectangle(), Color.Orange);

                DrawingHelper.DrawRectangle(BorderNorth.Hitbox.ToRectangle(), Color.Red);
                DrawingHelper.DrawRectangle(BorderWest.Hitbox.ToRectangle(), Color.Red);
                DrawingHelper.DrawRectangle(BorderSouth.Hitbox.ToRectangle(), Color.Red);
                DrawingHelper.DrawRectangle(BorderEast.Hitbox.ToRectangle(), Color.Red);

                Raylib.EndMode2D();
                Raylib.EndDrawing();

                player.Controller.MovePlayer();

                CollisionManager.CollideAll();

                MovementManager.MoveAll();

                camera.Target = player.Position.ToClassicVector();

            }
            Raylib.CloseWindow();
        }
    }
}