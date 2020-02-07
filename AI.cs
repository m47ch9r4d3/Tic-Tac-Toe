using System;
using System.Collections.Generic;

namespace TicTacToeApplication
{
    public class AI
    {
        public int PickSpot(TicTacToe game)
        {
            List<int> choices = game.GetValidSpots();

            Random rand = new Random();
            int choice = choices[(Math.Abs(rand.Next() % choices.Count))];
            return choice;
        }
    }
}