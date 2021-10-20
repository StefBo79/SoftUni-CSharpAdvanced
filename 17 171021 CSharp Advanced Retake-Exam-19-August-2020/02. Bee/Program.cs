using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] territory = new char[n][];

            for (int i = 0; i < n; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                territory[i] = chars;
            }
            int pollFlowers = 0;
            int beeRow = 0;
            int beeCol = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < territory[i].Length; j++)
                {
                    if (territory[i][j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                territory[beeRow][beeCol] = '.';
                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);               

                if (!IsInside(beeRow, beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (territory[beeRow][beeCol] == 'f')
                {
                    pollFlowers++;
                }
                else if (territory[beeRow][beeCol] == 'O')
                {
                    territory[beeRow][beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);
                    if (territory[beeRow][beeCol] == 'f')
                    {
                        pollFlowers++;
                    }
                    if (!IsInside(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }                         

                territory[beeRow][beeCol] = 'B';
                command = Console.ReadLine();
            }

            if (pollFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollFlowers} flowers more");
            }

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < territory[i].Length; j++)
                {
                    Console.Write(territory[i][j]);
                }
                Console.WriteLine();
            }
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }
            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col  + 1;
            }
            return col;
        }
        public static bool IsInside(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }
}