using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());

            int[] plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> listOfPlates = new List<int>(plates);

            Stack<int> orcWarriors = new Stack<int>();

            for (int i = 1; i <= orcWaves; i++)
            {
                int[] orcs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                if (listOfPlates.Count == 0)
                {
                    break;
                }

                orcWarriors = new Stack<int>(orcs);
                if (i % 3 == 0)
                {
                    int newLine = int.Parse(Console.ReadLine());
                    listOfPlates.Add(newLine);
                }

                while (listOfPlates.Count != 0 && orcWarriors.Count != 0)
                {
                    if (listOfPlates[0] > orcWarriors.Peek())
                    {
                        listOfPlates[0] -= orcWarriors.Pop();
                    }
                    else if (listOfPlates[0] < orcWarriors.Peek())
                    {
                        int result = orcWarriors.Pop() - listOfPlates[0];
                        orcWarriors.Push(result);
                        listOfPlates.RemoveAt(0);
                    }
                    else if (listOfPlates[0] == orcWarriors.Peek())
                    {
                        listOfPlates.RemoveAt(0);
                        orcWarriors.Pop();
                    }
                }
            }

            if (listOfPlates.Count > 0 && orcWarriors.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                if (listOfPlates.Count > 0)
                {
                    Console.Write("Plates left: ");
                    Console.WriteLine(string.Join(", ", listOfPlates));
                }
            }
            else if (orcWarriors.Count > 0 && listOfPlates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                if (orcWarriors.Count > 0)
                {
                    Console.Write("Orcs left: ");
                    Console.WriteLine(string.Join(", ", orcWarriors));
                }
            }
        }
    }
}
