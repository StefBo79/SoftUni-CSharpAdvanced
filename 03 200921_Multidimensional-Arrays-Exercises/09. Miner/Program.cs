using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[size, size];
            int[] minerIndex = new int[2];
            int coalCounter = 0;

            for (int i = 0; i < size; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = char.Parse(row[j]);
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] == 's')
                    {
                        minerIndex[0] = i;
                        minerIndex[1] = j;
                    }
                }
            }

            foreach (var c in command)
            {
                if (c == "up")
                {
                    minerIndex[0] -= 1;
                    if (minerIndex[0] < 0)
                    {
                        minerIndex[0] += 1;
                    }
                }

                if (c == "down")
                {
                    minerIndex[0] += 1;
                    if (minerIndex[0] >= field.GetLength(0))
                    {
                        minerIndex[0] -= 1;
                    }
                }

                if (c == "left")
                {
                    minerIndex[1] -= 1;
                    if (minerIndex[1] < 0)
                    {
                        minerIndex[1] += 1;
                    }
                }

                if (c == "right")
                {
                    minerIndex[1] += 1;
                    if (minerIndex[1] >= field.GetLength(1))
                    {
                        minerIndex[1] -= 1;
                    }
                }

                if (field[minerIndex[0], minerIndex[1]] == 'c')
                {
                    coalCounter++;
                    field[minerIndex[0], minerIndex[1]] = '*';
                    var query = from char element in field where element == 'c' select element;
                    if (!query.Any())
                    {
                        Console.WriteLine($"You collected all coals! ({minerIndex[0]}, {minerIndex[1]})");
                        return;
                    }
                }

                else if (field[minerIndex[0], minerIndex[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerIndex[0]}, {minerIndex[1]})");
                    return;
                }
            }

            var coals = from char element in field where element == 'c' select element;
            Console.WriteLine($"{coals.Count()} coals left. ({minerIndex[0]}, {minerIndex[1]})");
        }        
    }
}
