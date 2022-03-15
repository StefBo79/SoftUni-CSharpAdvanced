using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    field[row, col] = line[col];
                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (field[row, col] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            field[snakeRow, snakeCol] = '.';
            int food = 0;

            while (true)
            {
                if (food >= 10)
                {
                    Console.WriteLine($"You won! You fed the snake.");
                    field[snakeRow, snakeCol] = 'S';
                    break;
                }

                string command = Console.ReadLine();

                if (command == "up")
                {
                    snakeRow--;
                }
                if (command == "down")
                {
                    snakeRow++;
                }
                if (command == "left")
                {
                    snakeCol--;
                }
                if (command == "right")
                {
                    snakeCol++;
                }

                if (!IsSafe(field, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (field[snakeRow, snakeCol] == '*')
                {
                    food++;
                }
                if (field[snakeRow, snakeCol] == 'B')
                {
                    field[snakeRow, snakeCol] = '.';
                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }
                field[snakeRow, snakeCol] = '.';
            }

            Console.WriteLine($"Food eaten: {food}");

            Print(field);
        }

        static bool IsSafe(char[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
