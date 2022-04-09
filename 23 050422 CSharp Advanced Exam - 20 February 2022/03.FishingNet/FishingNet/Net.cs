using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {        
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }
        public List<Fish> Fish = new List<Fish>();
        public int Count => Fish.Count;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return $"Invalid fish.";
            }
            else if (Fish.Count >= Capacity)
            {
                return $"Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(f => f.Weight == weight);
            if (fish != null)
            {
                return this.Fish.Remove(fish);
            }
            return false;            
        }
        public Fish GetFish(string fishType)
        {
            var fish = this.Fish.FirstOrDefault(f => f.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(f => f.Weight).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}