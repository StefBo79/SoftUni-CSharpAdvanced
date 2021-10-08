using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> table = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {

                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    table.Add(element);
                }
                
            }
            Console.WriteLine(string.Join(" ", table));

        }
    }
}
