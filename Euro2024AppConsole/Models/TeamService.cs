using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024AppConsole.Models
{
    public class TeamService
    {
        private List<Team> teams = new List<Team>();
        private HashSet<int> teamIds = new HashSet<int>(); 

        
        public TeamService()
        {
            teams = new List<Team>
            {
                new Team(1, "Holanda", 0,0,0,0,0,0,0),
                new Team(2, "Italia", 0,0,0,0,0,0,0),
                new Team(3, "França", 0,0,0,0,0,0,0)
            };

            foreach(var team in teams)
            {
                teamIds.Add(team.Id);
            }
        }
        

        public bool AddTeam(Team team)
        {
            if (teamIds.Contains(team.Id))
            {
                return false;
            }
            else
            {
                teams.Add(team);
                teamIds.Add(team.Id);
                return true;
            }           
        }

        private Team GetTeamById(int id)
        {
            return teams.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTeam(int id, string name, int points, int matchesPlayed, int wins, int draws, int losses, int goalsFor, int goalsAgainst)
        {
            var team = GetTeamById(id);
            if (team == null)
            {
                return false;
            }   
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

        public bool DeleteTeam(int id)
        {
            var team = GetTeamById(id);
            if (team == null)
            {
                return false;               
            }
            teams.Remove(team);
            teamIds.Remove(id);
            return true;

        }

        public List<Team> GetTeams()
        {
            return teams;
        }
    }
}
