using Raylib_cs;
using Aria.templates;
using Aria.Systems.Drawing;
using Aria.Systems.Collision;
using System.Numerics;
using Aria.GameObjects.Entities.Player;
using Aria.GameObjects.Enviroment;
using Aria.Systems.Movement;
using Aria.Context;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);
            // Raylib.InitWindow(800, 800, "Aria");
            Raylib.InitWindow(ContextData.Window.Width, ContextData.Window.Height, "Aria");
            ContextData.Window.UpdateSize();

            Player player = new Player(new Vector2D((ContextData.Window.Width / 2) + 25, (ContextData.Window.Height / 2) + 25), new Vector2D(50, 50));

            ContextData.SetPlayer(player);

            Prop house = new Prop(new Vector2D(700, 700), new Vector2D(400, 120));
            house.SetDebugName("House");
            Prop tree = new Prop(new Vector2D(500, 200), new Vector2D(75, 75));


            Camera2D camera = new Camera2D();
            camera.Offset = new Vector2(ContextData.Window.Width / 2, ContextData.Window.Height / 2);
            camera.Rotation = 0f;
            camera.Zoom = 1f;

            Prop BorderNorth = new Prop(new Vector2D(0, -1), new Vector2D(ContextData.Window.Width, 1));
            Prop BorderSouth = new Prop(new Vector2D(0, ContextData.Window.Height), new Vector2D(ContextData.Window.Width, 1));
            Prop BorderEast = new Prop(new Vector2D(ContextData.Window.Width, 0), new Vector2D(1, ContextData.Window.Height));
            Prop BorderWest = new Prop(new Vector2D(-1, 0), new Vector2D(1, ContextData.Window.Height));


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
                Raylib.DrawText($"Player collisions: top: {player.Hitbox.CollisionTop.Colliding} left:{player.Hitbox.CollisionLeft.Colliding} right:{player.Hitbox.CollisionRight.Colliding} bottom:{player.Hitbox.CollisionDown.Colliding} colliding:{player.Hitbox.IsColliding}", 0, 0, 25, Color.Pink);

                Raylib.EndDrawing();

                player.Controller.PlayerMovementInput();


                CollisionManager.CollideAll();

                MovementManager.MoveAll();

                camera.Target = player.Position.ToClassicVector();

            }
            Raylib.CloseWindow();
        }
    }
}