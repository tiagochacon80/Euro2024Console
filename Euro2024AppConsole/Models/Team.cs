using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024AppConsole.Models
{
    public class Team
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;

        public Team() { }

        public Team(int id, string name, int points, int matchesPlayed, int wins, int draws, int losses, int goalsFor, int goalsAgainst)
        {
            Id = id;
            Name = name;
            Points = points;
            MatchesPlayed = matchesPlayed;
            Wins = wins;
            Draws = draws;
            Losses = losses;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
        }

    }
}
