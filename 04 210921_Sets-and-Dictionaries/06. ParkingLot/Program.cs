using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                string car = commandArgs[1];

                if (direction == "IN")
                {
                    carsNumbers.Add(car);
                }
                else if (direction == "OUT")
                {
                    carsNumbers.Remove(car);
                }

                command = Console.ReadLine();
            }

            if (carsNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            Console.WriteLine(string.Join(Environment.NewLine, carsNumbers));
        }
    }
}
