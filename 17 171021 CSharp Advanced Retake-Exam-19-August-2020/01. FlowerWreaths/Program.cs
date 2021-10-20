using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));
            var roses = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));

            int wreath = 0;
            int storedNumbers = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                var numberRose = roses.Peek();
                var numberLili = lilies.Peek();
                var countWhreth = numberRose + numberLili;

                if (countWhreth == 15)
                {
                    wreath++;
                    roses.Dequeue();
                    lilies.Pop();
                }

                else if (countWhreth > 15)
                {
                    numberLili -= 2;
                    lilies.Pop();
                    lilies.Push(numberLili);
                    continue;
                }

                else if (countWhreth < 15)
                {
                    storedNumbers += numberLili + numberRose;
                    roses.Dequeue();
                    lilies.Pop();                    
                }                              
            }

            while (storedNumbers >= 15)
            {
                storedNumbers -= 15;
                wreath++;
            }

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }
        }
    }
}
