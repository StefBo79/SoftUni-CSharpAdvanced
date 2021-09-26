using System;

namespace _05._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string[] firstLineParts = firstLine.Split(", ");
            int rows = int.Parse(firstLineParts[0]);
            int cols = int.Parse(firstLineParts[1]);

            int[,] numbers = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                string[] lineParts = line.Split(", ");
                for (int col = 0; col < cols; col++)
                {
                    numbers[row, col] = int.Parse(lineParts[col]);
                }
            }

            long maxValue = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < numbers.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 1; col++)
                {
                    var sum = numbers[row, col] + numbers[row, col + 1] + 
                        numbers[row + 1, col] + numbers[row + 1, col + 1];

                    if (sum > maxValue )
                    {
                        maxValue = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = maxSumRow; row < maxSumRow + 2; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 2; col++)
                {
                    Console.Write(numbers[row, col] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine(maxValue);
            
        }
    }
}
