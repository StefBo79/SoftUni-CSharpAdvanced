using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueOfOrders = new Queue<int>();

            foreach (var order in orders)
            {
                queueOfOrders.Enqueue(order);
            }

            int maxOrder = int.MinValue;

            while (queueOfOrders.Count > 0 && quantity > 0)
            {                
                int currentOrder = queueOfOrders.Peek();                

                if (currentOrder > maxOrder)
                {
                    maxOrder = currentOrder;
                }

                if (quantity - currentOrder >= 0)
                {
                    quantity -= currentOrder;
                    queueOfOrders.Dequeue();
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(maxOrder);

            if (queueOfOrders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
