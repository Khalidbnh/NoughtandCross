using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtandCross
{
    internal class Program
    {
        static char[,] board = new char[3, 3]; // The Tic Tac Toe tablero
        static int currentPlayer = 1;


        static void Main(string[] args)
        {
            InitializeBoard();
            checkGameStatut();
        }

        // Function to initialize the board
        static void InitializeBoard()
        {
            char number = '1';

            // boucle de row y col
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = number;
                    number++; 
                }
            }
        }

        // Function to start game
        static void checkGameStatut()
        {
            int turns = 0;
            bool isGameWon = false;

            while (isGameWon == false && turns < 9) // Loop until a player wins or it's a draw (9 turns)
            {
                DisplayBoard();
                Console.WriteLine($"\nJugador {currentPlayer} ({GetPlayerSymbol(currentPlayer)}), Elige tu movimiento (1-9): ");

                int choice = int.Parse(Console.ReadLine());

                if (MakeMove(choice))
                {
                    turns++;
                    isGameWon = CheckWin();

                    if (isGameWon)
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine($"\nJugador {currentPlayer} ({GetPlayerSymbol(currentPlayer)}) ha ganado!");
                        Console.ReadKey();

                    }
                    else if (turns == 9)
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine("\nEs un empate!");
                        Console.ReadKey();
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento no válido. Inténtalo de nuevo..");
                    Console.ReadKey(); // Pause for user to read the message
                    //Debug.WriteLine()
                }
            }
        }



        // Function to display the board
        static void DisplayBoard()
        {
            Console.WriteLine("       |       |       ");
            Console.WriteLine($"   {board[0, 0]}   |   {board[0, 1]}   |   {board[0, 2]}   ");
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine($"   {board[1, 0]}   |   {board[1, 1]}   |   {board[1, 2]}   ");
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine($"   {board[2, 0]}   |   {board[2, 1]}   |   {board[2, 2]}   ");
            Console.WriteLine("       |       |       ");

        }

        // Function to get the player's symbol (X for Player 1, O for Player 2)
        static char GetPlayerSymbol(int player)
        {
            return player == 1 ? 'X' : 'O';
        }

        // Function to make a move on the board
        static bool MakeMove(int position)
        {
            
            if (position < 1 || position > 9)
            {
                return false; // Invalid position
            }

            // Calculate row and column using arithmetic
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            // Check if the spot is already taken
            if (board[row, col] == 'X' || board[row, col] == 'O')
            {
                return false; // The position is already taken
            }

            // Mark the board with the current player's symbol
            board[row, col] = GetPlayerSymbol(currentPlayer);
            return true;
        }

        // Function to switch between players
        static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1; // Switch between Player 1 (X) and Player 2 (O)
        }       

        // Function to check if there's a winner
        static bool CheckWin()
        {
            char Symbolplayer = GetPlayerSymbol(currentPlayer);
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == Symbolplayer && board[row, 1] == Symbolplayer && board[row, 2] == Symbolplayer)
                {                    
                    return true;

                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == Symbolplayer && board[1, col] == Symbolplayer && board[2, col] == Symbolplayer)
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == Symbolplayer && board[1, 1] == Symbolplayer && board[2, 2] == Symbolplayer) ||
                (board[0, 2] == Symbolplayer && board[1, 1] == Symbolplayer && board[2, 0] == Symbolplayer))
            {
                return true;
            }

            return false;


        }

    }
}
