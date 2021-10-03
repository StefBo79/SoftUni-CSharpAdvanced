using System;
using System.Linq;

namespace _02._SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];
            int counter = 0;

            for (int row = 0; row < size[0]; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && 
                        matrix[row, col] == matrix[row + 1, col] && 
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
