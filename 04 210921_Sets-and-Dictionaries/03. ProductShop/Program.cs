using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] inputArgs = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
                string shop = inputArgs[0];                
                string product = inputArgs[1];
                double price = double.Parse(inputArgs[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);

                input = Console.ReadLine();
            }

            //var orderedShops = shops.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");                

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
