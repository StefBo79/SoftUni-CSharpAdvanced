using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roster = new List<Player>();
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return false;
            }
            roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string classy)
        {
            List<Player> tempList = new List<Player>();
            foreach (var player in roster)
            {
                if (player.Class == classy)
                {
                    tempList.Add(player);
                }
            }
            Player[] arrayToReturn = tempList.ToArray();

            roster = roster.Where(x => x.Class != classy).ToList();
            return arrayToReturn;
        }

        public String Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
                sb.AppendLine($"Rank: {player.Rank}");
                sb.AppendLine($"Description: {player.Description}");
            }
            return sb.ToString().TrimEnd();
        }
    }    
}