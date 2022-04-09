using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            var steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int gladius = 0;
            int shamshir = 0;
            int katana = 0;
            int sabre = 0;
            int broadsword = 0;
            int totalNumberOfSwords = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                var currentSteel = steel.Peek();
                var currentCarbon = carbon.Peek();
                var forge = currentSteel + currentCarbon;

                if (forge == 70)
                {
                    gladius++;
                    totalNumberOfSwords++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (forge == 80)
                {
                    shamshir++;
                    totalNumberOfSwords++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (forge == 90)
                {
                    katana++;
                    totalNumberOfSwords++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (forge == 110)
                {
                    sabre++;
                    totalNumberOfSwords++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (forge == 150)
                {
                    broadsword++;
                    totalNumberOfSwords++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    currentCarbon += 5;
                    carbon.Pop();
                    carbon.Push(currentCarbon);
                }
            }

            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");                
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");                
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (broadsword > 0)
            {
                Console.WriteLine($"Broadsword: {broadsword}");
            }
            if (gladius > 0)
            {
                Console.WriteLine($"Gladius: {gladius}");
            }
            if (katana > 0)
            {
                Console.WriteLine($"Katana: {katana}");
            }
            if (sabre > 0)
            {
                Console.WriteLine($"Sabre: {sabre}");
            }
            if (shamshir > 0)
            {
                Console.WriteLine($"Shamshir: {shamshir}");
            }
        }
    }
}
