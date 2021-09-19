using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            Queue<int> bullets = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            
            int bulletsInBarrel = sizeOfBarrel;
            int shotBullets = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                shotBullets++;
                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    bullets.Dequeue();
                    bulletsInBarrel--;                    
                    Console.WriteLine("Bang!");                    
                }
                else
                {
                    bullets.Dequeue();
                    bulletsInBarrel--;
                    Console.WriteLine("Ping!");
                }                

                if (bulletsInBarrel <= 0)
                {
                    if (bullets.Count != 0)
                    {
                        Console.WriteLine("Reloading!");
                        bulletsInBarrel = sizeOfBarrel;
                    }                                      
                    continue;
                }
            }

            if (bullets.Count >= 0 && locks.Count == 0)
            {
                valueOfIntelligence -= bulletPrice * shotBullets;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}