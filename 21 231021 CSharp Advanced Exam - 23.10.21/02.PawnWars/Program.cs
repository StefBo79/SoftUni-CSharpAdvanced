using System;

namespace _02._Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] classboard = new string[8, 8];
            for (int i = 7; i >= 0; i--)
            {
                string row = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    classboard[i, col] = row[col].ToString();
                }
            }
            while (true)
            {
                int rowW = GetRow(classboard, "w");
                int colW = GetCol(classboard, "w");
                int rowB = GetRow(classboard, "b");
                int colB = GetCol(classboard, "b");
                char letterCol = '\0';
                if (colW + 1 < 8 && colW - 1 >= 0)
                {
                    if (classboard[rowW + 1, colW + 1] == "b" || classboard[rowW + 1, colW - 1] == "b")
                    {
                        letterCol = GetLetterCol(classboard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }
                else if (colW + 1 < 8 && colW - 1 < 0)
                {
                    if (classboard[rowW + 1, colW + 1] == "b")
                    {
                        letterCol = GetLetterCol(classboard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }
                else if (colW + 1 >= 8 && colW - 1 >= 0)
                {
                    if (classboard[rowW + 1, colW - 1] == "b")
                    {
                        letterCol = GetLetterCol(classboard, colB);
                        Console.WriteLine($"Game over! White capture on {letterCol}{rowW + 2}.");
                        break;
                    }
                }
                classboard[rowW, colW] = "-";
                rowW += 1;
                if (rowW == 7)
                {
                    letterCol = GetLetterCol(classboard, colW);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {letterCol}{rowW + 1}.");
                    break;
                }
                classboard[rowW, colW] = "w";
                classboard[rowB, colB] = "-";
                if (colB + 1 < 8 && colB - 1 >= 0)
                {
                    if (classboard[rowB - 1, colB - 1] == "w" || classboard[rowB - 1, colB] == "w")
                    {
                        letterCol = GetLetterCol(classboard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                else if (colB + 1 < 8 && colB - 1 < 0)
                {
                    if (classboard[rowB - 1, colB + 1] == "w")
                    {
                        letterCol = GetLetterCol(classboard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                else if (colB + 1 >= 8 && colB - 1 >= 0)
                {
                    if (classboard[rowB - 1, colB - 1] == "w")
                    {
                        letterCol = GetLetterCol(classboard, colW);
                        Console.WriteLine($"Game over! Black capture on {letterCol}{rowB}.");
                        break;
                    }
                }
                rowB -= 1;
                if (rowB == 0)
                {
                    letterCol = GetLetterCol(classboard, colB);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letterCol}{rowB + 1}.");
                    break;
                }
                classboard[rowB, colB] = "b";
            }
        }

        private static char GetLetterCol(string[,] classboard, int colW)
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

        private static int GetCol(string[,] classboard, string v)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (classboard[row, col] == v)
                    {
                        return col;
                    }
                }
            }
            return 0;
        }

        private static int GetRow(string[,] classboard, string v)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (classboard[row, col] == v)
                    {
                        return row;
                    }
                }
            }
            return 0;
        }
    }
}