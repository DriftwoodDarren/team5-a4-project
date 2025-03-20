// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using Team_5_2D_Game_Assignment;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        
        // score variables
        public float score;
        public string scoreText;

        // class declarations
        private Player player;

        //Constructor
        public Game()
        {
            player = new Player(new Vector2(50, 200)); // Initialize player at start position
            //obstacle = new Obstacle(new Vector2(380, 200)); Use for obstacle constructor
        }

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {

            Window.SetTitle("Dinosaur Game");
            Window.SetSize(400, 400);
            Draw.LineColor = Color.Black;
            Window.TargetFPS = 60;

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
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

        public void DrawPlayer()
        {
            // Draw the player
            Draw.FillColor = Color.Red;
            Draw.Rectangle(player.position.X, player.position.Y, 20, 20);
        }

        //public void DrawObstacle()
        //{
        //    // Draw the obstacle (box)
        //    Draw.FillColor = Color.White;
        //   Draw.Rectangle(obstacle.position.X, obstacle.position.Y, 20, 20);
        //} ^^ Draw function for obstacle

        public void DrawScore()
        {
            // Draw the score at the top of the screen
            Draw.FillColor = Color.White;
            Text.Draw("Score: ", 10, 10);
            Text.Draw(scoreText, 120, 10);
        }

    }

}
