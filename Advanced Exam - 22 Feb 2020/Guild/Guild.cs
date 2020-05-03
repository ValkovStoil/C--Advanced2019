using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster.Count + 1 <= this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.roster
                .FirstOrDefault(n => n.Name == name);

            if (playerToRemove != null)
            {
                this.roster.Remove(playerToRemove);
                
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = this.roster
                .First(n => n.Name == name);

            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToDemote = this.roster
                .First(n => n.Name == name);

            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var kickPlayers = this.roster
                .Where(c => c.Class == @class)
                .ToArray();

            this.roster.RemoveAll(c => c.Class == @class);

            return kickPlayers;
        }

        public string Report()
        {
            var report = new StringBuilder();

            report.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                report.AppendLine(player.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}
