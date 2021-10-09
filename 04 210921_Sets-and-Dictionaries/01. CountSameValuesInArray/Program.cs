using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();            

            foreach (var num in numbers)
            {
                if (!count.ContainsKey(num))
                {
                    count.Add(num, 0);
                }
                
                count[num]++;
            }

            foreach (var num in count)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
