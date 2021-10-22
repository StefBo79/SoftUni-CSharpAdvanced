using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    /*
•	Name: string
•	Type: string
•	Laps: int
•	Capacity: int - the maximum allowed number of participants in the race
•	MaxHorsePower: int - the maximum allowed Horse Power of a Car in the Race
    */
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }

        public int Count => Participants.Count;

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        // the maximum allowed number of participants in the race
        public int Capacity { get; set; }

        // the maximum allowed Horse Power of a Car in the Race
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            // FindParticipant(car.LicensePlate) == null
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) &&
                Capacity >= Participants.Count + 1 &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString().TrimEnd());
            }

            return sb.ToString();
        }
    }
}