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

        private bool walking = false;
        private bool jumping = false;
        private bool dashing = false;



        public PlayerController(Player player)
        {
            this.player = player;
            accelerator = new Accelerator(player.MaxSpeed, player.Acceleration);
        }

        public void PlayerMovementInput()
        {
            UpdateClocks();
            GetMovementInputs();

            float speedModifier = 1f;

            float TotalSpeed = player.Speed;
            
            TotalSpeed *= Raylib.GetFrameTime();
            // Directions = VectorHelper.Normalize(Directions);


            player.ApplyVelocity(new Vector2D(Directions.X * TotalSpeed, Directions.Y * player.JumpForce * Raylib.GetFrameTime()));


            Directions.X = 0;
            Directions.Y = 0;
        }
        private void GetMovementInputs()
        {
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                Directions.X += 1;
                walking = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                Directions.X -= 1;
                walking = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.Space) && player.OnGround)
            {
                Directions.Y -= 1;
                jumping = true;
            }
        }
        private void UpdateClocks()
        {
            dashCooldown.Update();
            dashDuration.Update();
        }

    }
}