using Aria.templates;
using Raylib_cs;
using Aria.Systems.Clocks;
using Aria.Systems.Movement;


namespace Aria.GameObjects.Entities.Player
{
    public class PlayerController
    {
        private Player player;
        private Clock dashCooldown = new Clock(0.5f);
        private Clock dashDuration = new Clock(0.2f);
        private Vector2D Directions = new Vector2D(0, 0);
        private Accelerator accelerator;
        public PlayerController(Player player)
        {
            this.player = player;
            accelerator = new Accelerator(player.MaxSpeed, player.Acceleration);
        }

        public void MovePlayer()
        {
            UpdateClocks();
            GetMovementInputs();

            float speedModifier = 1f;

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift) && !dashCooldown.Ongoing && !dashDuration.Ongoing)
            {
                dashCooldown.Start();
                dashDuration.Start();
            }

            


            float TotalSpeed = player.Speed;

            if (!dashDuration.Ongoing)
            {
                TotalSpeed = accelerator.Accelerate(Directions, TotalSpeed);
            }
            else
            {
                speedModifier += player.DashSpeedModifier;
                TotalSpeed = player.Speed * speedModifier;
            }


            TotalSpeed *= Raylib.GetFrameTime();
            Directions = VectorHelper.Normalize(Directions);


            player.ApplyVelocity(new Vector2D(Directions.X * TotalSpeed, Directions.Y * TotalSpeed));


            Directions.X = 0;
            Directions.Y = 0;
        }
        private void GetMovementInputs()
        {
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                Directions.X += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                Directions.X -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                Directions.Y -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                Directions.Y += 1;
            }
        }
        private void UpdateClocks()
        {
            dashCooldown.Update();
            dashDuration.Update();
        }
        private void ApplyMovement(Vector2D velocity)
        {
            player.Position = new Vector2D(velocity);
        }

    }
}