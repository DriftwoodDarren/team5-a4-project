using MohawkGame2D;
using System.Numerics;

namespace Team_5_2D_Game_Assignment
{
    public class Player
    {
        public Vector2 position;
        private Vector2 velocity;
        private Vector2 gravity = new Vector2(0, 300); 
        private float jumpHeight = 200f;
        private bool isOnGround = true;
        private float groundLevel; 
        Sound JumpSound;

        public Player(Vector2 startPosition, float platformHeight)
        {
            position = startPosition;
            groundLevel = platformHeight; // Set the ground level
            JumpSound = Audio.LoadSound("../../../../Assests/Sounds/Jump.wav");
        }

        public void Move(bool jumpPressed)
        {
            if (jumpPressed && isOnGround)
            {
                isOnGround = false;
                Audio.Play(JumpSound);
                velocity.Y = -jumpHeight; // Jumping up
            }

            // Apply gravity
            velocity.Y += gravity.Y * Time.DeltaTime;

            // Update position
            position.Y += velocity.Y * Time.DeltaTime;

            // Check if landed on the platform
            if (position.Y >= groundLevel)
            {
                position.Y = groundLevel;
                isOnGround = true;
                velocity.Y = 0; // Stop movement after landing
            }
        }

        public void Render()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(position.X, position.Y, 20, 20);
        }

    }
}
