using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> market = new Queue<string>();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    market.Enqueue(input);
                }
                else
                {
                    foreach (var customer in market)
                    {
                        Console.WriteLine(customer);
                    }
                    market.Clear();
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{market.Count} people remaining.");
        }
    }
}
