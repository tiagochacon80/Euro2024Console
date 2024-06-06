// See https://aka.ms/new-console-template for more information
using Euro2024AppConsole.Models;
using Euro2024AppConsole.utils;
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
                        AddTeam(teamService);
                        break;
                    case "3":
                        UpdateTeam(teamService);
                        break;
                    case "4":
                        DeleteTeam(teamService);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
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
           
            var team = new Team(0, "", 0, 0, 0, 0, 0, 0, 0);
            team.Id = InputValidator.GetValidatedInput("Enter the new team ID: ");
            Console.WriteLine("Enter a new team name: ");
            team.Name = Console.ReadLine();


            team.Points = InputValidator.GetValidatedInput("Enter the points: ");
            team.MatchesPlayed = InputValidator.GetValidatedInput("Enter the matches played: ");
            team.Wins = InputValidator.GetValidatedInput("Enter a wins: ");
            team.Draws = InputValidator.GetValidatedInput("Enter a draws: ");
            team.Losses = InputValidator.GetValidatedInput("Enter the losses: ");
            team.GoalsFor = InputValidator.GetValidatedInput("Enter the goals for: ");
            team.GoalsAgainst = InputValidator.GetValidatedInput("Enter the goals against: ");        
                      

            if (teamService.AddTeam(team))
            {
                Console.WriteLine("Team added successfully!");
            }
            else
            {
                Console.WriteLine("ID already exists.");
            }                           
            Console.WriteLine();
        }

        static void UpdateTeam(TeamService teamService)
        {
            int id = InputValidator.GetValidatedInput("Enter a ID of the team to updated: ");            
            Console.WriteLine("Enter the new team name: ");
            var name = Console.ReadLine();

            int points = InputValidator.GetValidatedInput("Enter the new points: ");
            int matchesPlayed = InputValidator.GetValidatedInput("Enter the new matches played: ");
            int wins = InputValidator.GetValidatedInput("Enter the new wins: ");
            int draws = InputValidator.GetValidatedInput("Enter the new draws: ");
            int losses = InputValidator.GetValidatedInput("Enter the new losses: ");
            int goalsFor = InputValidator.GetValidatedInput("Enter the new goals for: ");
            int goalsAgainst = InputValidator.GetValidatedInput("Enter the new goals against: ");            

            if (teamService.UpdateTeam(id, name, points, matchesPlayed, wins, draws, losses, goalsFor, goalsAgainst))
            {
                Console.WriteLine("Team updated successfully!");
            }
            else
            {
                Console.WriteLine("Error updating team");
            }           
                                            
            Console.WriteLine();
            }
            
        static void DeleteTeam(TeamService teamService)
        {           
            int id = InputValidator.GetValidatedInput("Enter the ID of the team to be deleted: ");           
            if (teamService.DeleteTeam(id))
            {
                Console.WriteLine("team deleted successfully!");
            }
            else
            {
                Console.WriteLine("team not found!");
            }            
            
            Console.WriteLine();
        }
    }
}
