using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            string following = "following";
            string followers = "followers";

            while (input != "Statistics")
            {
                string[] inputArgs = input.Split();
                string action = inputArgs[1];
                string user = inputArgs[0];
                string starUser = inputArgs[2];

                if (action == "joined" && !vlogger.ContainsKey(user))
                {
                    vlogger.Add(user, new Dictionary<string, HashSet<string>>());
                    vlogger[user].Add(following, new HashSet<string>());
                    vlogger[user].Add(followers, new HashSet<string>());
                }
                else if (action == "followed" && vlogger.ContainsKey(user) && vlogger.ContainsKey(starUser) && user != starUser && !vlogger[starUser].ContainsKey(user))
                {
                    vlogger[user][following].Add(starUser);
                    vlogger[starUser][followers].Add(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            var sortedVloggers = vlogger.OrderByDescending(x => x.Value[followers].Count).ThenBy(x => x.Value[following].Count);

            int counter = 1;

            foreach (var currentVloger in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {currentVloger.Key} : {currentVloger.Value[followers].Count} followers, {currentVloger.Value[following].Count} following");

                if (counter == 1)
                {
                    foreach (var item in currentVloger.Value[followers].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }                    
                }
                counter++;
            }
        }
    }
}
