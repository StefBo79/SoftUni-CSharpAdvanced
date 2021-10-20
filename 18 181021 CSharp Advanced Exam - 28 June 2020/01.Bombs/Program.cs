using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEfect = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));
            var bombCasting = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDekoyBombs = 0;

            while (bombEfect.Count > 0 && bombCasting.Count > 0)
            {
                var efect =  bombEfect.Peek();
                var casting = bombCasting.Peek();
                var sum = efect + casting;

                if (sum == 40)
                {
                    daturaBombs++;
                    bombEfect.Dequeue();
                    bombCasting.Pop();
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                    bombEfect.Dequeue();
                    bombCasting.Pop();
                }
                else if (sum == 120)
                {
                    smokeDekoyBombs++;
                    bombEfect.Dequeue();
                    bombCasting.Pop();
                }
                else
                {
                    casting -= 5;
                    bombCasting.Pop();
                    bombCasting.Push(casting);
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDekoyBombs >= 3)
                {
                    break;
                }
            }

            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDekoyBombs >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEfect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEfect)}");
            }

            if (bombCasting.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasting)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDekoyBombs}");
        }
    }
}
