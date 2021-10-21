using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            var threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    break;
                }
                if (tasks.Peek() <= threads.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
