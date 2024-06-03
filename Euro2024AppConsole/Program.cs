// See https://aka.ms/new-console-template for more information
using Euro2024AppConsole.Models;
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
            }
        }
    }
}
