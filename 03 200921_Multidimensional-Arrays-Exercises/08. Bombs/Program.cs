using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputIntegers[col];
                }
            }

            string[] coords = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < coords.Length; i++)
            {
                string[] coordsArgs = coords[i].Split(",").ToArray();
                int row = int.Parse(coordsArgs[0]);
                int col = int.Parse(coordsArgs[1]);
                int value = matrix[row, col];

                if (matrix[row, col] > 0)
                {
                    if (IsValid(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= matrix[row, col];
                    }

                    if (IsValid(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= matrix[row, col];
                    }

                    matrix[row, col] = 0;
                }

            }

            IEnumerable<int> activeCells = matrix.OfType<int>().Where(value => value > 0);

            Console.WriteLine($"Alive cells: {activeCells.Count()}");
            Console.WriteLine($"Sum: {activeCells.Sum()}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool IsValid(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
