using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Vlogger>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputArgs = input.Split();

                string action = inputArgs[1];
                string user = inputArgs[0];
                string starUser = inputArgs[2];

                if (action == "joined" && !vlogger.ContainsKey(user))
                {
                    vlogger.Add(user, new Vlogger());
                }
                else if (action == "followed" && vlogger.ContainsKey(user)
                    && vlogger.ContainsKey(starUser) && user != starUser)
                {
                    vlogger[user].Following.Add(starUser);
                    vlogger[starUser].Followers.Add(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            var sortedVloggers = vlogger.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count);

            int counter = 1;

            foreach (var currentVlogger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {currentVlogger.Key} : {currentVlogger.Value.Followers.Count} followers, {currentVlogger.Value.Following.Count} following");

                if (counter == 1)
                {
                    foreach (var item in currentVlogger.Value.Following.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
        }
    }

    public class Vlogger
    {
        public Vlogger()
        {
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }

        public HashSet<string> Followers { get; set; }

        public HashSet<string> Following { get; set; }
    }
}