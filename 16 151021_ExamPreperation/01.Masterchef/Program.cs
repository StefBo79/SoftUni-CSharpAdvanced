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
            
            //int dippingSause = 0, int greenSalad = 0, int chokolateCake = 0, int lobster = 0;
            int dippingSause = 0;
            int greenSalad = 0;
            int chokolateCake = 0;
            int lobster = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {

                var ingredient = ingredients.Peek();
                var fresh = freshness.Peek();
                var freshnessLevel = fresh * ingredient;

                if (freshnessLevel == 150)
                {
                    dippingSause++;
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
                    chokolateCake++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (freshnessLevel == 400)
                {
                    lobster++;
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

            if (dippingSause > 0 && greenSalad > 0 && chokolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                Console.WriteLine($"# Chocolate cake --> {chokolateCake}");
                Console.WriteLine($"# Dipping sauce --> {dippingSause}");
                Console.WriteLine($"# Green salad --> {greenSalad}");
                Console.WriteLine($"# Lobster --> {lobster}");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                if (chokolateCake > 0)
                {
                    Console.WriteLine($"# Chocolate cake --> {chokolateCake}");
                }
                if (dippingSause > 0)
                {
                    Console.WriteLine($"# Dipping sauce --> {dippingSause}");
                }
                if (greenSalad > 0)
                {
                    Console.WriteLine($"# Green salad --> {greenSalad}");
                }
                if (lobster > 0)
                {
                    Console.WriteLine($"# Lobster --> {lobster}");
                }
            }
        }
    }
}