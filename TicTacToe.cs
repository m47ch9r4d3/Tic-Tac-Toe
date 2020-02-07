using System;
using System.Collections.Generic;

namespace TicTacToeApplication
{
    public class TicTacToe
    {
        private char[] board;

        public char CurrentMarker { get; private set; }
        public char UserMarker { get; private set; }
        public char AiMarker { get; private set; }

        public TicTacToe(char playerToken, char aiMarker)
        {
            this.CurrentMarker = playerToken;
            this.UserMarker = playerToken;
            this.AiMarker = aiMarker;
            this.board = setBoard();
        }

        public static char[] setBoard()
        {
            char[] board = new char[9];
            for (int i = 0; i < board.Length; i++ )
            {
                board[i] = '-';
            }
            return board;
        }

        public void SetMarker(int spot)
        {
            this.board[spot - 1] = this.CurrentMarker;
            this.CurrentMarker = (this.CurrentMarker == this.UserMarker) ? this.AiMarker : this.UserMarker;
        }

        public bool IsPlayValid(int spot)
        {
            return withinRange(spot) && !isSpotTaken(spot);
        }

        public bool withinRange(int number)
        {
            return number > 0 && number < board.Length + 1;
        }

        public bool isSpotTaken(int number)
        {
            return board[number - 1] != '-';
        }

        public List<int> GetValidSpots()
        {
            List<int> choices = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (this.board[i] == '-')
                {
                    choices.Add(i + 1);
                }
            }

            return choices;
        }

        public void printBoard(bool useIndices)
        {
            string divider = "|";
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("------------");
                }

                if (i % 3 != 0)
                {
                    Console.Write(divider);
                }

                string c = useIndices ? $"{i + 1}" : $"{this.board[i]}";
                Console.Write($" {c} ");
            }

            Console.WriteLine();
        }

        public bool Compare3(char a, char b, char c)
        {
            if (a == b && a == c) return true;
            return false;
        }

        public bool IsThereAWinner()
        {
            // If 0,1,2
            // if 3,4,5
            // if 6,7,8
            if (Compare3(board[0], board[1], board[2]) && board[0] != '-') return true;
            if (Compare3(board[3], board[4], board[5]) && board[3] != '-') return true;
            if (Compare3(board[6], board[7], board[8]) && board[6] != '-') return true;

            // if 0,4,8
            // if 6,4,2
            if (Compare3(board[0], board[4], board[8]) && board[0] != '-') return true;
            if (Compare3(board[6], board[4], board[2]) && board[6] != '-') return true;

            // if 0,3,6
            // if 1,4,7
            // if 2,5,8
            if (Compare3(board[0], board[3], board[6]) && board[0] != '-') return true;
            if (Compare3(board[1], board[4], board[7]) && board[1] != '-') return true;
            if (Compare3(board[2], board[5], board[8]) && board[2] != '-') return true;
            return false;
        }
        
        public bool IsTheBoardFilled()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-')
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsGameOver()
        {
            bool didSomeoneWin = IsThereAWinner();
            if (didSomeoneWin)
            {
                this.CurrentMarker = (this.CurrentMarker == this.UserMarker) ? this.AiMarker : this.UserMarker;
                Console.WriteLine($"We have a winner! The winner is {this.CurrentMarker}'s");
                return true;
            }
            else if (this.IsTheBoardFilled())
            {
                Console.WriteLine("Draw! Game Over!");
                return true;
            }

            return false;
        }
    }
}
