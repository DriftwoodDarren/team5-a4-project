using System.Numerics;
using Team_5_2D_Game_Assignment;

namespace MohawkGame2D
{
    public class Game
    {
        public float score;
        public string scoreText;

        // Setup Screen Variables
        public bool runningGame = false;
        public bool runStartScreen = true;

        // class declarations
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
            if (!runningGame)
            {
                ResetGameState();
            }
            else
            {
                // Score updates
                score += 1 * Time.DeltaTime;
                int intScore = (int)score;
                scoreText = intScore.ToString();

                // Clear screen
                Window.ClearBackground(Color.OffWhite);

                // Handle player movement
                bool jumpPressed = Input.IsKeyboardKeyDown(KeyboardInput.Space);
                player.Move(jumpPressed);

                // Move obstacle
                obstacle.Move();

                // Check for collision
                // If player collides, game stops running - leading to resetGameState
                if (obstacle.CheckCollision(player))
                { 
                    runningGame = false;   
                }

                // Draw elements
                DrawPlatform();
                player.Render();
                obstacle.Render();
                DrawScore();
            }
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

        // Function for Resetting Game 
        public void ResetGameState()
        {
            score = 0;
            Window.ClearBackground(Color.OffWhite);
            Text.Color = Color.Black;
            obstacle.position.X = 400; 
         
            if (runStartScreen)
            {
                Text.Draw("Press Spacebar to Start!", 5 , Window.Height / 2.5f);
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                   
                    // Begins running the game
                    runningGame = true;
                  
                    // When the game ends, else condition activated
                    runStartScreen = false;
                }
            }
            else
            {
                Text.Draw("GAME OVER!", Window.Width / 3, Window.Height / 2.5f);

                // If spacebar pushed, intial If statement true and game fully reset. 
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    runStartScreen = true;
                }
            }
            
        }
    }
}
