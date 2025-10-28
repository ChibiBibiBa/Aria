using Aria.templates;
using Aria.testing;
using Raylib_cs;
using Aria.Systems.Clocks;


namespace Aria.Systems.Movement
{
    public class PlayerMovement
    {
        private Player player;
        private float movementSpeed = 400f;
        private float dashSpeedModifier = 2.5f;

        private Clock dashCooldown = new Clock(0.75f);
        private Clock dashDuration = new Clock(0.25f);

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

            var oldPosition = player.Position;
            var TotalSpeed = movementSpeed * speedModifier * Raylib.GetFrameTime();
            Directions = VectorHelper.Normalize(Directions);
            player.Position = new Vector2D(oldPosition.X + Directions.X * TotalSpeed, oldPosition.Y + Directions.Y * TotalSpeed);
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

    }
}