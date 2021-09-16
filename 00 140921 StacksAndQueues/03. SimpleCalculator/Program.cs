using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> calk = new Stack<string>(input);

            while (calk.Count > 1)
            {
                int a = int.Parse(calk.Pop());                
                string op = calk.Pop();
                int b = int.Parse(calk.Pop());

                if (op == "+")
                {
                    calk.Push((a + b).ToString());
                }
                else
                {
                    calk.Push((a - b).ToString());
                }
            }

            Console.WriteLine(calk.Pop());
        }
    }
}
