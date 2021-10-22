using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            
            int wastedFood = 0;
            int stillHungry = 0;

            while (guestCapacity.Count > 0 && plates.Count > 0)
            {
                var guest = guestCapacity.Peek();
                var plate = plates.Peek();

                if (stillHungry != 0)
                {
                    guest = stillHungry;
                }                

                if (plate > guest)
                {
                    wastedFood += plate - guest;
                    plates.Pop();
                    guestCapacity.Dequeue();                    
                    stillHungry = 0;
                }
                else if (plate == guest)
                {
                    plates.Pop();
                    guestCapacity.Dequeue();
                    stillHungry = 0;
                }
                else if (guest > plate)
                {
                    guest -= plate;
                    plates.Pop();
                    stillHungry = guest;
                    continue;
                }
                
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (guestCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestCapacity)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
