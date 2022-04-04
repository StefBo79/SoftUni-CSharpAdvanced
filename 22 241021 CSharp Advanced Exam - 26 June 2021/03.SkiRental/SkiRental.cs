using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (Capacity >= data.Count + 1)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (ski == null)
            {
                return false;
            }
            else
            {
                data.Remove(ski);
                return true;
            }
        }
        public Ski GetNewestSki()
        {
            return data.OrderByDescending(s => s.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString().TrimEnd());
            }
            return sb.ToString();
        }
    }
}