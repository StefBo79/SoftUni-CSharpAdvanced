using System;

namespace _07._KnightGame
{
    class Program
    {        

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] board = new char[rows, rows];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (board[row, col] != 'K')
                        {
                            continue;
                        }

                        if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }                    
                }

                if (maxAttacks == 0)
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
                else
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                }
            }
        }
            

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
