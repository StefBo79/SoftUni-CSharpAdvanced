using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> reverse = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }

            foreach (var item in input)
            {
                Console.Write(reverse.Pop());
            }

            Console.WriteLine();
        }
    }
}