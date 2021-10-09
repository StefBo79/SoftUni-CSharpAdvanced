using System;
using System.Linq;

namespace _04._AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersWithVat = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x * 1.2);

            foreach (var number in numbersWithVat)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
