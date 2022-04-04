using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int dippingSauces = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobsters = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                var ingredient = ingredients.Peek();
                var fresh = freshness.Peek();
                var freshnessLevel = ingredient * fresh;

                if (freshnessLevel == 150)
                {
                    dippingSauces++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (freshnessLevel == 250)
                {
                    greenSalad++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (freshnessLevel == 300)
                {
                    chocolateCake++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (freshnessLevel == 400)
                {
                    lobsters++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredient == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    freshness.Pop();
                    ingredient += 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(ingredient);
                }
            }

            if (dippingSauces > 0 && greenSalad > 0 && chocolateCake > 0 && lobsters > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
                Console.WriteLine($"# Dipping sauce --> {dippingSauces}");
                Console.WriteLine($"# Green salad --> {greenSalad}");
                Console.WriteLine($"# Lobster --> {lobsters}");

            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                if (chocolateCake > 0)
                {
                    Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
                }
                if (dippingSauces > 0)
                {
                    Console.WriteLine($"# Dipping sauce --> {dippingSauces}");
                }
                if (greenSalad > 0)
                {
                    Console.WriteLine($"# Green salad --> {greenSalad}");
                }
                if (lobsters > 0)
                {
                    Console.WriteLine($"Lobster -->{lobsters}");
                }
            }
        }
    }
}
