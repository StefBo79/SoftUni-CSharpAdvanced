using System;
using System.Collections.Generic;

namespace _08._TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    int count = cars.Count;

                    for (int i = 0; i < (count < n ? count : n); i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                    }

                    command = Console.ReadLine();
                    continue;
                }
                cars.Enqueue(command);
                command = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
