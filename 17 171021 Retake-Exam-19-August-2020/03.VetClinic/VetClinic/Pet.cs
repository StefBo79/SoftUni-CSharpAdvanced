﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }
        public override string ToString()
        {
            //var sb = new StringBuilder();
            //sb.AppendLine($"Name: {Name}");
            //sb.AppendLine($"Age: {Age}");
            //sb.AppendLine($"Owner: {Owner}");
            //return sb.ToString().TrimEnd();
            return $"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}";
        }
    }
}
