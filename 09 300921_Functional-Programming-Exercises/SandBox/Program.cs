using System;

namespace _01._SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = inputString => Console.WriteLine(inputString);

            print ("Hello, from Action!"); 

            Predicate<int> isEven = number => number % 2 == 0;
            bool isEvenResult = isEven(15);

            Func<int, bool> isOdd = number => number % 2 != 0;
            bool isOddResult = isOdd(22);

            Func<int, int, int> increaseNumber = (integer, power) => integer += power;
            int increaseNumberResult = increaseNumber(10, 20);

            Func<int, string> isEvenOdd = number =>
            {
                if (number % 2 == 0)
                {
                    return "even";
                }

                return "odd";

            };
            string isEvenOrOddResult = isEvenOdd(15);
        }
    }
}
