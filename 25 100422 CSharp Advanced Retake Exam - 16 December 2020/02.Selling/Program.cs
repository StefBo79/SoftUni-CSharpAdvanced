using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] bakery = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    bakery[row, col] = currentRow[col];
                    if (bakery[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int dollars = 0;

            while (dollars < 50)
            {
                string move = Console.ReadLine();

                if (move == "up")
                {
                    bakery[playerRow, playerCol] = '-';
                    playerRow -= 1;

                    if (playerRow < 0)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(bakery[playerRow, playerCol]))
                    {
                        dollars += int.Parse(bakery[playerRow, playerCol].ToString());
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (bakery[playerRow, playerCol] == 'O')
                    {
                        bakery[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (bakery[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }
                        playerRow = rowO;
                        playerCol = colO;
                        bakery[playerRow, playerCol] = 'S';
                    }
                }
                else if (move == "down")
                {
                    bakery[playerRow, playerCol] = '-';
                    playerRow += 1;

                    if (playerRow >= n)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(bakery[playerRow, playerCol]))
                    {
                        dollars += int.Parse(bakery[playerRow, playerCol].ToString());
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (bakery[playerRow, playerCol] == 'O')
                    {
                        bakery[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (bakery[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }
                        playerRow = rowO;
                        playerCol = colO;
                        bakery[playerRow, playerCol] = 'S';
                    }
                }
                else if (move == "right")
                {
                    bakery[playerRow, playerCol] = '-';
                    playerCol += 1;

                    if (playerCol >= n)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(bakery[playerRow, playerCol]))
                    {
                        dollars += int.Parse(bakery[playerRow, playerCol].ToString());
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (bakery[playerRow, playerCol] == 'O')
                    {
                        bakery[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (bakery[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }
                        playerRow = rowO;
                        playerCol = colO;
                        bakery[playerRow, playerCol] = 'S';
                    }
                }
                else if (move == "left")
                {
                    bakery[playerRow, playerCol] = '-';
                    playerCol -= 1;

                    if (playerCol < 0)
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(bakery[playerRow, playerCol]))
                    {
                        dollars += int.Parse(bakery[playerRow, playerCol].ToString());
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (bakery[playerRow, playerCol] == 'O')
                    {
                        bakery[playerRow, playerCol] = '-';
                        int rowO = -1;
                        int colO = -1;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (bakery[row, col] == 'O')
                                {
                                    rowO = row;
                                    colO = col;
                                }
                            }
                        }
                        playerRow = rowO;
                        playerCol = colO;
                        bakery[playerRow, playerCol] = 'S';
                    }
                }
            }

            if (dollars >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {dollars}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(bakery[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
