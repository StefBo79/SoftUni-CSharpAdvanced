using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones = new List<Drone>();
        public int Count => Drones.Count;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public string AddDrone(Drone drone)
        {
            if (Count == Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                if (!string.IsNullOrEmpty(drone.Name) && !string.IsNullOrEmpty(drone.Brand) && drone.Range >= 5 && drone.Range <= 15)
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else
                {
                    return "Invalid drone.";
                }
            }
        }
        public bool RemoveDrone(string name)
        {
            var drone = Drones.FirstOrDefault(d => d.Name == name);

            return Drones.Remove(drone);
        }
        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(x => x.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var drones = new List<Drone>();
            foreach (var drone in Drones.Where(x => x.Range >= range))
            {
                FlyDrone(drone.Name);
                drones.Add(drone);
            }
            return drones;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in Drones.Where(x => x.Available))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}