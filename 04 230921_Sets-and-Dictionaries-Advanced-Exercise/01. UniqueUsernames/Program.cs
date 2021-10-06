using System;
using System.Collections.Generic;

namespace _01._UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> nicknames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                nicknames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, nicknames));
        }
    }
}
