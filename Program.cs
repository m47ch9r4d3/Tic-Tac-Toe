using System;

namespace TicTacToeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doYouWantToPlay = true;
            while (doYouWantToPlay)
            {
                Console.WriteLine("Welcome to Tic Tac Toe! \nYou are about to go against the master of Tic Tac Toe\nAre you ready? I hope so! \nBUT FIRST, you must pick which character you want to be");
                Console.WriteLine();
                Console.WriteLine("Enter a single character that will represent you on the board.");
                char playerToken = Console.ReadLine()[0];
                Console.WriteLine("Enter a single character that will represent your oponent.");
                char opponentToken = Console.ReadLine()[0];
                TicTacToe game = new TicTacToe(playerToken, opponentToken);
                AI ai = new AI();

                ///
                ///set up the game
                ///
                Console.WriteLine();
                Console.WriteLine("Now we can start the game.\nTo play, enter a number and your token \nshall be put in it's place.\nThe numbers go from 1 - 9, top left to bottom right. We shall see who will win this round.");
                game.printBoard(true);
                Console.WriteLine();

                while (!game.IsGameOver())
                {
                    if (game.CurrentMarker == game.UserMarker)
                    {
                        Console.WriteLine("It's your turn! Enter a spot for your token.");
                        int spot = int.Parse(Console.ReadLine());
                        while (!game.IsPlayValid(spot))
                        {
                            Console.WriteLine($"Try again. {spot} is invalid. This spot is already taken, or it is out of range.");
                            spot = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine($"You picked {spot}!");
                        game.SetMarker(spot);
                    }
                    else
                    {
                        Console.WriteLine($"It's my turn!");
                        int aiSpot = ai.PickSpot(game);
                        Console.WriteLine($"I picked {aiSpot}!");
                        game.SetMarker(aiSpot);
                    }

                    Console.WriteLine();
                    game.printBoard(false);
                }

                Console.WriteLine();

                Console.WriteLine("Do you want to play again?\nEnter Y if you do.\nEnter anything else if you don't.");
                char response = Console.ReadLine()[0];
                doYouWantToPlay = (response == 'Y');
            }
        }
    }    
}
