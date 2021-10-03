using System;
using System.Linq;

namespace _05._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, cols];
            bool isLeftToRight = true;
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                if (isLeftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter++];
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeftToRight = true;
                }
                
            }

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
