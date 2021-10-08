using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(inputNumber))
                {
                    numbers.Add(inputNumber, 0);
                }

                numbers[inputNumber]++;
            }

            //int number = numbers.Where(x => x.Value % 2 == 0).FirstOrDefault().Key;
            //int number = numbers.FirstOrDefault(x => x.Value % 2 == 0).Key;

            foreach (var (key, value) in numbers)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(key);
                    break;
                }
            }
        }
    }
}
