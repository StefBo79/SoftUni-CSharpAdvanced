using System;
using System.Linq;

namespace _04._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string swap = commandArgs[0];                


                if (swap != "swap" || commandArgs.Count() != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    int row1 = int.Parse(commandArgs[1]);
                    int col1 = int.Parse(commandArgs[2]);
                    int row2 = int.Parse(commandArgs[3]);
                    int col2 = int.Parse(commandArgs[4]);

                    if (row1 >= 0 && row1 < matrix.GetLength(0) &&
                        col1 >= 0 && col1 < matrix.GetLength(1) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine();
                        continue;
                    }
                    

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }

                        Console.WriteLine();
                    }

                }

                command = Console.ReadLine();
            }

        }
    }
}
