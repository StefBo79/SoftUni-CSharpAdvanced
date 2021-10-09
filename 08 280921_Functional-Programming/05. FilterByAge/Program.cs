using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FilterByAge
{
    class Person
    {
        public string Name;
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split(", ");
                var person = new Person();
                person.Name = inputArgs[0];
                person.Age = int.Parse(inputArgs[1]);
                people.Add(person);
            }

            var filteredName = Console.ReadLine();
            var ageToCompare = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;
            if (filteredName == "younger")
            {
                filter = p => p.Age < ageToCompare;
            }
            else if (filteredName == "older")
            {
                filter = p => p.Age >= ageToCompare;
            }

            var filteredPeople = people.Where(filter);
            var printName = Console.ReadLine();

            Func<Person, string> printFunc = p => p.Name + " " + p.Age;
            if (printName == "name age")
            {
                printFunc = p => p.Name + " - " + p.Age;
            }
            else if (printName == "name")
            {
                printFunc = p => p.Name;
            }
            else if (printName == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var personAsString = filteredPeople.Select(printFunc);
            foreach (var prs in personAsString)
            {
                Console.WriteLine(prs);
            }
           
        }
    }
}
