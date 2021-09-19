using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumАndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> elements = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    elements.Push(int.Parse(command[1]));
                }
                else if (command[0] == "2")
                {
                    if (elements.Any())
                    {
                        elements.Pop();
                    }                    
                }
                else if (command[0] == "3")
                {
                    if (elements.Count > 0)
                    {
                       Console.WriteLine(elements.Max());
                    }                    
                }
                else if (command[0] == "4")
                {
                    if (elements.Count > 0)
                    {
                        Console.WriteLine(elements.Min());
                    }                    
                }                
            }
            Console.Write(string.Join(", ", elements));
        }
    }
}
