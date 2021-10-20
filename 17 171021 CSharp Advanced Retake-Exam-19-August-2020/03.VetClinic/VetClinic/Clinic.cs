using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count { get {return Data.Count; } }
        public List<Pet> Data { get; set; }

        public void Add(Pet pet) 
        {
            if (Data.Count < Capacity)
            {
                Data.Add(pet);
            }
        }

        public bool Remove(string name) 
        {
            Pet pet = Data.FirstOrDefault(p => p.Name == name);
            if (pet == null)
            {
                return false;
            }

            Data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = Data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet() 
        {
            return Data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics() 
        {
            var result = new StringBuilder();
            result.AppendLine($"The clinic has the following patients:");
            foreach (var pet in Data)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return result.ToString().TrimEnd();
        }
    }
}