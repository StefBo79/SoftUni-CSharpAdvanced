using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCubs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(inputCubs);
            Stack<int> bottles = new Stack<int>(inputBottles);

            int wastedLitters = 0;
            bool isNewOne = true;
            int currentCup = 0;

            while (cups.Any() && bottles.Any())
            {

                if (isNewOne)
                {
                    currentCup = cups.Peek();
                    isNewOne = false;
                }                
                int currentBottle = bottles.Pop();

                if (currentCup - currentBottle <= 0)
                {
                    wastedLitters += currentCup - currentBottle;
                    cups.Dequeue();
                    isNewOne = true;
                }
                else
                {
                    currentCup -= currentBottle;                    
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {Math.Abs(wastedLitters)}");
        }
    }
}
