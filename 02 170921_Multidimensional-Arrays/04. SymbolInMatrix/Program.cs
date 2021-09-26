using System;
using System.Linq;

namespace _04._SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            char symbolLookingFor = char.Parse(Console.ReadLine());

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    if (matrix[i, j] == symbolLookingFor)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolLookingFor} does not occur in the matrix");
        }
    }
}
