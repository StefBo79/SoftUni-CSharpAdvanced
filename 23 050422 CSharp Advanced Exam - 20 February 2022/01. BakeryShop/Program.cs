using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountOfWater = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            var amountOfFlour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();
            bakedProducts.Add("Croissant", 0);
            bakedProducts.Add("Muffin", 0);
            bakedProducts.Add("Baguette", 0);
            bakedProducts.Add("Bagel", 0);

            while (amountOfWater.Count > 0 && amountOfFlour.Count > 0)
            {
                var water = amountOfWater.Peek();
                var flour = amountOfFlour.Peek();

                var mixedWaterFlour = water + flour;
                var ratio = water * 100 / mixedWaterFlour;

                if (ratio == 50)
                {
                    bakedProducts["Croissant"]++;              
                    amountOfWater.Dequeue();
                    amountOfFlour.Pop();
                }
                else if (ratio == 40)
                {
                    bakedProducts["Muffin"]++;
                    amountOfWater.Dequeue();
                    amountOfFlour.Pop();
                }
                else if (ratio == 30)
                {
                    bakedProducts["Baguette"]++;
                    amountOfWater.Dequeue();
                    amountOfFlour.Pop();
                }
                else if (ratio == 20)
                {
                    bakedProducts["Bagel"]++;
                    amountOfWater.Dequeue();
                    amountOfFlour.Pop();
                }
                else
                {
                    var flourNeeded = water;
                    var flourLeft = flour - flourNeeded;
                    bakedProducts["Croissant"]++;
                    amountOfWater.Dequeue();
                    amountOfFlour.Pop();
                    amountOfFlour.Push(flourLeft);
                }
            }

            bakedProducts = bakedProducts
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var product in bakedProducts)
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
                else
                {
                    continue;
                }                
            }

            if (amountOfWater.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", amountOfWater)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (amountOfFlour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", amountOfFlour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}