using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> claimedItems = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Peek();
                int sumOfItems = firstItem + secondItem;

                if (sumOfItems % 2 == 0)
                {
                    claimedItems.Add(sumOfItems);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondItem);
                    secondLootBox.Pop();
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems.Sum() > 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
