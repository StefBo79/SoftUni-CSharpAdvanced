using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Tire[]> tires = new List<Tire[]>();

            while (command != "No more tires")
            {
                string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Tire> listOfTires = new List<Tire>();

                for (int i = 0; i < splitted.Length; i += 2)
                {
                    int year = int.Parse(splitted[i]);
                    double pressure = double.Parse(splitted[i + 1]);
                    Tire current = new Tire(year, pressure);
                    listOfTires.Add(current);
                }

                tires.Add(listOfTires.ToArray());
                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] splitted = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(splitted[0]);
                double cubicCapacity = double.Parse(splitted[1]);
                Engine current = new Engine(horsePower, cubicCapacity);
                engines.Add(current);

                command = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = info[0];
                string model = info[1];
                int year = int.Parse(info[2]);
                double fuelQuantity = double.Parse(info[3]);
                double fuelConsumption = double.Parse(info[4]);
                int engineIdx = int.Parse(info[5]);
                int tireIdx = int.Parse(info[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIdx], tires[tireIdx]);
                cars.Add(car);

                command = Console.ReadLine();
            }

            cars = cars.Where(x =>
                x.Year >= 2017 && x.Engine.HorsePower > 330 &&
                x.Tires.Sum(x => x.Pressure) >= 9 &&
                x.Tires.Sum(x => x.Pressure) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}