using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Game
    {
        public int GameId { get; private set; }
        // Highest value encountered of Red Green Blue
        public int MaxR { get; private set; }
        public int MaxG { get; private set; }
        public int MaxB { get; private set; }

        // Maximum allowed values for a game to be 'possible'
        private int AllowedRed = 12;
        private int AllowedGreen = 13;
        private int AllowedBlue = 14;
        public Game(int id)
        {
            GameId = id;
        }
        public Game(int id, int red, int green, int blue)
        {
            GameId = id;
            MaxR = red;
            MaxG = green;
            MaxB = blue;
        }
        // Adds a given cube draw to the game knowledge
        public void AddCubeDraw(int red, int green, int blue)
        {
            // Update maximums
            if (red > MaxR)
                MaxR = red;
            if (green > MaxG)
                MaxG = green;
            if (blue > MaxB)
                MaxB = blue;
        }

        public bool Possible()
        {
            return (MaxR <= AllowedRed && MaxG <= AllowedGreen && MaxB <= AllowedBlue);
        }

        public int GetPower()
        {
            return MaxR * MaxG * MaxB;
        }
    }
}
