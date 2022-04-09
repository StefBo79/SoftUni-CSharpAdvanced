using System;
using System.Linq;

namespace _02.Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] armory = new char[n, n];

            int officerRow = 0;
            int officerCol = 0;
            int swordsBought = 0;
            int index = 0;

            string[] coords = new string[2];

            for (int i = 0; i < armory.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    armory[i, j] = input[j];

                    if (armory[i, j] == 'A')
                    {
                        officerRow = i;
                        officerCol = j;
                    }

                    if (armory[i, j] == 'M')
                    {
                        coords[index] = $"{i} {j}";
                        index++;
                    }
                }
            }

            while (true)
            {
                string move = Console.ReadLine();
                armory[officerRow, officerCol] = '-';

                if (move == "up")
                {
                    officerRow--;
                }
                else if (move == "down")
                {
                    officerRow++;
                }
                else if (move == "left")
                {
                    officerCol--;
                }
                else
                {
                    officerCol++;
                }

                if (officerRow >= 0 && officerRow < armory.GetLength(0) && officerCol >= 0 && officerCol < armory.GetLength(1))
                {
                    if (armory[officerRow, officerCol] >= 49 && armory[officerRow, officerCol] <= 57)
                    {
                        swordsBought += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        int[] zero = coords[0].Split(" ").Select(int.Parse).ToArray();
                        int[] one = coords[1].Split(" ").Select(int.Parse).ToArray();

                        if (zero[0] == officerRow && zero[1] == officerCol)
                        {
                            armory[officerRow, officerCol] = '-';

                            officerRow = one[0];
                            officerCol = one[1];
                        }
                        else
                        {
                            armory[officerRow, officerCol] = '-';

                            officerRow = zero[0];
                            officerCol = zero[1];
                        }
                    }

                    armory[officerRow, officerCol] = 'A';

                    if (swordsBought >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
            }

            Console.WriteLine($"The king paid {swordsBought} gold coins.");
            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
