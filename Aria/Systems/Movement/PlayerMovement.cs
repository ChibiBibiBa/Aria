using Aria.templates;
using Aria.testing;
using Raylib_cs;
using Aria.Systems.Clocks;
using Aria.Systems.Collision;
using Aria.Systems.Movement;


namespace Aria.Systems.Movement
{
    public class PlayerMovement
    {
        private Player player;
        private float movementSpeed = 400f;
        private float dashSpeedModifier = 5.5f;

        private Clock dashCooldown = new Clock(0.5f);
        private Clock dashDuration = new Clock(0.1f);

        private Vector2D Directions = new Vector2D(0, 0);
        public PlayerMovement(Player player)
        {
            this.player = player;
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

            if (dashDuration.Ongoing)
            {
                speedModifier = dashSpeedModifier;
            }

            var TotalSpeed = movementSpeed * speedModifier * Raylib.GetFrameTime();
            Directions = VectorHelper.Normalize(Directions);
            Vector2D velocity = new Vector2D(Directions.X * TotalSpeed, Directions.Y * TotalSpeed);

            MovementManager.MoveAndCollide(player, velocity);

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