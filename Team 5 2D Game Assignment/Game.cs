﻿// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Dinosaur Game");
            Window.SetSize(400, 400);
            Window.ClearBackground(Color.OffWhite);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {

        }
    }

}
