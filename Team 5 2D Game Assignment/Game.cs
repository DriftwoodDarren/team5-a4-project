using System;
using System.Numerics;
using Team_5_2D_Game_Assignment;

namespace MohawkGame2D
{
    public class Game
    {
        public float score;
        private string scoreText;
        private Player player;
        private Obstacle obstacle;
        private float platformHeight = 300; 

        public Game()
        {
            player = new Player(new Vector2(50, platformHeight), platformHeight);
            obstacle = new Obstacle(new Vector2(400, platformHeight));
        }

        public void Setup()
        {
            Window.SetTitle("Mohawk2D Dino Game");
            Window.SetSize(400, 400);
            Window.TargetFPS = 60;
        }

        public void Update()
        {
            // Score increases over time
            score += 1 * Time.DeltaTime;
            scoreText = ((int)score).ToString();

            // Clear screen
            Window.ClearBackground(Color.OffWhite);

            // Handle player movement
            bool jumpPressed = Input.IsKeyboardKeyDown(KeyboardInput.Space);
            player.Move(jumpPressed);

            // Move obstacle
            obstacle.Move();

            // Check for collision
            if (obstacle.CheckCollision(player))
            {
                score = 0; // Reset score on collision
            }

            // Draw elements
            DrawPlatform();
            player.Render();
            obstacle.Render();
            DrawScore();
        }

        private void DrawPlatform()
        {
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(0, platformHeight + 20, 400, 10);
        }

        private void DrawScore()
        {
            Draw.FillColor = Color.Black;
            Text.Draw("Score: " + scoreText, 10, 10);
        }
    }
}
