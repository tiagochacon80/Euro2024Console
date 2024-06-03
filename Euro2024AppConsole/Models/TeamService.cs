using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024AppConsole.Models
{
    public class TeamService
    {
        private readonly List<Team> teams;

        public TeamService()
        {
            teams = new List<Team>
            {
                new Team(1, "Holanda", 0,0,0,0,0,0,0),
                new Team(2, "Italia", 0,0,0,0,0,0,0),
                new Team(3, "França", 0,0,0,0,0,0,0)
            };
        }

        public bool AddTeam(Team team)
        {
            if(GetTeamById(team.Id) == null)
            {
                teams.Add(team);
                return true;
            }
            return false;
        }

        private Team GetTeamById(int id)
        {
            return teams.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTeam(int id, string name, int points, int matchesPlayed, int wins, int draws, int losses, int goalsFor, int goalsAgainst)
        {
            var team = GetTeamById(id);
            if (team != null)
            {
                team.Name = name;
                team.Points = points;
                team.MatchesPlayed = matchesPlayed;
                team.Wins = wins;
                team.Draws = draws;
                team.Losses = losses;
                team.GoalsFor = goalsFor;
                team.GoalsAgainst = goalsAgainst;
                return true;
            }
            return false;
        }        

        public bool DeleteTeam(int id)
        {
            var team = GetTeamById(id);
            if (team != null)
            {
                teams.Remove(team);
                return true;
            }
            return false;
        }

        public List<Team> GetTeams()
        {
            return teams;
        }
    }
}
