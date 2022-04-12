using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> coords = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            char[,] field = new char[n, n];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int destroyedShips = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (input[col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            while (firstPlayerShips != 0 && secondPlayerShips != 0 && coords.Count != 0)
            {
                int row = coords[0];
                int col = coords[1];

                if (CheckIndex(row, col, n))
                {
                    if (field[row, col] == '#')
                    {
                        Explode(row, col, field, n, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                        field[row, col] = 'X';
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShips--;
                        destroyedShips++;
                        field[row, col] = 'X';
                    }
                    else if (field[row, col] == '<')
                    {
                        firstPlayerShips--;
                        destroyedShips++;
                        field[row, col] = 'X';
                    }
                }
                coords.RemoveAt(0);
                coords.RemoveAt(0);

            }
            if (firstPlayerShips > 0 && secondPlayerShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (secondPlayerShips > 0 && firstPlayerShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (firstPlayerShips > 0 && secondPlayerShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }

        static bool CheckIndex(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        static void Explode(int row, int col, char[,] field, int n,
            ref int firstShips, ref int secondShips, ref int destroyedShips)
        {
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row, col - 1] = 'X';
                }
                else if (field[row, col - 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row, col - 1] = 'X';
                }
            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (field[row - 1, col - 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row - 1, col - 1] = 'X';
                }
                else if (field[row - 1, col - 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row - 1, col - 1] = 'X';
                }
            }
            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row - 1, col] = 'X';
                }
                else if (field[row - 1, col] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row - 1, col] = 'X';
                }
            }
            if (row - 1 >= 0 && col + 1 < n)
            {
                if (field[row - 1, col + 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row - 1, col + 1] = 'X';
                }
                else if (field[row - 1, col + 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row - 1, col + 1] = 'X';
                }
            }
            if (col + 1 < n)
            {
                if (field[row, col + 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row, col + 1] = 'X';
                }
                else if (field[row, col + 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row, col + 1] = 'X';
                }
            }
            if (row + 1 < n && col + 1 < n)
            {
                if (field[row + 1, col + 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row + 1, col + 1] = 'X';
                }
                else if (field[row + 1, col + 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row + 1, col + 1] = 'X';
                }
            }
            if (row + 1 < n)
            {
                if (field[row + 1, col] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row + 1, col] = 'X';
                }
                else if (field[row + 1, col] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row + 1, col] = 'X';
                }
            }
            if (row + 1 < n && col - 1 >= 0)
            {
                if (field[row + 1, col - 1] == '<')
                {
                    firstShips--;
                    destroyedShips++;
                    field[row + 1, col - 1] = 'X';
                }
                else if (field[row + 1, col - 1] == '>')
                {
                    secondShips--;
                    destroyedShips++;
                    field[row + 1, col - 1] = 'X';
                }
            }
        }
    }
}
