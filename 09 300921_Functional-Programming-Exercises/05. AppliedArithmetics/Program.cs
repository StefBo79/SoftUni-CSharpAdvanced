using System;
using System.Linq;

namespace _05._AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                }

                return numbers;
            };
            Func<int[], int[]> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] -= 1;
                }

                return numbers;
            };
            Func<int[], int[]> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }

                return numbers;
            };           
            Action<int[]> printNumbers = numbers => Console.WriteLine(string.Join(" ", numbers));

            int[] inputNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    add(inputNumber);
                }
                else if (command == "subtract")
                {
                    subtract(inputNumber);
                }
                else if (command == "multiply")
                {
                    multiply(inputNumber);
                }
                else if (command == "print")
                {
                    printNumbers(inputNumber);
                }

                command = Console.ReadLine();
            }
        }
    }
}
