using System;
using System.Linq;

namespace _06._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                double[] inputIntegers = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[i] = inputIntegers;                
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;

                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (!(row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length))
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}
