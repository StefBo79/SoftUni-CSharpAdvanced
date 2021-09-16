using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] inputArgs = input.Split(' ');
                string action = inputArgs[0];

                if (action == "add")
                {
                    numbers.Push(int.Parse(inputArgs[1]));
                    numbers.Push(int.Parse(inputArgs[2]));
                }

                if (action == "remove")
                {
                    int countToRemove = int.Parse(inputArgs[1]);
                    if (numbers.Count >= countToRemove)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}