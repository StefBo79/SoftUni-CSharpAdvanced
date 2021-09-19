using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = commands[0];
            int s = commands[1];
            int x = commands[2];

            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count <= 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Contains(x) ? "true" : $"{numbers.Min()}");
            }
        }
    }
}
