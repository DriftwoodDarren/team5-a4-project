using System;
using System.Data;
using System.Linq.Expressions;
using System.Numerics;
using Team_5_2D_Game_Assignment;

namespace MohawkGame2D
{
    public class Game
    {
        public float score;
        public string scoreText;

        // Setup Screen Variables
        public bool runningGame;
        Texture2D backGround = Graphics.LoadTexture("../ ../../../Assests/Images/start_screen.jpg");

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

            ResetGameState();

        }

        public void Update()
        {
            if (!runningGame)
            {
                Text.Color = Color.White;
                Graphics.Draw(backGround, Window.Width / 2, Window.Height / 2);
                Text.Draw("Press SpaceBar to Start!", 200, 200); 
                
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                    runningGame = true;
                }
            }
            else
            {
                // Score updates
                score += 1 * Time.DeltaTime;
                int intScore = (int)score;
                scoreText = intScore.ToString();

                //Clear background
                Window.ClearBackground(Color.OffWhite);

                // Move player based on spacebar input
                bool jumpPressed = Input.IsKeyboardKeyDown(KeyboardInput.Space);
                player.Move(jumpPressed);

                // Check for collision
                //if (Collision.Check(player, obstacle))
                // {
                //    // Reset score on collision
                //    score = 0;
                // }
                // ^ Use this spot for collision update call

                // Draw Elements
                DrawPlayer();
                DrawScore();
            }
            
        }

        public void DrawPlayer()
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
            runningGame = false;
        }
    }
}
