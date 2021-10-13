using System;

namespace _01._ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> PrintCollection = input => Console.WriteLine(string.Join(Environment.NewLine, input));

            string[] input = Console.ReadLine().Split();

            PrintCollection(input);
        }
    }
}
