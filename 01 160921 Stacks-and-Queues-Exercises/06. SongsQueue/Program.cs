using System;
using System.Collections.Generic;

namespace _06._SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {            
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            string command = Console.ReadLine();

            while (songs.Count > 0)
            {
                int indexSeparator = command.IndexOf(' ');

                string[] commandArgs = command.Split();
                string action = commandArgs[0];

                if (action == "Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    string songToBeAdded = command.Substring(indexSeparator + 1);

                    if (songs.Contains(songToBeAdded))
                    {
                        Console.WriteLine($"{songToBeAdded} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songToBeAdded);
                    }                    
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
