using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[n][];
            for (int i = 0; i < n; i++)
            {
                var chars = string.Concat(Console.ReadLine().Where(c => !char.IsWhiteSpace(c))).ToCharArray();
                jaggedArray[i] = chars;
            }

            int collection = 0;
            int opponentCollection = 0;
            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                int rowPosition = int.Parse(commandArgs[1]);
                int colPosition = int.Parse(commandArgs[2]);

                if (action == "Find" && ValidPosition(jaggedArray, rowPosition, colPosition))
                {
                    if (jaggedArray[rowPosition][colPosition] == 'T')
                    {
                        collection++;
                        jaggedArray[rowPosition][colPosition] = '-';
                    }
                }
                else if (action == "Opponent" && ValidPosition(jaggedArray, rowPosition, colPosition))
                {
                    string direction = commandArgs[3];
                    if (jaggedArray[rowPosition][colPosition] == 'T')
                    {
                        opponentCollection++;
                        jaggedArray[rowPosition][colPosition] = '-';
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (direction == "up")
                        {
                            rowPosition--;
                            if (ValidPosition(jaggedArray, rowPosition, colPosition))
                            {
                                if (jaggedArray[rowPosition][colPosition] == 'T')
                                {
                                    opponentCollection++;
                                    jaggedArray[rowPosition][colPosition] = '-';
                                }
                            }
                        }

                        else if (direction == "down")
                        {
                            rowPosition++;
                            if (ValidPosition(jaggedArray, rowPosition, colPosition))
                            {
                                if (jaggedArray[rowPosition][colPosition] == 'T')
                                {
                                    opponentCollection++;
                                    jaggedArray[rowPosition][colPosition] = '-';
                                }
                            }
                        }

                        else if (direction == "left")
                        {
                            colPosition--;
                            if (ValidPosition(jaggedArray, rowPosition, colPosition))
                            {
                                if (jaggedArray[rowPosition][colPosition] == 'T')
                                {
                                    opponentCollection++;
                                    jaggedArray[rowPosition][colPosition] = '-';
                                }
                            }
                        }

                        else if (direction == "right")
                        {
                            colPosition++;
                            if (ValidPosition(jaggedArray, rowPosition, colPosition))
                            {
                                if (jaggedArray[rowPosition][colPosition] == 'T')
                                {
                                    opponentCollection++;
                                    jaggedArray[rowPosition][colPosition] = '-';
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            //printing:
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }

            Console.WriteLine($"Collected tokens: {collection}");
            Console.WriteLine($"Opponent's tokens: {opponentCollection}");
        }
        public static bool ValidPosition(char[][] jaggedArray, int rowPosition, int colPosition)
        {
            if (rowPosition >= 0 && rowPosition < jaggedArray.Length &&
                colPosition >= 0 && colPosition < jaggedArray[rowPosition].Length)
            {
                return true;
            }

            return false;
        }
    }
}