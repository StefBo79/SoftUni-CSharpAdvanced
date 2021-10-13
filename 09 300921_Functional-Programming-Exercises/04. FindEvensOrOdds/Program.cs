using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> IsEven = number => number % 2 == 0;
            List<int> numbers = new List<int>();
            Action<int[]> printIntegers = inputNumbers => Console.WriteLine(string.Join(" ", inputNumbers));

            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            string evenOdd = Console.ReadLine();
            if (evenOdd == "even")
            {
                //Console.WriteLine(string.Join(" ", numbers.Where(x => IsEven(x))));
                printIntegers(numbers.Where(x => IsEven(x)).ToArray());
            }
            else
            {
                //Console.WriteLine(string.Join(" ", numbers.Where(x => !IsEven(x))));
                printIntegers(numbers.Where(x => !IsEven(x)).ToArray());
            }
        }
    }
}
