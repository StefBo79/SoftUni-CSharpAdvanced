using System;

namespace _02._PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] chessBoard = new string[8, 8];

            for (int i = 7; i >= 0; i--)
            {
                string row = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    chessBoard[i, col] = row[col].ToString();
                }
            }

            while (true)
            {
                int rowW = GetRow(chessBoard, "w");
                int colW = GetCol(chessBoard, "w");
                int rowB = GetRow(chessBoard, "b");
                int colB = GetCol(chessBoard, "b");
                char letterCol = '\0';

                if (colW + 1 < 8 && colW - 1 >= 0)
                {
                    if (chessBoard[rowW + 1, colW + 1] == "b" || chessBoard[rowW + 1, colW - 1] == "b")
                    {
                        letterCol = GetLetterCol(chessBoard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }
                else if (colW + 1 < 8 && colW - 1 < 0)
                {
                    if (chessBoard[rowW + 1, colW + 1] == "b")
                    {
                        letterCol = GetLetterCol(chessBoard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }
                else if (colW + 1 >= 8 && colW - 1 >= 0)
                {
                    if (chessBoard[rowW + 1, colW - 1] == "b")
                    {
                        letterCol = GetLetterCol(chessBoard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }

                chessBoard[rowW, colW] = "-";
                rowW += 1;
                if (rowW == 7)
                {
                    letterCol = GetLetterCol(chessBoard, colW);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {letterCol}{rowW + 1}.");
                    break;
                }
                chessBoard[rowW, colW] = "w";
                chessBoard[rowB, colB] = "-";
                if (colB + 1 < 8 && colB - 1 >= 0)
                {
                    if (chessBoard[rowB - 1, colB - 1] == "w" || chessBoard[rowB - 1, colB] == "w")
                    {
                        letterCol = GetLetterCol(chessBoard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                else if (colB + 1 < 8 && colB - 1 < 0)
                {
                    if (chessBoard[rowB - 1, colB + 1] == "w")
                    {
                        letterCol = GetLetterCol(chessBoard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                else if (colB + 1 >= 8 && colB - 1 >= 0)
                {
                    if (chessBoard[rowB - 1, colB - 1] == "w")
                    {
                        letterCol = GetLetterCol(chessBoard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                rowB -= 1;
                if (rowB == 0)
                {
                    letterCol = GetLetterCol(chessBoard, colB);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letterCol}{rowB + 1}.");
                    break;
                }
                chessBoard[rowB, colB] = "b";
            }
        }

        private static int GetRow(string[,] board, string v)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == v)
                    {
                        return row;
                    }
                }
            }
            return 0;
        }

        private static int GetCol(string[,] board, string v)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == v)
                    {
                        return col;
                    }
                }
            }
            return 0;
        }

        private static char GetLetterCol(string[,] board, int colW)
        {
            if (colW == 0)
            {
                return 'a';
            }
            else if (colW == 1)
            {
                return 'b';
            }
            else if (colW == 2)
            {
                return 'c';
            }
            else if (colW == 3)
            {
                return 'd';
            }
            else if (colW == 4)
            {
                return 'e';
            }
            else if (colW == 5)
            {
                return 'f';
            }
            else if (colW == 6)
            {
                return 'g';
            }
            else if (colW == 7)
            {
                return 'h';
            }
            return '\0';
        }
    }
}