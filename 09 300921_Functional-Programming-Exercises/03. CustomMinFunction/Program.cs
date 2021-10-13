using System;
using System.Linq;

namespace _03._CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getSmallestNumber = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                return minValue;
            };

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(getSmallestNumber(inputNumbers));
        }
    }
}
