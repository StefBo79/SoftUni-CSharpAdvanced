using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());

            while (!numbers.All(i => i % 2 == 0))
            {
                if (numbers.Peek() % 2 == 0)
                {
                    numbers.Enqueue(numbers.Dequeue());
                }
                else
                {
                    numbers.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ", numbers.Reverse()));          
        }
    }
}
