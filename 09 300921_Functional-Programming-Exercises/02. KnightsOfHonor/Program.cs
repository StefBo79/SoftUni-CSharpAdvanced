using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> PrintCollection = input => input.ForEach(x => Console.WriteLine($"Sir {x}"));

            List<string> input = Console.ReadLine().Split().ToList();

            PrintCollection(input);
        }
    }
}
