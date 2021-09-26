using System;
using System.Linq;

namespace _01._SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                    sum += row[j];
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, matrixSize));
            Console.WriteLine(sum);
        }
    }
}