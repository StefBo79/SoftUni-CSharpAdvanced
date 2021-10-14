using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Comparer<int> compare = Comparer<int>.Create((i, j) =>
            {
                if (i == j)
                    return 0;
                if (i % 2 == 0 && j % 2 != 0)
                    return -1;
                if (i % 2 == 0 && j % 2 == 0)
                    return i < j ? -1 : 1;
                if (i % 2 != 0 && j % 2 != 0)
                    return i < j ? -1 : 1;

                return 1;
            });
            Array.Sort(numbers, compare);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
/*
var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Func<int, int, int> comparator = (number1, number2) =>
    (number1 % 2 == 0 && number2 % 2 != 0) ? -1 :
    (number1 % 2 != 0 && number2 % 2 == 0) ? 1 :
    number1.CompareTo(number2);
Array.Sort<int>(numbers, new Comparison<int>(comparator));
Console.WriteLine(string.Join(" ", numbers));
*/
