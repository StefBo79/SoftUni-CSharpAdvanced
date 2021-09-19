using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> boxWithClothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int rackCapacity = int.Parse(Console.ReadLine());
            int sumOfClothesOut = 0;
            int countOfracks = 1;

            while (boxWithClothes.Count > 0)
            {

                if (sumOfClothesOut + boxWithClothes.Peek() > rackCapacity)
                {
                    sumOfClothesOut = 0;
                    countOfracks++;
                }

                sumOfClothesOut += boxWithClothes.Pop();
            }

            Console.WriteLine(countOfracks);
        }
    }
}
