using System;
using System.IO;
using System.Linq;

namespace _06._JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rowSize][];

            for (int r = 0; r < rowSize; r++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();

                matrix[r] = col;
            }
            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (command == "Add")
                {
                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row][col] += value;
                    }                    
                }

                if (command == "Subtract")
                {
                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }                    
                }

                line = Console.ReadLine();
            }

            for (int i = 0; i < rowSize; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
