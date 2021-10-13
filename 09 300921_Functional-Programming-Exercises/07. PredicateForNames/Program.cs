using System;
using System.Linq;

namespace _07._PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> nameLenght = (name, lenght) => name.Length <= lenght;

            int maxLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split()
                .Where(x => nameLenght(x, maxLenght))
                .ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
