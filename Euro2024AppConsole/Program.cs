// See https://aka.ms/new-console-template for more information
using Euro2024AppConsole.Models;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Euro2024AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamService teamService = new TeamService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Eurocup cup table 2024");
                Console.WriteLine("1. List Teams");
                Console.WriteLine("2. Add Team");
                Console.WriteLine("3. Update Team");
                Console.WriteLine("4. Delete Team");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option: ");
                var choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        ListTeams(teamService);
                        break;
                    case "2":
                        Add
                }
            }
        }

        static void ListTeams(TeamService teamService)
        {
            var teams = teamService.GetTeams();
            Console.WriteLine("\nTeams: ");
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.Id}, Name: {team.Name}, Points: {team.Points}, Matches Played: {team.MatchesPlayed}, Wins: {team.Wins}, Draws: {team.Draws}, Losses: {team.Losses}, Goals For: {team.GoalsFor}, Goals Against: {team.GoalsAgainst}, Goal Difference: {team.GoalDifference}");
            }
            Console.WriteLine();
        }

        static void AddTeam(TeamService teamService)
        {
            Console.WriteLine("Enter the new team ID: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                var team = new Team(id, "", 0, 0, 0, 0, 0, 0, 0);
                Console.WriteLine("Enter a new team name: ");
                team.Name = Console.ReadLine();

                Console.WriteLine("Enter the points: ");
                if(int.TryParse(Console.ReadLine(), out int points))
                {
                    team.Points = points;
                }

                Console.WriteLine("Enter the matches played: ");
                if (int.TryParse(Console.ReadLine(), out int matchesPlayed))
                {
                    team.MatchesPlayed = matchesPlayed;
                }

                Console.WriteLine("Enter a wins: ");
                if (int.TryParse(Console.ReadLine(), out int wins))
                {
                    team.Wins = wins;
                }

                Console.WriteLine("Enter a draws: ");
                if(int.TryParse(Console.ReadLine(), out int draws))
                {
                    team.Draws = draws;
                }

                Console.WriteLine("Enter the losses: ");
                if(int.TryParse(Console.ReadLine(), out int losses))
                {
                    team.Losses = losses;
                }

                Console.WriteLine("Enter the new goals for: ");
                if(int.TryParse(Console.ReadLine(), out int goalsFor))
                {
                    team.GoalsFor = goalsFor;
                }

                Console.Write("Enter the new goals against: ");
                if(int.TryParse(Console.ReadLine(), out int goalsAgainst))
                {
                    team.GoalsAgainst = goalsAgainst;
                }

                if (teamService.AddTeam(team))
                {
                    Console.WriteLine("Team added successfully!");
                }
                else
                {
                    Console.WriteLine("ID already exists.");
                }                
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine();
        }

        static void UpdateTeam(TeamService teamService)
        {
            Console.WriteLine("Enter a ID of the team to updated: ");
            if(int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Enter the new team name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the new points: ");
                int.TryParse(Console.ReadLine(), out int points);

                Console.WriteLine("Enter the new matches played: ");
                int.TryParse(Console.ReadLine(), out int matchesPlayed);

                Console.WriteLine("Enter the new wins: ");
                int.TryParse(Console.ReadLine(), out int wins);

                Console.WriteLine("Enter the new draws: ");
                int.TryParse(Console.ReadLine(), out int draws);

                Console.Write("Enter the new losses: ");
                int.TryParse(Console.ReadLine(), out int losses);

                Console.Write("Enter the new goals for: ");
                int.TryParse(Console.ReadLine(), out int goalsFor);

                Console.Write("Enter the new goals against: ");
                int.TryParse(Console.ReadLine(), out int goalsAgainst);

                if(teamService.UpdateTeam(id, name, points, matchesPlayed, wins, draws, losses, goalsFor, goalsAgainst))
                {
                    Console.WriteLine("Team updated successfully!");
                }
                else
                {
                    Console.WriteLine("Error updating team");
                }
                else
                {
                    Console.WriteLine("Invalid ID");
                }
                Console.WriteLine();
            }


        }
    }
}
