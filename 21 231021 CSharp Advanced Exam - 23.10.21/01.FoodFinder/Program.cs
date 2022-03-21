using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> food = new Dictionary<string, int>();
            food.Add("pear", 0);
            food.Add("flour", 0);
            food.Add("pork", 0);
            food.Add("olive", 0);

            List<char> pear = "pear".ToCharArray().ToList();
            List<char> flour = "flour".ToCharArray().ToList().ToList();
            List<char> pork = "pork".ToCharArray().ToList();
            List<char> olive = "olive".ToCharArray().ToList();

            var vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));

            while (consonants.Count > 0)
            {
                var currentVowels = vowels.Dequeue();
                vowels.Enqueue(currentVowels);
                var currentConsonant = consonants.Pop();

                if (pear.Contains(currentVowels))
                {
                    pear.Remove(currentVowels);
                }
                if (pear.Contains(currentConsonant))
                {
                    pear.Remove(currentConsonant);
                }
                if (flour.Contains(currentVowels))
                {
                    flour.Remove(currentVowels);
                }
                if (flour.Contains(currentConsonant))
                {
                    flour.Remove(currentConsonant);
                }
                if (olive.Contains(currentVowels))
                {
                    olive.Remove(currentVowels);
                }
                if (olive.Contains(currentConsonant))
                {
                    olive.Remove(currentConsonant);
                }
                if (pork.Contains(currentVowels))
                {
                    pork.Remove(currentVowels);
                }
                if (pork.Contains(currentConsonant))
                {
                    pork.Remove(currentConsonant);
                }

                if (pork.Count == 0)
                {
                    food["pork"]++;
                    pork = "pork".ToCharArray().ToList();
                }
                if (olive.Count == 0)
                {
                    food["olive"]++;
                    olive = "olive".ToCharArray().ToList();
                }
                if (flour.Count == 0)
                {
                    food["flour"]++;
                    flour = "flour".ToCharArray().ToList();
                }
                if (pear.Count == 0)
                {
                    food["pear"]++;
                    pear = "pear".ToCharArray().ToList();
                }
            }

            food = food.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Words found: {food.Sum(x => x.Value)}");

            foreach (var word in food)
            {
                Console.WriteLine(word.Key);
            }

        }
    }
}