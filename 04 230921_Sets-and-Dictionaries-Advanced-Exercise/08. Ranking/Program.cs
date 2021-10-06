using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var participants = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] commandArgs = command.Split(":");
                string contestName = commandArgs[0];
                string password = commandArgs[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] inputArgs = command.Split("=>");

                string contestName = inputArgs[0];
                string password = inputArgs[1];
                string participant = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (!contests.ContainsKey(contestName))
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (contests[contestName] != password)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (!participants.ContainsKey(participant))
                {
                    participants.Add(participant, new Dictionary<string, int>());
                }

                if (!participants[participant].ContainsKey(contestName))
                {
                    participants[participant].Add(contestName, 0);
                }

                if (participants[participant][contestName] < points)
                {
                    participants[participant][contestName] = points;
                }

                command = Console.ReadLine();
            }

            int topSum = 0;
            string name = "";

            foreach (var participant in participants)
            {
                if (participant.Value.Sum(x => x.Value) > topSum)
                {
                    topSum = participant.Value.Sum(x => x.Value);
                    name = participant.Key;
                }

            }

            Console.WriteLine($"Best candidate is {name} with total {topSum} points.");
            Console.WriteLine($"Ranking:");

            foreach (var item in participants.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}