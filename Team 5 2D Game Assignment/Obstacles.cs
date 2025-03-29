using MohawkGame2D;
using System.Numerics;

namespace Team_5_2D_Game_Assignment
{
    public class Obstacle
    {
        public Vector2 position;
        private float speed = 150f; // Speed of the obstacle

        public Obstacle(Vector2 startPosition)
        {
            position = startPosition;
        }

        public void Move()
        {
            // Move obstacle from right to left
            position.X -= speed * Time.DeltaTime;

            // Reset position if it goes off-screen
            if (position.X < -20)
            {
                position.X = 400; // Reset to the right side
            }
        }

        public bool CheckCollision(Player player)
        {
            // Simple box collision detection
            return (player.position.X < position.X + 20 &&
                    player.position.X + 20 > position.X &&
                    player.position.Y < position.Y + 20 &&
                    player.position.Y + 20 > position.Y);
        }

        public void Render()
        {
            Draw.FillColor = Color.Black;
            Draw.Rectangle(position.X, position.Y, 20, 20);
        }
    }
}
