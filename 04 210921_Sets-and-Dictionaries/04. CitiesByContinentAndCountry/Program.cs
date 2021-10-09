using System;
using System.Collections.Generic;

namespace _04._CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = inputArgs[0];
                string country = inputArgs[1];
                string city = inputArgs[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(country, new List<string> {city});
                }
                else
                {
                    if (continents[continent].ContainsKey(country))
                    {
                        continents[continent][country].Add(city);
                    }
                    else
                    {
                        continents[continent].Add(country, new List<string> { city });
                    }
                }                
            }

            foreach (var cont in continents)
            {
                Console.WriteLine($"{cont.Key}:");

                foreach (var country in cont.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
